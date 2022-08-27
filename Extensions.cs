using System;
using System.ComponentModel;
using System.Text;

using Newtonsoft.Json;

namespace AttendanceTracker
{
    public static class Extensions
    {
        public static string Encrypt<T>(this T toEncrypt)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(toEncrypt)));
        }

        public static T Decrypt<T>(this string toDecrypt)
        {
            return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(Convert.FromBase64String(toDecrypt)));
        }
    }
}
