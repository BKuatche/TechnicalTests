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
            throw new NotImplementedException();
        }
    }
}
