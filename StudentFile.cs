using System.Collections.Generic;
using System.IO;

using Newtonsoft.Json;

namespace AttendanceTracker
{
    public class StudentFile
    {
        public static readonly string DEFAULT_STUDENT_FILE = Path.Combine(Settings.SETTINGS_FOLDER_PATH, "students.stu");

        private IDictionary<string, Student> _students = new Dictionary<string, Student>();

        public IDictionary<string, Student> Students => _students;

        [JsonConstructor]
        private StudentFile(IDictionary<string, Student> students)
        {
            _students = students ?? _students;
        }

        public static IDictionary<string, Student> ReadFromFile(string filePath)
        {
            StudentFile file = null;

            if (File.Exists(filePath))
            {
                file = File.ReadAllText(filePath).DecryptJson<StudentFile>();
            }

            return file?.Students;
        }

        public static void WriteToFile(IDictionary<string, Student> students, string filePath)
        {
            new StudentFile(students).WriteToFile(filePath);
        }

        public void WriteToFile(string filePath)
        {
            File.WriteAllText(filePath, this.EncryptJson());
        }
    }
}
