using System.ComponentModel;

namespace AttendanceTracker
{
    public class Student
    {
        public const string SelectedColumnName  = "Selected";
        public const string FirstNameColumnName = "First Name";
        public const string LastNameColumnName  = "Last Name";
        public const string CheckedInColumnName = "Checked In";

        [DisplayName(SelectedColumnName)]
        public bool Selected { get; set; }

        [DisplayName(FirstNameColumnName)]
        public string FirstName { get; }

        [DisplayName(LastNameColumnName)]
        public string LastName { get; }

        [DisplayName(CheckedInColumnName)]
        public bool CheckedIn { get; private set; }

        public Student(string firstName, string lastName)
        {
            Selected  = false;
            FirstName = firstName;
            LastName  = lastName;
            CheckedIn = false;
        }

        public void CheckIn(bool checkIn)
        {
            CheckedIn = checkIn;
        }
    }
}
