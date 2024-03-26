namespace TDD_Time
{
    public struct Time
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        public Time(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        // �verskriver Equals-metoden f�r att j�mf�ra tv� Time-objekt s� att det inte blir n�gra varningar i Visual Studio
        public override bool Equals(object? obj)
        {
            if (obj is Time)
            {
                Time other = (Time)obj;
                return Hours == other.Hours && Minutes == other.Minutes && Seconds == other.Seconds;
            }
            return false;
        }

        // �verskriver GetHashCode-metoden f�r att generera en hashkod f�r Time-objektet s� att det inte blir n�gra varningar i Visual Studio
        public override int GetHashCode()
        {
            return Hours.GetHashCode() ^ Minutes.GetHashCode() ^ Seconds.GetHashCode();
        }

        
        public static bool operator >(Time t1, Time t2)
        {
            return t1.Hours > t2.Hours || (t1.Hours == t2.Hours && t1.Minutes > t2.Minutes) || (t1.Hours == t2.Hours && t1.Minutes == t2.Minutes && t1.Seconds > t2.Seconds);
        }

        public static bool operator <(Time t1, Time t2)
        {
            return t1.Hours < t2.Hours || (t1.Hours == t2.Hours && t1.Minutes < t2.Minutes) || (t1.Hours == t2.Hours && t1.Minutes == t2.Minutes && t1.Seconds < t2.Seconds);
        }

        
        public static bool operator ==(Time t1, Time t2)
        {
            return t1.Hours == t2.Hours && t1.Minutes == t2.Minutes && t1.Seconds == t2.Seconds;
        }

        
        public static bool operator !=(Time t1, Time t2)
        {
            return !(t1 == t2);
        }

        
        public static Time operator ++(Time t)
        {
            return t + 1;
        }

        
        public static Time operator --(Time t)
        {
            return t - 1;
        }

        
        public static Time operator +(Time t, int seconds)
        {
            int newSeconds = t.Seconds + seconds;
            int newMinutes = t.Minutes + newSeconds / 60;
            int newHours = t.Hours + newMinutes / 60;

            newSeconds %= 60;
            newMinutes %= 60;
            newHours %= 24;

            return new Time(newHours, newMinutes, newSeconds);
        }

        
        public static Time operator -(Time t, int seconds)
        {
            int newSeconds = t.Seconds - seconds;
            int newMinutes = t.Minutes;
            int newHours = t.Hours;

            while (newSeconds < 0)
            {
                newSeconds += 60;
                newMinutes--;
            }

            while (newMinutes < 0)
            {
                newMinutes += 60;
                newHours--;
            }

            while (newHours < 0)
            {
                newHours += 24;
            }

            return new Time(newHours, newMinutes, newSeconds);
        }

        
        public static void IsValid(Time time)
        {
            if (time.Hours < 0 || time.Hours > 23 || time.Minutes < 0 || time.Minutes > 59 || time.Seconds < 0 || time.Seconds > 59)
            {
                throw new ArgumentOutOfRangeException("Time is out of range");
            }
        }

        
        public string ToString(bool format)
        {
            if (format)
            {
                // Returnerar tiden i formatet HH:MM:SS
                return $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}";
            }
            else
            {
                // Returnerar tiden i formatet HH:MM:SS AM/PM
                string amPmDesignator = (Hours < 12) ? "am" : "pm";
                int displayHours = (Hours == 0 || Hours == 12) ? 12 : Hours % 12;
                return $"{displayHours:D2}:{Minutes:D2}:{Seconds:D2} {amPmDesignator}";
            }
        }

        
        public bool IsAm()
        {
            return Hours < 12;
        }
    }
}
