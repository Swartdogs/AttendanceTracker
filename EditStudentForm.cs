using System;
using System.Windows.Forms;

namespace AttendanceTracker
{
    public partial class EditStudentForm : Form
    {
        private readonly Student _student;

        public EditStudentForm(Student student)
        {
            InitializeComponent();

            _student               = student;

            _firstNameTextBox.Text = _student.FirstName;
            _lastNameTextBox.Text  = _student.LastName;
            _emailTextBox.Text     = _student.Email;
            _idTextBox.Text        = _student.ID;

            DialogResult = DialogResult.Cancel;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            _student.Update(_firstNameTextBox.Text, _lastNameTextBox.Text, _emailTextBox.Text, _idTextBox.Text);
            DialogResult = DialogResult.OK;

            Close();
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
