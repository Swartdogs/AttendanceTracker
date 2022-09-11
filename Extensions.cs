using System;
using System.Text;

using Newtonsoft.Json;

namespace AttendanceTracker
{
    public static class Extensions
    {
        public static string EncryptJson<T>(this T toEncrypt)
        {
            return JsonConvert.SerializeObject(toEncrypt).Encrypt();
        }

        public static string Encrypt(this string toEncrypt)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(toEncrypt));
        }

        public static T DecryptJson<T>(this string toDecrypt)
        {
            return JsonConvert.DeserializeObject<T>(toDecrypt.Decrypt());
        }

        public static string Decrypt(this string toDecrypt)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(toDecrypt));
        }
    }
}
