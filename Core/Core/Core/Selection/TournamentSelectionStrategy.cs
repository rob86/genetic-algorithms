using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GA.Core.Fitness;
using GA.Core.Chromosome;
using GA.Core.Util;
using GA.Core.Comparer;

namespace GA.Core.Selection
{
	/// <summary>
	/// Selekcja turniejowa.
	/// </summary>
    public class TournamentSelectionStrategy : ISelectionStrategy
    {
        private IComparer<IChromosome> comparer = new FitnessReverseComparer();

        /// <summary>
        /// Wykorzystywany generator liczb losowych.
        /// </summary>
        private IRandomGenerator RandomGenerator
        {
            get;
            set;
        }

        /// <summary>
        /// Rozmiar grupy turniejowej.
        /// </summary>
        private ISelectionSizeStrategy TournamentSize
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
        /// <param name="tournamentSize">Rozmiar grupy turniejowej.</param>
        /// <param name="randomGenerator">Wykorzystywany generator liczb losowych.</param>
        public TournamentSelectionStrategy(ISelectionSizeStrategy populationSize, ISelectionSizeStrategy tournamentSize, IRandomGenerator randomGenerator)
        {
            TournamentSize = tournamentSize;
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

            UInt32 tournamenSize = TournamentSize.ComputeSize(population);
            UInt32 populationSize = PopulationSize.ComputeSize(population);

            IChromosome[] result = new IChromosome[populationSize];
            Parallel.For(0, populationSize, i =>
                {
                    IChromosome[] group = new IChromosome[tournamenSize];
                    for (Int32 j = 0; j < tournamenSize; ++j)
                    {
                        group[j] = population[RandomGenerator.Next(0, population.Length)];
                    }
                    Array.Sort(group, comparer);
                    result[i] = group.First();
                });

            return result;
        }
    }
}
