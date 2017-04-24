using System;

namespace TravelingSalesman
{
    public class City
    {
        int x, y;

        static Random rand = new Random();

        public City()
        {
            x = rand.Next(0, 301);
            y = rand.Next(0, 301);
        }

        public City(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

        public double distanceTo(City city)
        {
            int xDistance = Math.Abs(getX() - city.getX());
            int yDistance = Math.Abs(getY() - city.getY());
            double distance = Math.Sqrt((xDistance * xDistance) + (yDistance * yDistance));

            return distance;
        }

        public override string ToString()
        {
            return getX() + ", " + getY();
        }
    }
}
