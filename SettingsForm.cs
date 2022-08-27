using System;
using System.Windows.Forms;

namespace AttendanceTracker
{
    public partial class SettingsForm : Form
    {
        public string NewMentorCode => _mentorCodeTextBox.Text;

        private readonly string _existingMentorCode;

        public SettingsForm(string existingMentorCode)
        {
            InitializeComponent();

            _existingMentorCode = existingMentorCode;
            _mentorCodeTextBox.Text = _existingMentorCode;
        }

        public void OkButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_mentorCodeTextBox.Text))
            {
                MessageBox.Show("Mentor code may not be empty!", "Error", MessageBoxButtons.OK);
            }
            else if (_mentorCodeTextBox.Text != _existingMentorCode)
            {
                var result = MessageBox.Show($"Mentor code will be set to: {_mentorCodeTextBox.Text}", "Confirm", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    Close(result);
                }
            }
            else
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

        public void Close(DialogResult result)
        {
            DialogResult = result;
            Close();
        }
    }
}
