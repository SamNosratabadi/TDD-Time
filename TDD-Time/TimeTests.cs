namespace TDD_Time
{

    public class TimeTests
    {
        [Theory]
        [InlineData(0, 0, 0, true, "00:00:00")]
        [InlineData(1, 2, 3, true, "01:02:03")]
        [InlineData(12, 0, 0, false, "12:00:00 AM")]
        [InlineData(23, 59, 59, false, "11:59:59 PM")]
        [InlineData(24, 0, 0,false, "12:00:00 PM")]
        public void Time_CanNotExceedLimits(int hours, int minutes, int seconds, bool format, string expected)
        {
            var result = Time.ToString(hours, minutes, seconds, format);
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
            Assert.Throws<ArgumentOutOfRangeException>(() => Time.IsValid(hours, minutes, seconds));
        }
        [Theory]
        [InlineData(0, true)]
        [InlineData(1, true)]
        [InlineData(12, false)]
        [InlineData(13, false)]
        public void Time_CanFormatTime(int hours, bool expected)
        {
            var result = Time.IsAm(hours);
            Assert.Equal(expected, result);
        }
    }

}
