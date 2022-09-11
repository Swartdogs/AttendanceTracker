using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AttendanceTracker
{
    public partial class AttendanceForm : Form
    {
        // Two minutes to form auto-lock
        private const int LOCK_TIME = 120000;

        private Settings                     _settings;
        private List<Button>                 _mentorButtons;
        private IDictionary<string, Student> _students;
        private AttendanceSheet              _attendance;
        private bool                         _locked;
        private readonly Timer               _lockTimer = new Timer();

        public AttendanceForm()
        {
            InitializeComponent();

            _settings = Settings.Load();

            if (_settings is null)
            {
                CreateSettings();
            }

            LoadStudents();
            LoadAttendance();

            _locked = true;

            _mentorButtons = new List<Button>()
            {
                _lockButton,
                _forceCheckoutButton,
                _removeStudentButton
            };

            ResetStudentDataGridView();
            SetColumnEnabled(Student.SelectedColumnName, false);

            _lockTimer.Interval = LOCK_TIME;
            _lockTimer.Tick += new EventHandler(LockTimerElapsed);
        }

        public void UnlockForm()
        {
            _locked = false;
            SetMenuStripEnabled(true);
            SetMentorButtonsEnabled(true);
            SetColumnEnabled(Student.SelectedColumnName, true);
            _lockTimer.Enabled = true;
        }

        public void LockForm()
        {
            _locked = true;
            SetMenuStripEnabled(false);
            SetMentorButtonsEnabled(false);
            SetColumnEnabled(Student.SelectedColumnName, false);
            _lockTimer.Enabled = false;
        }

        public void CheckIn()
        {
            string id = _idTextBox.Text;
            _idTextBox.Text = string.Empty;

            if (!string.IsNullOrWhiteSpace(id))
            {

                if (id == _settings.MentorCode.Value)
                {
                    if (_locked)
                    {
                        UnlockForm();
                    }

                    else
                    {
                        LockForm();
                    }
                }

                else if (_students.ContainsKey(id))
                {
                    if (_students[id].CheckedIn)
                    {
                        _attendance.AddRecord(_students[id].CheckOut(false));
                        _attendance.WriteToFile(_settings.AttendanceFile.Value);
                    }
                    else
                    {
                        _students[id].CheckIn();
                    }
                }

                else
                {
                    var newStudentForm = new NewStudentForm(_settings.MentorCode.Value);
                    var result = newStudentForm.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        _students.Add(id, newStudentForm.NewStudent);
                        newStudentForm.NewStudent.CheckIn();

                        StudentFile.WriteToFile(_students, _settings.StudentFile.Value);
                    }

                    bool visible = false;

                    if (TryGetStudentDataGridViewColumn(Student.SelectedColumnName, out var column))
                    {
                        visible = column.Visible;
                    }

                    ResetStudentDataGridView();
                    SetColumnEnabled(Student.SelectedColumnName, visible);
                }
            }

            _studentDataGridView.Refresh();
        }

        public void ConfirmForceCheckout()
        {
            var result = MessageBox.Show("Confirming will force check out ALL students. Are you sure?", "Force Checkout", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                ForceCheckout();
            }
        }

        public void ForceCheckout()
        {
            foreach (var student in _students.Values.Where(s => s.CheckedIn))
            {
                _attendance.AddRecord(student.CheckOut(true));
            }

            _attendance.WriteToFile(_settings.AttendanceFile.Value);

            _studentDataGridView.Refresh();
        }

        public void RemoveStudents()
        {
            var confirm = MessageBox.Show("Confirming will remove ALL selected students. Are you sure?", "Remove Students", MessageBoxButtons.OKCancel);

            if (confirm == DialogResult.OK)
            {
                var studentsRemoved = false;

                foreach (string key in _students.Where(s => s.Value.Selected).Select(s => s.Key).ToArray())
                {
                    _students.Remove(key);
                    studentsRemoved = true;
                }

                if (studentsRemoved)
                {
                    StudentFile.WriteToFile(_students, _settings.StudentFile.Value);
                }

                ResetStudentDataGridView();
                SetColumnEnabled(Student.SelectedColumnName, true);
            }
        }

        public void SetMenuStripEnabled(bool enabled)
        {
            _settingsStrip.Visible = enabled;
            _settingsStrip.Enabled = enabled;

            foreach (var control in new Control[] { 
                _idTextBox,
                _submitButton,
                _lockButton,
                _forceCheckoutButton,
                _removeStudentButton,
                _studentDataGridView
            })
            {
                control.Top += (enabled ? 1 : -1) * _settingsStrip.Height;
            }

            _studentDataGridView.Height += (enabled ? -1 : 1) * _settingsStrip.Height;
        }

        public void SetMentorButtonsEnabled(bool enabled)
        {
            foreach (var button in _mentorButtons)
            {
                button.Enabled = enabled;
                button.Visible = enabled;
            }
        }

        public void SetColumnEnabled(string columnName, bool enabled)
        {
            if (TryGetStudentDataGridViewColumn(columnName, out var column))
            {
                column.Visible = enabled;
            }
        }

        public void SetColumnAutoSizeMode(string columnName, DataGridViewAutoSizeColumnMode autoSizeMode)
        {
            if (TryGetStudentDataGridViewColumn(columnName, out var column))
            {
                column.AutoSizeMode = autoSizeMode;
            }
        }

        public bool TryGetStudentDataGridViewColumn(string columnName, out DataGridViewColumn column)
        {
            return (column = _studentDataGridView.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.HeaderText == columnName)) != null;
        }

        public void ResetStudentDataGridView()
        {
            _studentDataGridView.DataSource = typeof(Student);
            _studentDataGridView.DataSource = new BindingSource(_students.Values.OrderBy(s => s.FirstName).ThenBy(s => s.LastName), null);

            SetColumnAutoSizeMode(Student.SelectedColumnName,  DataGridViewAutoSizeColumnMode.AllCells);
            SetColumnAutoSizeMode(Student.FirstNameColumnName, DataGridViewAutoSizeColumnMode.AllCells);
            SetColumnAutoSizeMode(Student.LastNameColumnName,  DataGridViewAutoSizeColumnMode.AllCells);
            SetColumnAutoSizeMode(Student.CheckedInColumnName, DataGridViewAutoSizeColumnMode.Fill);
        }

        public void CreateSettings()
        {
            MessageBox.Show($"Settings file not found. One will be created at {Settings.SETTINGS_FILE_PATH}", "Create Settings File");

            Directory.CreateDirectory(Settings.SETTINGS_FOLDER_PATH);

            _settings = new Settings();
            _settings.Reset();
            _settings.Write();
        }

        public void CreateStudentsFile()
        {
            MessageBox.Show($"Students file not found at {_settings.StudentFile.Value}. One will be created.", "Create Students File");

            Directory.CreateDirectory(Path.GetDirectoryName(_settings.StudentFile.Value));

            StudentFile.WriteToFile(null, _settings.StudentFile.Value);
            _students = new Dictionary<string, Student>();
        }

        public void CreateAttendanceFile()
        {
            MessageBox.Show($"Attendance file not found at {_settings.AttendanceFile.Value}. One will be created.", "Create Attendance File");

            Directory.CreateDirectory(Path.GetDirectoryName(_settings.AttendanceFile.Value));

            _attendance = new AttendanceSheet();
            _attendance.WriteToFile(_settings.AttendanceFile.Value);
        }

        public void SubmitButton_Click(object sender, EventArgs e)
        {
            CheckIn();
            _idTextBox.Focus();
        }

        public void LockButton_Click(object sender, EventArgs e)
        {
            LockForm();
            _idTextBox.Focus();
        }

        public void ForceCheckoutButton_Click(object sender, EventArgs e)
        {
            ConfirmForceCheckout();
            _idTextBox.Focus();
        }

        public void RemoveStudentButton_Click(object sender, EventArgs e)
        {
            RemoveStudents();
            _idTextBox.Focus();
        }

        public void IdTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && ActiveForm == this)
            {
                CheckIn();
                e.Handled = true;
            }
        }

        public void StudentDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            _studentDataGridView.ClearSelection();
        }

        public void StudentDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var student = _studentDataGridView.Rows[e.RowIndex].DataBoundItem as Student;

            if (TryGetStudentDataGridViewColumn(Student.CheckedInColumnName, out var column))
            {
                if (column.Index == e.ColumnIndex)
                {
                    if (student.CheckedIn)
                    {
                        e.CellStyle.BackColor = Color.Orange;
                    }

                    else
                    {
                        e.CellStyle.BackColor = Color.White;
                    }
                }
            }
        }

        public void SettingsStripSettings_Click(object sender, EventArgs e)
        {
            var result = new SettingsForm(_settings).ShowDialog();

            if (result == DialogResult.OK)
            {
                if (_settings.StudentFile.Changed)
                {
                    ForceCheckout();
                }

                _settings.Save();
                _settings.Write();

                LoadStudents();

                ResetStudentDataGridView();
                SetColumnEnabled(Student.SelectedColumnName, false);
            }
        }

        public void LoadStudents()
        {
            _students = StudentFile.ReadFromFile(_settings.StudentFile.Value);

            if (_students is null)
            {
                CreateStudentsFile();
            }
        }

        public void LoadAttendance()
        {
            _attendance = AttendanceSheet.ReadFromFile(_settings.AttendanceFile.Value);

            if (_attendance is null)
            {
                CreateAttendanceFile();
            }
        }

        private void LockTimerElapsed(object sender, EventArgs e)
        {
            LockForm();
        }
    }
}
