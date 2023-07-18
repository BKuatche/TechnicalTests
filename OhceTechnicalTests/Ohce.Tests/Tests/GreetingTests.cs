using FluentAssertions;
using Moq;
using OhceApp.Adapters;
using OhceApp.Factory;

namespace Ohce.Tests.Tests
{
    public class GreetingTests
    {
        private readonly Mock<IGreeterFactory> _greeterFactory;
        private readonly Mock<IGreeter> _greeter;


        public GreetingTests()
        {
            _greeterFactory = new Mock<IGreeterFactory>();
            _greeter = new Mock<IGreeter>();
        }


        [Theory]
        [InlineData("Jack", 6, "¡Buenos días Jack!")]
        public void GivenMorningTime_WhenUserGreet_ThenCorrectGreetingFormat(string userName, int hour, string expectedGreetingFormat)
        {
            // Arrange
            _greeter.Setup(s => s.GetHour()).Returns(hour);
            var greeterInstance = new Greeter(_greeterFactory.Object, _greeter.Object.GetHour());

            //Action
            var actualGreetingFormat = greeterInstance.GetGreetingFor(userName);

            //assert
            actualGreetingFormat.Should().Be(expectedGreetingFormat);
        }
    }
}
