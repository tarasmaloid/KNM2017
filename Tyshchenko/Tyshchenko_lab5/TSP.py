#! /usr/bin/env python3


from random import random
from math import sqrt

from pygene3.gene import FloatGene, FloatGeneMax, FloatGeneRandom
from pygene3.organism import Organism, MendelOrganism
from pygene3.population import Population
import matplotlib.pyplot as plt

width = 500
height = 500


numCities = 30



geneRandMin = 0.0
geneRandMax = 500.0
geneMutProb = 0.5
geneMutAmt = 0.8         

popInitSize = 10
popChildCull = 15
popChildCount = 100
popIncest = 10           
popNumMutants = 0.7     
popNumRandomOrganisms = 0  

mutateOneOnly = True


BaseGeneClass = FloatGeneMax


OrganismClass = MendelOrganism


mutateAfterMating = False

crossoverRate = 0.15

class CityPriorityGene(BaseGeneClass):
    
    randMin = geneRandMin
    randMax = geneRandMax

    mutProb = geneMutProb
    mutAmt = geneMutAmt

class City:
    
    def __init__(self, name, x=None, y=None):
        
        
        self.name = name

        if x == None:
            x = random() * (width - 100) + 50
        if y == None:
            y = random() * (height - 100) + 50

        self.x = x
        self.y = y

    def __sub__(self, other):
        
        dx = self.x - other.x
        dy = self.y - other.y
        return sqrt(dx * dx + dy * dy)

    def __repr__(self):
        return "<City %s at (%.2f, %.2f)>" % (self.name, self.x, self.y)



cities = []
for i in range(numCities):
    cities.append(City("%s" % i))

cityNames = [city.name for city in cities]

cityCount = len(cities)

cityDict = {}
for city in cities:
    cityDict[city.name] = city

priInterval = (geneRandMax - geneRandMin) / cityCount
priNormal = []
for i in range(cityCount):
    priNormal.append(((i+0.25)*priInterval, (i+0.75)*priInterval))

genome = {}
for name in cityNames:
    genome[name] = CityPriorityGene

class TSPSolution(OrganismClass):
    
    genome = genome

    mutateOneOnly = mutateOneOnly

    crossoverRate = crossoverRate

    numMutants = 0.5

    def fitness(self):
        """
        return the journey distance
        """
        distance = 0.0

        
        sortedCities = self.getCitiesInOrder()

        
        for i in range(cityCount - 1):
            distance += sortedCities[i] - sortedCities[i+1]

        
        distance += sortedCities[0] - sortedCities[-1]

        
        return distance

    def getCitiesInOrder(self):
        
        sorter = [(self[name], cityDict[name]) for name in cityNames]

        
        sorter.sort()

        
        sortedCities = [tup[1] for tup in sorter]

        
        return sortedCities

    def normalise(self):
        """
        modifies the genes to a reasonably even spacing
        """
        genes = self.genes
        for i in range(2):
            sorter = [(genes[name][i], name) for name in cityNames]
            sorter.sort()
            sortedGenes = [tup[1] for tup in sorter]




class TSPSolutionPopulation(Population):

    initPopulation = popInitSize
    species = TSPSolution

    
    childCull = popChildCull

    
    childCount = popChildCount

    
    incest = popIncest

    mutants = popNumMutants

    numNewOrganisms = popNumRandomOrganisms

    mutateAfterMating = mutateAfterMating

def main():
    from time import time
    s = time()
    
    pop = TSPSolutionPopulation()

    
    i = 0
    c = 0
    l = 0
    while True:
        ff = pop.best().get_fitness()
        if ff != l:
            print("gen=%s best=%s avg=%s" % (i, ff, pop.fitness()))
            l = ff
        pop.gen()
        i += 1
        if i % 100 == 0:
            if c == ff:
                break
            else:
                c = ff


    
    solution = pop.best()

    
    sortedCities = solution.getCitiesInOrder()
    time_s = time() - s
    print("Best solution: total distance %04.2f in %.3f seconds:" % (
        solution.fitness(), time_s))
    x, y = [], []
    for city in sortedCities:
        print("  x=%03.2f y=%03.2f %s" % (city.x, city.y, city.name))
        x.append(city.x)
        y.append(city.y)
        plt.plot(city.x, city.y, 'ro')
        plt.annotate(city.name, xy=(city.x, city.y))
    x.append(x[0])
    y.append(y[0])
    plt.plot(x, y, 'b-')
    plt.title("Best solution: total distance %04.2f in %.3f seconds, iteration: %d:" % (solution.fitness(), time_s, i))
    plt.show()

if __name__ == '__main__':
    main()
