using System.Collections.Generic;
using System.Linq;

namespace TravelingSalesman
{
    class TourManager
    {
        private static List<City> destinationCities = new List<City>();

        public static void addCity(City city)
        {
            destinationCities.Add(city);
        }

        public static City getCity(int index)
        {
            return destinationCities[index];
        }

        public static int numberOfCities()
        {
            return destinationCities.Count();
        }

        public static void clearCities()
        {
            destinationCities.Clear();
        }
    }
}
