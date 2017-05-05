#! /usr/bin/env python3



from pygene3.gene import FloatGene, FloatGeneMax
from pygene3.organism import Organism, MendelOrganism
from pygene3.population import Population
import matplotlib.pyplot as plt
import numpy as np


a = 12
b = -8
c = -40
d = 3

RANDMIN = -10.0
RANDMAX = 53.0

class XGene(FloatGene):
    randMin = RANDMIN
    randMax = RANDMAX

   
    mutProb = 0.2

    
    mutAmt = 0.8


def func(x):
    return a + b * x + c * x ** 2 + d * x ** 3


class QuadraticSolver(Organism):
    genome = {'max': XGene, 'min': XGene}

    def fitness(self):
        '''
        try to minimize fitmess function
        :return:
        '''
        x_max = self['max']
        x_min = self['min']

        max_y = func(x_max)     
        min_y = func(x_min)     
        return min_y - max_y

    def __repr__(self):
        return "<fitness=%f x1=%s x2=%s>" % (
            self.fitness(), self['x1'], self['x2'])


class QPopulation(Population):
    species = QuadraticSolver
    initPopulation = 2

    
    childCull = 10

    
    childCount = 25


pop = QPopulation()


def main():
    x_max, x_min = 0, 0
    xs_min = []
    xs_max = []
    try:
        generations = 100
        for i in range(generations):
            
            pop.gen()
            best = pop.organisms[0]
            print("fitness=%f x1=%f x2=%f" % (best.get_fitness(), best['max'], best['min']))
            xs_min.append(best['min'])
            xs_max.append(best['max'])
            x_max = best['max']
            x_min = best['min']
    except KeyboardInterrupt:
        pass
    print("Executed", generations, "generations")

    res_x = [x for x in np.arange(RANDMIN, RANDMAX, 0.01)]
    res_y = [func(x) for x in res_x]
    plt.title('Function with GA MAX & MIN')
    plt.plot(res_x, res_y, 'b-')
    plt.plot(x_max, func(x_max), 'ro')
    plt.annotate('max', xy=(x_max, func(x_max)))
    plt.plot(x_min, func(x_min), 'ro')
    plt.annotate('min', xy=(x_min, func(x_min)))
    plt.xlabel('x')
    plt.ylabel('y')
    plt.show()

    plt.title("GA MAX various")
    xs_max = sorted(xs_max)
    t = [t for t in range(len(xs_max))]
    plt.plot(t, xs_max, 'b-')
    plt.xlabel('Generation')
    plt.ylabel('X')
    plt.show()

    plt.title("GA MIN various")
    xs_min = sorted(xs_min, reverse=True)
    t = [t for t in range(len(xs_min))]
    plt.plot(t, xs_min, 'b-')
    plt.xlabel('Generation')
    plt.ylabel('X')
    plt.show()

if __name__ == '__main__':
    main()