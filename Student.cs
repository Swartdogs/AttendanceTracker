using System;
using System.ComponentModel;

using Newtonsoft.Json;

namespace AttendanceTracker
{
    public class Student
    {
        public const string SelectedColumnName    = "Selected";
        public const string FirstNameColumnName   = "First Name";
        public const string LastNameColumnName    = "Last Name";
        public const string CheckInTimeColumnName = "Check In Time";
        public const string CheckedInColumnName   = "Checked In";

        [DisplayName(SelectedColumnName)]
        [JsonIgnore]
        public bool Selected { get; set; }

        [DisplayName(FirstNameColumnName)]
        [JsonProperty("first")]
        public string FirstName { get; private set; }

        [DisplayName(LastNameColumnName)]
        [JsonProperty("last")]
        public string LastName { get; private set; }

        [Browsable(false)]
        [JsonProperty("id")]
        public string ID { get; set; }

        [Browsable(false)]
        [JsonProperty("email", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue("")]
        public string Email { get; set; }

        [DisplayName(CheckInTimeColumnName)]
        [JsonIgnore]
        public DateTime? CheckInTime { get; private set; }

        [DisplayName(CheckedInColumnName)]
        [JsonIgnore]
        public bool CheckedIn => CheckInTime.HasValue;

        public Student(string firstName, string lastName, string email, string id)
        {
            Selected    = false;
            FirstName   = firstName;
            LastName    = lastName;
            Email       = email;
            ID          = id;
            CheckInTime = null;
        }

        public void Update(string firstName, string lastName, string email, string id)
        {
            FirstName = firstName;
            LastName  = lastName;
            Email     = email;
            ID        = id;
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
