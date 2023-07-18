using FluentAssertions;
using Moq;
using OhceApp.Adapters;
using OhceApp.Factory;
using OhceApp.Services;

namespace Ohce.Tests.Tests
{
    public class OhceTest
    {
        private readonly Mock<IGreeter> _greeter;
        private Mock<IPalindrome> _palindrome;
        private StringWriter _stringWriter;


        public OhceTest()
        {
            _greeter = new Mock<IGreeter>();
            _palindrome = new Mock<IPalindrome>();
            _stringWriter = new StringWriter();
        }


        [Theory]
        [InlineData("Kilo", 6, "¡Buenos días Kilo!\r\n!potS\r\nAdios Kilo\r\n", "Stop!")]
        public void GivenTimePeriod_WhenUserGreetAndStop_ThenCorrectResultShoulbBeDisplayed(string userName, int hour, string expectedResult, string stop)
        {
            //arrange
            _greeter.Setup(s => s.GetHour()).Returns(hour);
            _palindrome.Setup(s => s.Content()).Returns(userName);
            var ohce = new OhceService(stop, _greeter.Object.GetHour());


            // Act
            Console.SetOut(_stringWriter);
            ohce.RunApp(userName, stop);
            var actualResult = _stringWriter.ToString();

            //Assert
            expectedResult.Should().Be(actualResult);
        }


        [Theory]
        [InlineData("oto", 17, "¡Buenas tardes oto!\r\noto\n¡Bonita palabra!\r\n", null)]
        [InlineData("oto", 17, "¡Buenas tardes oto!\r\noto\n¡Bonita palabra!\r\nAdios oto\r\n", "Stop!")]
        public void GivenTimePeriod_WhenReversesPhrasesWithPalindrome_ThenCorrectResultShoulbBeDisplayed(string userName, int hour, string expected, string stop)
        {
            //arrange
            _greeter.Setup(s => s.GetHour()).Returns(hour);
            _palindrome.Setup(s => s.Content()).Returns(userName);
            var ohce = new OhceService(userName, _greeter.Object.GetHour());


            // Act
            Console.SetOut(_stringWriter);
            ohce.RunApp(userName, stop);
            var actualResult = _stringWriter.ToString();


            //Assert
            expected.Should().Be(actualResult);
        }
    }
}
