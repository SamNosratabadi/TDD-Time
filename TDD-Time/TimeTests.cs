namespace TDD_Time
{
    public class TimeTests
    {
        [Theory]
        [InlineData(0, 0, 0, true, "00:00:00")]
        [InlineData(1, 2, 3, true, "01:02:03")]
        [InlineData(12, 0, 0, false, "12:00:00 pm")]
        [InlineData(23, 59, 59, false, "11:59:59 pm")]
        public void Time_CanNotExceedLimits(int hours, int minutes, int seconds, bool format, string expected)
        {
            var time = new Time(hours, minutes, seconds);
            var result = time.ToString(format);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-1, 0, 0)]
        [InlineData(0, -1, 0)]
        [InlineData(0, 0, -1)]
        [InlineData(24, 0, 0)]
        [InlineData(0, 60, 0)]
        public void Time_ThrowsExceptionWhenOutOfRange(int hours, int minutes, int seconds)
        {
            var time = new Time(hours, minutes, seconds);
            Assert.Throws<ArgumentOutOfRangeException>(() => Time.IsValid(time));
        }

        [Theory]
        [InlineData(0, true)]
        [InlineData(1, true)]
        [InlineData(12, false)]
        [InlineData(13, false)]
        public void Time_CheckForAM(int hours, bool expected)
        {
            var time = new Time(hours, 0, 0);
            var result = time.IsAm();
            Assert.Equal(expected, result);
        }
        [Theory]
        [InlineData(1, 30, 30, 5, 1, 30, 35)]
        [InlineData(12, 59, 59, 1, 13, 0, 0)]
        [InlineData(23, 59, 59, 1, 0, 0, 0)]
        [InlineData(0, 0, 0, 60, 0, 1, 0)]
        public void Time_PlusOperator(int hours, int minutes, int seconds, int value, int expectedHours, int expectedMinutes, int expectedSeconds)
        {
            var time = new Time(hours, minutes, seconds);
            var result = time + value;
            Assert.Equal(new Time(expectedHours, expectedMinutes, expectedSeconds), result);
        }

        [Theory]
        [InlineData(1, 30, 29, 1, 30, 30)]
        [InlineData(23, 59, 59, 0, 0, 0)]
        public void Time_PlusPlusOperator(int initialHours, int initialMinutes, int initialSeconds, int expectedHours, int expectedMinutes, int expectedSeconds)
        {
            var time = new Time(initialHours, initialMinutes, initialSeconds);
            time++;
            Assert.Equal(new Time(expectedHours, expectedMinutes, expectedSeconds), time);
        }

        [Theory]
        [InlineData(1, 30, 35, 5, 1, 30, 30)]
        [InlineData(13, 0, 0, 1, 12, 59, 59)]
        [InlineData(0, 0, 0, 1, 23, 59, 59)]
        public void Time_MinusOperator(int hours, int minutes, int seconds, int value, int expectedHours, int expectedMinutes, int expectedSeconds)
        {
            var time = new Time(hours, minutes, seconds);
            var result = time - value;
            Assert.Equal(new Time(expectedHours, expectedMinutes, expectedSeconds), result);
        }

        [Theory]
        [InlineData(1, 30, 30, 1, 30, 29)]
        [InlineData(0, 0, 0, 23, 59, 59)]
        public void Time_MinusMinusOperator(int initialHours, int initialMinutes, int initialSeconds, int expectedHours, int expectedMinutes, int expectedSeconds)
        {
            var time = new Time(initialHours, initialMinutes, initialSeconds);
            time--;
            Assert.Equal(new Time(expectedHours, expectedMinutes, expectedSeconds), time);
        }
        [Theory]
        [InlineData(0, 0, 10, 0, 1, 0, false)]
        [InlineData(0, 1, 0, 0, 0, 10, true)]
        public void Time_GreaterThanOperator(int hour1, int minute1, int second1, int hour2, int minute2, int second2, bool expected)
        {
            var time1 = new Time(hour1, minute1, second1);
            var time2 = new Time(hour2, minute2, second2);
            Assert.Equal(expected, time1 > time2);
        }

        [Theory]
        [InlineData(0, 0, 10, 0, 1, 0, true)]
        [InlineData(0, 0, 10, 0, 0, 10, false)]
        public void Time_NotEqualsOperator(int hour1, int minute1, int second1, int hour2, int minute2, int second2, bool expected)
        {
            var time1 = new Time(hour1, minute1, second1);
            var time2 = new Time(hour2, minute2, second2);
            Assert.Equal(expected, time1 != time2);
        }

        [Theory]
        [InlineData(0, 0, 10, 0, 0, 10, true)]
        [InlineData(0, 0, 10, 0, 1, 0, false)]
        public void Time_EqualsOperator(int hour1, int minute1, int second1, int hour2, int minute2, int second2, bool expected)
        {
            var time1 = new Time(hour1, minute1, second1);
            var time2 = new Time(hour2, minute2, second2);
            Assert.Equal(expected, time1 == time2);
        }

        [Theory]
        [InlineData(0, 0, 10, 0, 1, 0, true)]
        [InlineData(0, 1, 0, 0, 0, 10, false)]
        public void Time_LessThanOperator(int hour1, int minute1, int second1, int hour2, int minute2, int second2, bool expected)
        {
            var time1 = new Time(hour1, minute1, second1);
            var time2 = new Time(hour2, minute2, second2);
            Assert.Equal(expected, time1 < time2);
        }

    }
}
