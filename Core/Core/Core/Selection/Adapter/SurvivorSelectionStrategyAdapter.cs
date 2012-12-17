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
    /// <summary>
    /// Modyficator selekcji, który usuwa z populacji osobniki przebywające w niej dłużej niż określona liczba iteracji.
    /// </summary>
    public class SurvivorSelectionStrategyAdapter : ISelectionStrategy
    {
        /// <summary>
        /// Wykorzystywany komparator.
        /// </summary>
        private IComparer<IChromosome> comparer = new AgeComparer();

        /// <summary>
        /// Maksymalny rozmiar grupy, która przetrwa.
        /// </summary>
        private ISelectionSizeStrategy SurvivorsSize
        {
            get;
            set;
        }

        /// <summary>
        /// Modyfikowana strategia selekcji.
        /// </summary>
        private ISelectionStrategy AdaptedStrategy
        {
            get;
            set;
        }

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="adaptedStrategy">Modyfikowana strategia selekcji.</param>
        /// <param name="survivorsSize">Maksymalny rozmiar grupy, która przetrwa.</param>
        public SurvivorSelectionStrategyAdapter(ISelectionStrategy adaptedStrategy, ISelectionSizeStrategy survivorsSize)
        {
            AdaptedStrategy = adaptedStrategy;
            SurvivorsSize = survivorsSize;
        }

        /// <summary>
        /// Realizuje algorytm selekcji.
        /// </summary>
        /// <param name="population">Populacja poddawana selekcji.</param>
        /// <returns>Zbiór osobników populacji, wybranych w wyniku selekcji do następnej generacji.</returns>
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
