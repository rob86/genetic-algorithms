using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using GA.Core.Chromosome;
using GA.Core.Util;
using GA.Core.Population;
using GA.Core.Selection;
using GA.Core.Fitness;

namespace GA.Core
{
    public class GACore
    {
        public static void Main()
        {
            // define cost matrix

            Double INF = Double.PositiveInfinity;
            Double[,] costMatrix = new Double[,]
            {
                { INF,   2.0,    4.0,   22.0,    2.0,    0.0},
                { 2.0,   INF,    8.0,   15.0,   13.0,   10.0},
                { 4.0,   8.0,    INF,    5.0,    2.0,    0.0},
                {22.0,  15.0,    5.0,    INF,   11.0,   12.0},
                { 2.0,  13.0,    2.0,   11.0,    INF,   14.0},
                { 0.0,  10.0,    0.0,   12.0,   14.0,    INF},
            };

            // create prototype chromosome
            PermutationChromosome prototype = new PermutationChromosome(0, costMatrix.GetLength(0));

            // set prototype's parameters
            prototype.CrossOverStrategy = new PermutationChromosome.CycleCrossOverStrategy();
            prototype.RandomGenerator = new ThreadSafeRandomGenerator();
            prototype.MutationStrategy = new PermutationChromosome.InsertMutationStrategy();
            prototype.Fitness = new TSPFitness(costMatrix);

            // create population
            DefaultPopulation population = new DefaultPopulation(prototype, 30);

            // set population's parameters
            population.SelectionStrategy = new EliteSelectionStrategy(new ProportionalSizeStrategy(0.4));
            population.RandomGenerator = new ThreadSafeRandomGenerator();

            Double fitness = Double.MinValue;
            Int32 fitnessRepeats = 0;
            while (fitnessRepeats < 100)
            {
                population.NextGeneration();

                if (Math.Abs(fitness - population.BestFitness.Evaluate()) < 0.01)
                {
                    ++fitnessRepeats;
                }
                else
                {
                    fitnessRepeats = 0;
                }
                fitness = population.BestFitness.Evaluate();
            }
            System.Console.WriteLine("Best fitness: " + fitness);
            System.Console.WriteLine(population.BestFitness.ToString());
            System.Console.ReadKey();
        }
    }
}
