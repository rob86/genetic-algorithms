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
    /// Modyficator selekcji, który gwarantuje, że określona liczba najlepiej dopasowanych osobników przejdzie do następnej iteracji.
    /// </summary>
    public class EliteSelectionStrategyAdapter : ISelectionStrategy
    {
        private IComparer<IChromosome> comparer = new FitnessReverseComparer();

        /// <summary>
        /// Rozmiar grupy najlepiej dopasowanych osobników.
        /// </summary>
        private ISelectionSizeStrategy EliteSize
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
        /// <param name="eliteSize">Rozmiar grupy najlepiej dopasowanych osobników.</param>
        public EliteSelectionStrategyAdapter(ISelectionStrategy adaptedStrategy, ISelectionSizeStrategy eliteSize)
        {
            AdaptedStrategy = adaptedStrategy;
            EliteSize = eliteSize;
        }

        /// <summary>
        /// Realizuje algorytm selekcji.
        /// </summary>
        /// <param name="population">Populacja poddawana selekcji.</param>
        /// <returns>Zbiór osobników populacji, wybranych w wyniku selekcji do następnej generacji.</returns>
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
