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
        [InlineData(" ")]
        public void GivenEmptyContent_WhenProcess_ReturnEmpty(string content)
        {
            // Arrage
            _palindrome.Setup(s => s.Content()).Returns(content);
            var palindrome = new Palindrome(_palindrome.Object.Content());


            // Action
            var actualContent = palindrome.Execute();

            // assert
            content.Should().Be(actualContent);
        }


        [Theory]
        [InlineData("hola", "aloh")]
        public void GivenNonPalindrome_WhenProcess_ReturnContentWithoutPalindrone(string content, string expectedResult)
        {
            // Arrage
            _palindrome.Setup(s => s.Content()).Returns(content);
            var palindrome = new Palindrome(_palindrome.Object.Content());


            // Action
            var actualContent = palindrome.Execute();

            // assert
            actualContent.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("oto", "oto\n¡Bonita palabra!")]
        public void GivenPalindrome_WhenProcess_ReturnCondentPlusPalindrome(string content, string expectedResult)
        {
            // Arrage
            _palindrome.Setup(s => s.Content()).Returns(content);
            var palindrome = new Palindrome(_palindrome.Object.Content());


            // Action
            var actualContent = palindrome.Execute();

            // assert
            actualContent.Should().Be(expectedResult);
        }
    }
}
