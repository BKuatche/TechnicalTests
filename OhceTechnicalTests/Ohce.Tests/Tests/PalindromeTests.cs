using FluentAssertions;
using Moq;
using OhceApp.Adapters;

namespace Ohce.Tests.Tests
{
    public class PalindromeTests
    {
        private Mock<IPalindrome> _palindrome;

        public PalindromeTests()
        {
            _palindrome = new Mock<IPalindrome>();
        }


        [Theory]
        [InlineData("hola", "aloh")]
        public void GivenNonPalindrome_WhenProcess_ReturnContentWithoutPalindrone(string content, string expectedResult)
        {
            // Arrage
            _palindrome.Setup(s => s.Content()).Returns(content);


            // Action
            var actualContent = _palindrome.Object.Execute();

            // assert
            actualContent.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("oto", "oto\n¡Bonita palabra!")]
        public void GivenPalindrome_WhenProcess_ReturnCondentPlusPalindrome(string content, string expectedResult)
        {
            // Arrage
            _palindrome.Setup(s => s.Content()).Returns(content);


            // Action
            var actualContent = _palindrome.Object.Execute();

            // assert
            actualContent.Should().Be(expectedResult);
        }
    }
}
