using OhceApp.Factory;

namespace OhceApp.Adapters
{
    public class Greeter : IGreeter
    {
        private readonly IGreeterFactory _greeterFactory;
        private readonly int _hour;
        public Greeter(IGreeterFactory greeterFactory, int hour)
        {
            _greeterFactory = greeterFactory;
            _hour = hour;
        }

        public string GetGreetingFor(string userName)
        {
            throw new NotImplementedException();
        }

        public int GetHour()
        {
            throw new NotImplementedException();
        }
    }
}
