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
    }
}
