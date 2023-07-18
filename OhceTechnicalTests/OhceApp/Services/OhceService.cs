using OhceApp.Adapters;
using OhceApp.Factory;

namespace OhceApp.Services
{
    public class OhceService
    {
        private IGreeter _greeter;
        private IPalindrome _palindrome;

        public OhceService(string content, int hour)
        {
            _greeter = new Greeter(new GreeterFactory(), hour);
            _palindrome = new Palindrome(content);
        }


        public void RunApp(string userName, string? stop = null)
        {
            try
            {
                GreetUser(userName);
                ReversePhrases();
                SayGoodByeToTheUser(userName, stop);
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void GreetUser(string username)
        {
            _greeter.GetGreetingFor(username);
        }

        private void ReversePhrases()
        {
            var result = _palindrome.Execute();
            Console.WriteLine(result);
        }

        private void SayGoodByeToTheUser(string userName, string? text)
        {
            if (!string.IsNullOrEmpty(text) && text.Equals("Stop!"))
            {
                Console.WriteLine($"Adios {userName}");
            }
        }
    }
}
