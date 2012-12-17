using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

using GA.Core.Fitness;
using GA.Core.Chromosome;
using GA.Core.Util;
using GA.Core.Comparer;

namespace GA.Core.Selection
{
	/// <summary>
	/// Selekcja metodą koła ruletki.
	/// </summary>
    public class RouletteWheelSelectionStrategy : ISelectionStrategy
    {
        /// <summary>
        /// Wykorzystywany generator liczb losowych.
        /// </summary>
        private IRandomGenerator RandomGenerator
        {
            get;
            set;
        }

        /// <summary>
        /// Rozmiar populacji po selekcji.
        /// </summary>
        private ISelectionSizeStrategy PopulationSize
        {
            get;
            set;
        }

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="populationSize">Rozmiar populacji po selekcji.</param>
        /// <param name="randomGenerator">Wykorzystywany generator liczb losowych.</param>
        public RouletteWheelSelectionStrategy(ISelectionSizeStrategy populationSize, IRandomGenerator randomGenerator)
        {
            PopulationSize = populationSize;
            RandomGenerator = randomGenerator;
        }

        /// <summary>
        /// Realizuje algorytm selekcji.
        /// </summary>
        /// <param name="population">Populacja poddawana selekcji.</param>
        /// <returns>Zbiór osobników populacji, wybranych w wyniku selekcji do następnej generacji.</returns>
        public IChromosome[] Select(IChromosome[] population)
        {
            if (population.Length < 2)
            {
                return population;
            }

            IChromosome[] subpopulation = population.Where(ch => ch.Evaluate() > 0).ToArray();
            Double totalFitness = subpopulation.Sum(ch => ch.Evaluate());

            Int32 newPopulationSize = (Int32)PopulationSize.ComputeSize(subpopulation);
            IChromosome[] result = new IChromosome[newPopulationSize];

            for (Int32 i = 0; i < newPopulationSize; i++)
            {
                Double ptr = RandomGenerator.NextDouble();
                Double sum = 0.0;
                for (Int32 j = 0; j < subpopulation.Length; ++j)
                {
                    sum += subpopulation[j].Evaluate() / totalFitness;
                    if (sum > ptr)
                    {
                        result[i] = subpopulation[j];
                        break;
                    }
                }
            }
            return result;
        }
    }
}
