using AOC24.Days;

namespace Tests
{
    public class AOC24
    {
        [Fact]
        public void Day1()
        {
            var day = new Day1();
            var enumerable = day.Execute();
#if DEBUG
            Assert.Equal(11, enumerable.First());
            Assert.Equal(31, enumerable.Last());
#else
            Assert.Equal(1530215, enumerable.First());
            Assert.Equal(26800609, enumerable.Last());
#endif
        }

        [Fact]
        public void Day2()
        {
            var day = new Day2();
            var enumerable = day.Execute();
#if DEBUG
            Assert.Equal(2, enumerable.First());
            Assert.Equal(4, enumerable.Last());
#else
            Assert.Equal(407, enumerable.First());
            Assert.Equal(459, enumerable.Last());
#endif
        }

        [Fact]
        public void Day3()
        {
            var day = new Day3();
            var enumerable = day.Execute();
#if DEBUG
            Assert.Equal(161, enumerable.First());
            Assert.Equal(48, enumerable.Last());
#else
            Assert.Equal(175615763, enumerable.First());
            Assert.Equal(74361272, enumerable.Last());
#endif
        }

        [Fact]
        public void Day4()
        {
            var day = new Day4();
            var enumerable = day.Execute();
#if DEBUG
            Assert.Equal(18, enumerable.First());
            //Assert.Equal(48, enumerable.Last());
#else
            Assert.Equal(2644, enumerable.First());
            //Assert.Equal(74361272, enumerable.Last());
#endif
        }
    }
}