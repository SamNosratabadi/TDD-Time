namespace TDD_Time
{
    public struct Time
    {
        // Maximala värden för timmar, minuter och sekunder
        public const int MaxHours = 23;
        public const int MaxMinutes = 59;
        public const int MaxSeconds = 59;

        // Antal sekunder i en minut och antal minuter i en timme
        public const int SecondsInMinute = 60;
        public const int MinutesInHour = 60;

        // Designatorer för AM och PM
        public const string AmDesignator = "am";
        public const string PmDesignator = "pm";

        // Egenskaper för timmar, minuter och sekunder
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        // Konstruktor för att skapa en ny instans av Time
        public Time(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        // Överskriver Equals-metoden för att jämföra två Time-objekt så att det inte blir några varningar i Visual Studio
        public override bool Equals(object? obj)
        {
            if (obj is Time)
            {
                Time other = (Time)obj;
                return Hours == other.Hours && Minutes == other.Minutes && Seconds == other.Seconds;
            }
            return false;
        }

        // Överskriver GetHashCode-metoden för att generera en hashkod för Time-objektet så att det inte blir några varningar i Visual Studio
        public override int GetHashCode()
        {
            return Hours.GetHashCode() ^ Minutes.GetHashCode() ^ Seconds.GetHashCode();
        }

        // Överlagrade operatorer för att jämföra två Time-objekt
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

        // Överlagrade operatorer för att öka och minska tiden med ett visst antal sekunder
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
            int newMinutes = t.Minutes + newSeconds / SecondsInMinute;
            int newHours = t.Hours + newMinutes / MinutesInHour;

            newSeconds %= SecondsInMinute;
            newMinutes %= MinutesInHour;
            newHours %= MaxHours + 1;

            return new Time(newHours, newMinutes, newSeconds);
        }

        public static Time operator -(Time t, int seconds)
        {
            int newSeconds = t.Seconds - seconds;
            int newMinutes = t.Minutes;
            int newHours = t.Hours;

            while (newSeconds < 0)
            {
                newSeconds += SecondsInMinute;
                newMinutes--;
            }

            while (newMinutes < 0)
            {
                newMinutes += MinutesInHour;
                newHours--;
            }

            while (newHours < 0)
            {
                newHours += MaxHours + 1;
            }

            return new Time(newHours, newMinutes, newSeconds);
        }

        // Metod för att kontrollera om en tid är giltig
        public static void IsValid(Time time)
        {
            if (time.Hours < 0 || time.Hours > MaxHours || time.Minutes < 0 || time.Minutes > MaxMinutes || time.Seconds < 0 || time.Seconds > MaxSeconds)
            {
                throw new ArgumentOutOfRangeException(nameof(time),"Time is out of range");
            }
        }

        // Överskrid ToString-metoden för att formatera tiden som en sträng
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
                string amPmDesignator = (Hours < 12) ? AmDesignator : PmDesignator;
                int displayHours = (Hours == 0 || Hours == 12) ? 12 : Hours % 12;
                return $"{displayHours:D2}:{Minutes:D2}:{Seconds:D2} {amPmDesignator}";
            }
        }

        // Metod för att kontrollera om tiden är AM eller PM
        public bool IsAm()
        {
            return Hours < 12;
        }
    }
}
