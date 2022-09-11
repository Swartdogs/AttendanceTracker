using System;
using System.ComponentModel;

using Newtonsoft.Json;

namespace AttendanceTracker
{
    public class Student
    {
        public const string SelectedColumnName  = "Selected";
        public const string FirstNameColumnName = "First Name";
        public const string LastNameColumnName  = "Last Name";
        public const string CheckedInColumnName = "Checked In";

        [DisplayName(SelectedColumnName)]
        [JsonIgnore]
        public bool Selected { get; set; }

        [DisplayName(FirstNameColumnName)]
        [JsonProperty("first")]
        public string FirstName { get; }

        [DisplayName(LastNameColumnName)]
        [JsonProperty("last")]
        public string LastName { get; }

        [Browsable(false)]
        [JsonProperty("email", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue("")]
        public string Email { get; }

        [Browsable(false)]
        [JsonIgnore]
        public DateTime? CheckInTime { get; private set; }

        [DisplayName(CheckedInColumnName)]
        [JsonIgnore]
        public bool CheckedIn => CheckInTime.HasValue;

        public Student(string firstName, string lastName, string email)
        {
            Selected    = false;
            FirstName   = firstName;
            LastName    = lastName;
            Email       = email;
            CheckInTime = null;
        }

        public void CheckIn()
        {
            CheckInTime = DateTime.Now;
        }

        public AttendanceSheet.Record CheckOut(bool forced)
        {
            DateTime outTime = DateTime.Now;

            if (forced && CheckedIn)
            {
                outTime = CheckInTime.Value.AddMinutes(10);
            }

            AttendanceSheet.Record record = new AttendanceSheet.Record()
            {
                FirstName = FirstName,
                LastName  = LastName,
                InTime    = CheckInTime.Value,
                OutTime   = outTime
            };

            CheckInTime = null;

            return record;
        }
    }
}
