using System.Collections.Generic;
using System.IO;

namespace AttendanceTracker
{
    public static class StudentFile
    {
        public static readonly string DEFAULT_STUDENT_FILE = Path.Combine(Settings.SETTINGS_FOLDER_PATH, "students.stu");

        public static ICollection<Student> ReadFromFile(string filePath)
        {
            ICollection<Student> students = new List<Student>();

            if (File.Exists(filePath))
            {
                students = File.ReadAllText(filePath).DecryptJson<ICollection<Student>>();
            }

            return students;
        }

        public static void WriteToFile(IEnumerable<Student> students, string filePath)
        {
            File.WriteAllText(filePath, students.EncryptJson());
        }
    }
}
