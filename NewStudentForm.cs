using System;
using System.Windows.Forms;

namespace AttendanceTracker
{
    public partial class NewStudentForm : Form
    {
        public Student NewStudent { get; private set; }

        private readonly string _mentorCode;
        private readonly string _id;

        public NewStudentForm(string mentorCode, string id)
        {
            InitializeComponent();

            NewStudent   = null;
            DialogResult = DialogResult.None;

            _mentorCode = mentorCode;
            _id         = id;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_firstNameTextBox.Text.Trim()))
            {
                MessageBox.Show("Students must have a first name!", "Error", MessageBoxButtons.OK);
            }
            else if (string.IsNullOrWhiteSpace(_lastNameTextBox.Text.Trim()))
            {
                MessageBox.Show("Students must have a last name!", "Error", MessageBoxButtons.OK);
            }
            else if (_mentorCodeTextBox.Text != _mentorCode)
            {
                MessageBox.Show("Mentor code incorrect!", "Error", MessageBoxButtons.OK);
            } 
            else
            {
                NewStudent = new Student(_firstNameTextBox.Text.Trim(), _lastNameTextBox.Text.Trim(), _emailTextBox.Text.Trim(), _id);
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            NewStudent = null;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void MentorCodeTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && ActiveForm == this)
            {
                OkButton_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}
