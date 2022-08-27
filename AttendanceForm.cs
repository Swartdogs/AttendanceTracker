using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AttendanceTracker
{
    public partial class AttendanceForm : Form
    {
        private static readonly string DEFAULT_MENTOR_CODE = "0000";

        private string                       _mentorCode;
        private List<Button>                 _mentorButtons;
        private Dictionary<string, Student>  _students;
        private bool                         _locked;

        public AttendanceForm()
        {
            InitializeComponent();

            _locked     = true;
            _mentorCode = DEFAULT_MENTOR_CODE;

            _mentorButtons = new List<Button>()
            {
                _lockButton,
                _forceCheckoutButton,
                _removeStudentButton
            };

            _students = new Dictionary<string, Student>()
            {
                { "0", new Student("Seran",  "Wrap") },
                { "1", new Student("Silver", "Ware") }
            };

            ResetStudentDataGridView();

            SetColumnEnabled(Student.SelectedColumnName, false);
        }

        public void UnlockForm()
        {
            _locked = false;
            SetMenuStripEnabled(true);
            SetMentorButtonsEnabled(true);
            SetColumnEnabled(Student.SelectedColumnName, true);
        }

        public void LockForm()
        {
            _locked = true;
            SetMenuStripEnabled(false);
            SetMentorButtonsEnabled(false);
            SetColumnEnabled(Student.SelectedColumnName, false);
        }

        public void CheckIn()
        {
            string id = _idTextBox.Text;
            _idTextBox.Text = string.Empty;

            if (!string.IsNullOrWhiteSpace(id))
            {

                if (id == _mentorCode)
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
                    _students[id].CheckIn(!_students[id].CheckedIn);
                }

                else
                {
                    var newStudentForm = new NewStudentForm(_mentorCode);
                    var result = newStudentForm.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        _students.Add(id, newStudentForm.NewStudent);
                        newStudentForm.NewStudent.CheckIn(true);
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

        public void ForceCheckout()
        {
            var result = MessageBox.Show("Confirming will force check out ALL students. Are you sure?", "Force Checkout", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                foreach (var student in _students.Values.Where(s => s.CheckedIn))
                {
                    student.CheckIn(false);
                }

                _studentDataGridView.Refresh();
            }
        }

        public void RemoveStudents()
        {
            var confirm = MessageBox.Show("Confirming will remove ALL selected students. Are you sure?", "Remove Students", MessageBoxButtons.OKCancel);

            if (confirm == DialogResult.OK)
            {
                foreach (string key in _students.Where(s => s.Value.Selected).Select(s => s.Key).ToArray())
                {
                    _students.Remove(key);
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

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            CheckIn();
            _idTextBox.Focus();
        }

        private void LockButton_Click(object sender, EventArgs e)
        {
            LockForm();
            _idTextBox.Focus();
        }

        private void ForceCheckoutButton_Click(object sender, EventArgs e)
        {
            ForceCheckout();
            _idTextBox.Focus();
        }

        private void RemoveStudentButton_Click(object sender, EventArgs e)
        {
            RemoveStudents();
            _idTextBox.Focus();
        }

        private void IdTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && ActiveForm == this)
            {
                CheckIn();
                e.Handled = true;
            }
        }

        private void StudentDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            _studentDataGridView.ClearSelection();
        }

        private void StudentDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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

        private void SettingsStripSettings_Click(object sender, EventArgs e)
        {
            var settingsForm = new SettingsForm(_mentorCode);
            var result = settingsForm.ShowDialog();

            switch (result)
            {
                case DialogResult.OK:
                    _mentorCode = settingsForm.NewMentorCode;
                    break;

                default:
                    break;
            }
        }
    }
}
