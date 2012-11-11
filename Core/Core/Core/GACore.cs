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
using GA.Core.Stop;

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
                { INF,   2.0,    4.0,   22.0,    2.0,    INF},
                { 2.0,   INF,    8.0,   15.0,   13.0,   10.0},
                { 4.0,   8.0,    INF,    5.0,    2.0,    INF},
                {22.0,  15.0,    5.0,    INF,   11.0,   12.0},
                { 2.0,  13.0,    2.0,   11.0,    INF,   14.0},
                { INF,  10.0,    INF,   12.0,   14.0,    INF},
            };

            // create prototype chromosome
            PermutationChromosome prototype = new PermutationChromosome(0, costMatrix.GetLength(0) - 1);

            // set prototype's parameters
            prototype.CrossOverStrategy = new PermutationChromosome.CycleCrossOverStrategy();
            prototype.RandomGenerator = new ThreadSafeRandomGenerator();
            prototype.MutationStrategy = new PermutationChromosome.InsertMutationStrategy();
            prototype.Fitness = new TSPFitness(costMatrix);

            // stop condition, keep reference for selecting the leader
            NoChangeStopCondion stopCondition = new NoChangeStopCondion(10);

            // create population
            DefaultPopulation population = new DefaultPopulation(prototype, 40);

            // set population's parameters
            population.SelectionStrategy
                = new StochasticUniversalSamplingStrategy(new FixedSizeStrategy(40), new ThreadSafeRandomGenerator());
            population.RandomGenerator = new ThreadSafeRandomGenerator();
            population.StopCondition = stopCondition;

            // perform util the stop condition returns false
            while (population.NextGeneration())
                ;

            // print the result
            System.Console.WriteLine("Best fitness: " + (1.0 / stopCondition.Leader.Evaluate()));
            System.Console.WriteLine(stopCondition.Leader.ToString());
            System.Console.ReadKey();
        }
    }
}
