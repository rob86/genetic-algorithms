using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GA.Core.Fitness;
using GA.Core.Chromosome;
using GA.Core.Util;
using GA.Core.Comparer;

namespace GA.Core.Selection
{
    public class EliteSelectionStrategyAdapter : ISelectionStrategy
    {
        private IComparer<IChromosome> comparer = new FitnessReverseComparer();

        private ISelectionSizeStrategy EliteSize
        {
            get;
            set;
        }
        private ISelectionStrategy AdaptedStrategy
        {
            get;
            set;
        }
        public EliteSelectionStrategyAdapter(ISelectionStrategy adaptedStrategy, ISelectionSizeStrategy eliteSize)
        {
            AdaptedStrategy = adaptedStrategy;
            EliteSize = eliteSize;
        }
        public IChromosome[] Select(IChromosome[] population)
        {
            UInt32 size = EliteSize.ComputeSize(population);
            if (population.Length < size)
            {
                return AdaptedStrategy.Select(population).ToArray();
            }
            else
            {
                ArrayAlgorithm.ParallelQuickSort(population, comparer);
                return population.Take((Int32)EliteSize.ComputeSize(population)).Concat(AdaptedStrategy.Select(population)).ToArray();
            }
        }
    }
}
