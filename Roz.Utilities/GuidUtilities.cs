using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roz.Utilities
{
    public class GuidUtilities
    {
        public static Guid NewGuidComb()
        {
            byte[] b = Guid.NewGuid().ToByteArray();
            DateTime dateTime = new DateTime(1900, 1, 1);
            DateTime now = DateTime.Now;
            TimeSpan timeSpan = new TimeSpan(now.Ticks - dateTime.Ticks);
            TimeSpan timeOfDay = now.TimeOfDay;
            byte[] bytes1 = BitConverter.GetBytes(timeSpan.Days);
            byte[] bytes2 = BitConverter.GetBytes((long)(timeOfDay.TotalMilliseconds / 3.333333));
            Array.Reverse((Array)bytes1);
            Array.Reverse((Array)bytes2);
            Array.Copy((Array)bytes1, bytes1.Length - 2, (Array)b, b.Length - 6, 2);
            Array.Copy((Array)bytes2, bytes2.Length - 4, (Array)b, b.Length - 4, 4);
            return new Guid(b);
        }

        public static string NewGuidCombString(string format = "D")
        {
            return NewGuidComb().ToString(format);
        }
    }
}
