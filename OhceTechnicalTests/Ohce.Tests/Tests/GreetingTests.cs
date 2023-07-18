using FluentAssertions;
using Moq;
using OhceApp.Adapters;
using OhceApp.Factory;

namespace Ohce.Tests.Tests
{
    public class GreetingTests
    {
        private readonly IGreeterFactory _greeterFactory;
        private readonly Mock<IGreeter> _greeter;


        public GreetingTests()
        {
            _greeterFactory = new GreeterFactory();
            _greeter = new Mock<IGreeter>();
        }


        [Theory]
        [InlineData("Jack", 6, "¡Buenos días Jack!")]
        [InlineData("Renie", 11, "¡Buenos días Renie!")]
        [InlineData("Ali", 8, "¡Buenos días Ali!")]
        public void GivenMorning_WhenUserGreet_ThenCorrectGreetingFormat(string userName, int hour, string expectedGreetingFormat)
        {
            // Arrange
            _greeter.Setup(s => s.GetHour()).Returns(hour);
            var greeterInstance = new Greeter(_greeterFactory, _greeter.Object.GetHour());

            //Action
            var actualGreetingFormat = greeterInstance.GetGreetingFor(userName);

            //assert
            actualGreetingFormat.Should().Be(expectedGreetingFormat);
        }

        [Theory]
        [InlineData("Kelly", 12, "¡Buenas tardes Kelly!")]
        [InlineData("Sami", 14, "¡Buenas tardes Sami!")]
        [InlineData("Eddie", 19, "¡Buenas tardes Eddie!")]
        public void GivenAfternoon_WhenUserGreet_ThenCorrectGreetingFormat(string userName, int hour, string expectedGreetingFormat)
        {
            // Arrange
            _greeter.Setup(s => s.GetHour()).Returns(hour);
            var greeterInstance = new Greeter(_greeterFactory, _greeter.Object.GetHour());

            //Action
            var actualGreetingFormat = greeterInstance.GetGreetingFor(userName);

            //assert
            actualGreetingFormat.Should().Be(expectedGreetingFormat);
        }


        [Theory]
        [InlineData("Pedro", 20, "¡Buenas noches Pedro!")]
        [InlineData("Reo", 25, "¡Buenas noches Reo!")]
        [InlineData("Charlie", 5, "¡Buenas noches Charlie!")]
        public void GivenNight_WhenUserGreet_ThenCorrectGreetingFormat(string userName, int hour, string expectedGreetingFormat)
        {
            // Arrange
            _greeter.Setup(s => s.GetHour()).Returns(hour);
            var greeterInstance = new Greeter(_greeterFactory, _greeter.Object.GetHour());

            //Action
            var actualGreetingFormat = greeterInstance.GetGreetingFor(userName);

            //assert
            actualGreetingFormat.Should().Be(expectedGreetingFormat);
        }
    }
}
