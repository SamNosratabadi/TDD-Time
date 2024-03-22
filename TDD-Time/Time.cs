using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_Time
{
    internal class Time
    {
        public int Hour { get; private set; }
        public int Minute { get; private set; }
        public int Second { get; private set; }

        public Time(int hour, int minute, int second)
        {
            
        }


        //Måste kunna kolla om tiden är "valid" eller ej. Dvs om värdena för timmarna är mellan [0,23], minuter och sekunder är mellan[0, 59].
        public static void IsValid(int hour, int minute, int second)
        {
            if (hour < 0 || hour > 23 || minute < 0 || minute > 59 || second < 0 || second > 59)
            {
                throw new ArgumentOutOfRangeException("Time is out of range");
            }
        }
        public static string ToString(int hour, int minute, int second, bool format)
        {
            if (format)
            {
                return $"{hour:00}:{minute:00}:{second:00}";
            }
            else
            {
                if (hour > 12)
                {
                    return $"{hour - 12:00}:{minute:00}:{second:00} PM";
                }
                else
                {
                    return $"{hour:00}:{minute:00}:{second:00} AM";
                }
            }
        }

        public static bool IsAm(int hour) //Det skall vara möjligt att kolla om det är förmiddag eller eftermiddag.
        {
            if (hour < 12)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
