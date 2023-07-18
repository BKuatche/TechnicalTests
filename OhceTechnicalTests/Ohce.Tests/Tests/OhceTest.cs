using FluentAssertions;
using Moq;
using OhceApp.Adapters;
using OhceApp.Factory;
using OhceApp.Services;

namespace Ohce.Tests.Tests
{
    public class OhceTest
    {
        private readonly IGreeterFactory _greeterFactory;
        private readonly Mock<IGreeter> _greeter;
        private Mock<IPalindrome> _palindrome;
        private StringWriter _stringWriter;


        public OhceTest()
        {
            _greeterFactory = new GreeterFactory();
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
    }
}
