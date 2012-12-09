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
	/*
	 * Modyficator selekcji, który usuwa z populacji osobniki przebywające w niej dłużej niż określona liczba iteracji.
	 */
    public class SurvivorSelectionStrategyAdapter : ISelectionStrategy
    {
        private IComparer<IChromosome> comparer = new AgeComparer();

		/*
		 * Rozmiar grupy, która przetrwa.
		 */
        private ISelectionSizeStrategy SurvivorsSize
        {
            get;
            set;
        }
		/*
		 * Modyfikowana strategia selekcji.
		 */
        private ISelectionStrategy AdaptedStrategy
        {
            get;
            set;
        }
        public SurvivorSelectionStrategyAdapter(ISelectionStrategy adaptedStrategy, ISelectionSizeStrategy survivorsSize)
        {
            AdaptedStrategy = adaptedStrategy;
            SurvivorsSize = survivorsSize;
        }
        public IChromosome[] Select(IChromosome[] population)
        {
            IChromosome[] result = AdaptedStrategy.Select(population);
            UInt32 size = SurvivorsSize.ComputeSize(population);
            if (result.Length < size)
            {
                return result;
            }
            else
            {
                ArrayAlgorithm.ParallelQuickSort(result, comparer);
                return population.Take((Int32)SurvivorsSize.ComputeSize(result)).ToArray();
            }
        }
    }
}
