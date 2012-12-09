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
	/*
	 * Selekcja turniejowa.
	 */
    public class TournamentSelectionStrategy : ISelectionStrategy
    {
        private IComparer<IChromosome> comparer = new FitnessReverseComparer();

		/*
		 * Generator liczb losowych.
		 */
        private IRandomGenerator RandomGenerator
        {
            get;
            set;
        }
		/*
		 * Liczba osobników wchodzących do pojedynczego turnieju.
		 */
        private ISelectionSizeStrategy TournamentSize
        {
            get;
            set;
        }
		/*
		 * Rozmiar populacji po selekcji.
		 */
        private ISelectionSizeStrategy PopulationSize
        {
            get;
            set;
        }
        public TournamentSelectionStrategy(ISelectionSizeStrategy populationSize, ISelectionSizeStrategy tournamentSize, IRandomGenerator randomGenerator)
        {
            TournamentSize = tournamentSize;
            PopulationSize = populationSize;
            RandomGenerator = randomGenerator;
        }
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
