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
    public class EliteSelectionStrategy : ISelectionStrategy
    {
        private IComparer<IChromosome> comparer = new ReverseComparator();

        private ISelectionSizeStrategy Size
        {
            get;
            set;
        }
        public EliteSelectionStrategy(ISelectionSizeStrategy size)
        {
            Size = size;
        }
        public IChromosome[] Select(IChromosome[] population)
        {
            ArrayAlgorithm.ParallelQuickSort(population, comparer);
            return (IChromosome[])population.Take((Int32)Size.ComputeSize(population)).ToArray();
        }
    }
}
