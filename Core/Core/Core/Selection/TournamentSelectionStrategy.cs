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
    public class TournamentSelectionStrategy : ISelectionStrategy
    {
        private IComparer<IChromosome> comparer = new ReverseComparator();

        private ISelectionSizeStrategy TournamentGroupSize
        {
            get;
            set;
        }
        public TournamentSelectionStrategy(ISelectionSizeStrategy tournamentGroupSize)
        {
            TournamentGroupSize = tournamentGroupSize;
        }
        public IChromosome[] Select(IChromosome[] population)
        {
            if (population.Length < 2)
            {
                return population;
            }

            UInt32 size = TournamentGroupSize.ComputeSize(population);

            var leaders = Enumerable.Range(0, population.Length - 1).Where(i => i % size == 0).ToArray();

            IChromosome[] result = new IChromosome[(population.Length / size)];
            Parallel.For(0, leaders.Length - 1, i =>
                {
                    Array.Sort(population, leaders[i], (Int32)size, comparer);
                    result[i] = population[leaders[i]];
                });

            Array.Sort(population, leaders.Last(), population.Length - leaders.Last(), comparer);
            result[result.Length - 1] = population[leaders.Last()];

            return result;
        }
    }
}
