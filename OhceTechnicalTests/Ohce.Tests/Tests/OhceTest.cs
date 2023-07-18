using FluentAssertions;
using Moq;
using OhceApp.Adapters;
using OhceApp.Services;

namespace Ohce.Tests.Tests
{
    public class OhceTest
    {
        private readonly Mock<IGreeter> _greeter;

        public OhceTest()
        {
            _greeter = new Mock<IGreeter>();
        }


        [Theory]
        [InlineData("ete", 6, "¡Buenos días ete!\r\nete\n¡Bonita palabra!\r\nAdios ete\r\n", "Stop!")]
        public void GivenTimePeriod_WhenUserGreetAndStop_ThenCorrectResultShoulbBeDisplayed(string userName, int hour, string expectedResult, string stop)
        {
            //arrange
            _greeter.Setup(s => s.GetHour()).Returns(hour);
            var ohce = new OhceService(userName, _greeter.Object.GetHour());


            // Act
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            ohce.RunApp(userName, stop);
            var actualResult = stringWriter.ToString();

            //Assert
            expectedResult.Should().Be(actualResult);

        }
    }
}
