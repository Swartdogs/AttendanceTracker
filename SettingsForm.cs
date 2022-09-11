using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AttendanceTracker
{
    public partial class SettingsForm : Form
    {
        public string NewMentorCode => _mentorCodeTextBox.Text;

        private Settings _settings;

        private Dictionary<Setting, Tuple<TextBox, string>> _settingDescriptions = new Dictionary<Setting, Tuple<TextBox, string>>();

        public SettingsForm(Settings currentSettings)
        {
            InitializeComponent();

            _settings = currentSettings;

            _settingDescriptions = new Dictionary<Setting, Tuple<TextBox, string>>()
            {
                { _settings.MentorCode,     Tuple.Create(_mentorCodeTextBox,     "Mentor code")     },
                { _settings.StudentFile,    Tuple.Create(_studentFileTextBox,    "Student file")    },
                { _settings.AttendanceFile, Tuple.Create(_attendanceFileTextBox, "Attendance file") }
            };

            foreach (var kvp in _settingDescriptions)
            {
                kvp.Value.Item1.Text = kvp.Key.Value;
            }
        }

        public void OkButton_Click(object sender, EventArgs e)
        {
            bool exit = true;

            _settings.GetAllSettings().ToList().ForEach(s => s.Value = _settingDescriptions[s].Item1.Text);

            if (string.IsNullOrWhiteSpace(_mentorCodeTextBox.Text))
            {
                MessageBox.Show("Mentor code may not be empty!", "Error", MessageBoxButtons.OK);
                _settings.MentorCode.Reset();
                exit = false;
            }
            else
            {
                foreach (var setting in _settings.GetAllSettings())
                {
                    if (setting.Changed)
                    {
                        var result = MessageBox.Show($"{_settingDescriptions[setting].Item2} will be set to {setting.Value}", "Confirm", MessageBoxButtons.OKCancel);

                        if (result != DialogResult.OK)
                        {
                            setting.Reset();
                            exit = false;
                            break;
                        }
                    }
                }
            }

            if (exit)
            {
                Close(DialogResult.OK);
            }
        }

        public void CancelButton_Click(object sender, EventArgs e)
        {
            Close(DialogResult.Cancel);
        }

        public void MentorCodeTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && ActiveForm == this)
            {
                OkButton_Click(sender, e);
                e.Handled = true;
            }
        }

        public void StudentFileBrowseButton_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Path.GetDirectoryName(_settings.StudentFile.Value);
                openFileDialog.Filter = "Student data files (*.stu)|*.stu|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _studentFileTextBox.Text = openFileDialog.FileName;
                }
            }
        }

        private void AttendanceFileBrowseButton_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Path.GetDirectoryName(_settings.AttendanceFile.Value);
                openFileDialog.Filter = "Attendance sheet files (*.att)|*.att|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _attendanceFileTextBox.Text = openFileDialog.FileName;
                }
            }
        }

        public void Close(DialogResult result)
        {
            DialogResult = result;
            Close();
        }
    }
}
