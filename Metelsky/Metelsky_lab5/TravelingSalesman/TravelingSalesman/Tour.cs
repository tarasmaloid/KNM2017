using System;
using System.Collections.Generic;

namespace TravelingSalesman
{
    public class Tour
    {
        private List<City> tour = new List<City>();

        private double fitness = 0;
        private double distance = 0;

        public Tour()
        {
            for (int i = 0; i < TourManager.numberOfCities(); i++)
            {
                tour.Add(null);
            }
        }

        public Tour(List<City> tour)
        {
            this.tour = tour;
        }

        public void generateIndividual()
        {
            for (int cityIndex = 0; cityIndex < TourManager.numberOfCities(); cityIndex++)
            {
                setCity(cityIndex, TourManager.getCity(cityIndex));
            }

            ShuffleCities(tour);
        }

        List<City> ShuffleCities(List<City> array)
        {
            Random r = new Random();

            for (int i = array.Count; i > 0; i--)
            {
                City firstCity = array[r.Next(i)],
                     secondCity = array[r.Next(i)],
                     temp = firstCity;

                firstCity = secondCity;
                secondCity = temp;
            }

            return array;
        }

        public City getCity(int tourPosition)
        {
            return tour[tourPosition];
        }

        public void setCity(int tourPosition, City city)
        {
            tour[tourPosition] = city;
            fitness = 0;
            distance = 0;
        }

        public double getFitness()
        {
            if (fitness == 0)
            {
                fitness = 1 / (double)getDistance();
            }
            return fitness;
        }

        public double getDistance()
        {
            if (distance == 0)
            {
                double tourDistance = 0;

                for (int cityIndex = 0; cityIndex < tourSize(); cityIndex++)
                {
                    City fromCity = getCity(cityIndex);
                    City destinationCity;
                    if (cityIndex + 1 < tourSize())
                    {
                        destinationCity = getCity(cityIndex + 1);
                    }
                    else
                    {
                        destinationCity = getCity(0);
                    }
                    tourDistance += fromCity.distanceTo(destinationCity);
                }
                distance = tourDistance;
            }
            return distance;
        }

        public int tourSize()
        {
            return tour.Count;
        }

        public bool containsCity(City city)
        {
            return tour.Contains(city);
        }
    }
}
