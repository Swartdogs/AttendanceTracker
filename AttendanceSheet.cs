using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AttendanceTracker
{
    public class AttendanceSheet
    {
        public class Record
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime InTime { get; set; }
            public DateTime OutTime { get; set; }
        }

        public static readonly string DEFAULT_ATTENDANCE_FILE = Path.Combine(Settings.SETTINGS_FOLDER_PATH, "attendance.att");

        private IList<Record> _records = new List<Record>();

        private AttendanceSheet(IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                var parts = line.Split(',');

                if (parts.Length != 4) continue;

                _records.Add(new Record()
                {
                    FirstName = parts[0],
                    LastName  = parts[1],
                    InTime    = DateTime.Parse(parts[2]),
                    OutTime   = DateTime.Parse(parts[3])
                });
            }
        }

        public AttendanceSheet()
        {
            // do nothing
        }

        public void AddRecord(Record record)
        {
            _records.Add(record);
        }

        public void WriteToFile(string filePath)
        {
            var lines = new List<string>()
            {
                "First Name,Last Name,In Time,Out Time"
            };

            lines.AddRange(_records.Select(r => $"{r.FirstName},{r.LastName},{r.InTime},{r.OutTime}"));

            File.WriteAllLines(filePath, lines);
        }

        public static AttendanceSheet ReadFromFile(string filePath)
        {
            AttendanceSheet sheet = null;

            if (File.Exists(filePath))
            {
                sheet = new AttendanceSheet(File.ReadAllText(filePath).Replace("\r\n", "\n").Split('\n').Skip(1));
            }

            return sheet;
        }
    }
}
