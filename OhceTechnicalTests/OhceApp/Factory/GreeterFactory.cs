namespace OhceApp.Factory
{
    public class GreeterFactory : IGreeterFactory
    {
        private static bool IsMorningTime(int hour) => hour >= 6 && hour < 12;
        private static bool IsAfternoonTime(int hour) => hour >= 12 && hour < 20;

        public string At(int hour, string name)
        {
            if (IsMorningTime(hour))
            {
                return $"¡Buenos días {name}!";
            }
            else if (IsAfternoonTime(hour))
            {
                return $"¡Buenas tardes {name}!";
            }

            return $"¡Buenas noches {name}!";
        }
    }
}

