namespace OhceApp.Adapters
{
    public class Palindrome : IPalindrome
    {
        private string _content;
        private const string PALINDROME_MESSAGE = "¡Bonita palabra!";

        public Palindrome(string content)
        {
            _content = content;
        }

        private bool IsPalindrome()
        {
            if (_content.Length < 2)
            {
                return false;
            }

            var reverse = ReverseContent();
            return reverse.Equals(_content);
        }

        public string Execute()
        {

            try
            {
                string? result = null;

                if (IsPalindrome())
                {
                    result = ReverseContent() + $"\n{PALINDROME_MESSAGE}";
                }
                else
                {
                    result = ReverseContent();
                }

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }


        private string ReverseContent()
        {
            char[] stringArray = _content.ToCharArray();
            Array.Reverse(stringArray);
            var reverse = new string(stringArray);
            return reverse;
        }

        public string Content()
        {
            return _content;
        }
    }
}
