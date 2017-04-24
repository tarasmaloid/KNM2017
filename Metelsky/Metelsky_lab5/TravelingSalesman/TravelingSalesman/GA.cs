using System;

namespace TravelingSalesman
{
    public class GA
    {
        private static double mutationRate = 0.015;
        private static int tournamentSize = 5;
        private static bool elitism = true;

    public static Population evolvePopulation(Population pop)
        {
            Population newPopulation = new Population(pop.populationSize(), false);

            int elitismOffset = 0;
            if (elitism)
            {
                newPopulation.saveTour(0, pop.getFittest());
                elitismOffset = 1;
            }

            for (int i = elitismOffset; i < newPopulation.populationSize(); i++)
            {
                Tour parent1 = tournamentSelection(pop);
                Tour parent2 = tournamentSelection(pop);

                Tour child = crossover(parent1, parent2);
                newPopulation.saveTour(i, child);
            }

            for (int i = elitismOffset; i < newPopulation.populationSize(); i++)
            {
                mutate(newPopulation.getTour(i));
            }

            return newPopulation;
        }

        public static Tour crossover(Tour parent1, Tour parent2)
        {
            Tour child = new Tour();

            int startPos = new Random().Next(0, 2) * parent1.tourSize(),
                endPos = new Random().Next(0, 2) * parent1.tourSize();

            for (int i = 0; i < child.tourSize(); i++)
            {
                if (startPos < endPos && i > startPos && i < endPos)
                {
                    child.setCity(i, parent1.getCity(i));
                } 
                else if (startPos > endPos)
                {
                    if (!(i < startPos && i > endPos))
                    {
                        child.setCity(i, parent1.getCity(i));
                    }
                }
            }

            for (int i = 0; i < parent2.tourSize(); i++)
            {
                if (!child.containsCity(parent2.getCity(i)))
                {
                    for (int ii = 0; ii < child.tourSize(); ii++)
                    {
                        if (child.getCity(ii) == null)
                        {
                            child.setCity(ii, parent2.getCity(i));
                            break;
                        }
                    }
                }
            }
            return child;
        }

        private static void mutate(Tour tour)
        {
            for (int tourPos1 = 0; tourPos1 < tour.tourSize(); tourPos1++)
            {
                if (new Random().Next(0, 2) < mutationRate)
                {
                    int tourPos2 = new Random().Next(0, tour.tourSize());
                    City city1 = tour.getCity(tourPos1);
                    City city2 = tour.getCity(tourPos2);

                    tour.setCity(tourPos2, city1);
                    tour.setCity(tourPos1, city2);
                }
            }
        }

        private static Tour tournamentSelection(Population pop)
        {
            Population tournament = new Population(tournamentSize, false);

            for (int i = 0; i < tournamentSize; i++)
            {
                int randomId = new Random().Next(0, pop.populationSize());
                tournament.saveTour(i, pop.getTour(randomId));
            }

            Tour fittest = tournament.getFittest();
            return fittest;
        }
    }
}
