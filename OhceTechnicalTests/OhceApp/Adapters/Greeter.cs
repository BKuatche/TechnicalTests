using OhceApp.Factory;

namespace OhceApp.Adapters
{
    public class Greeter : IGreeter
    {
        private IGreeterFactory _greeterFactory;
        private int _hour;

        public Greeter(IGreeterFactory greeterFactory, int hour)
        {
            _greeterFactory = greeterFactory;
            _hour = hour;
        }


        public string GetGreetingFor(string userName)
        {
            try
            {
                var result = _greeterFactory.At(GetHour(), userName);

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetHour()
        {
            return _hour;
        }
    }
}
