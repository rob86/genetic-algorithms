using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using GA.Core.Chromosome;
using GA.Core.Util;
using GA.Core.Comparer;

namespace GA.Core.Selection
{
    public class LinearSelectionRanking : ISelectionRanking
    {
        private IComparer<IChromosome> comparer = new FitnessComparer();

        private IChromosome[] Population
        {
            get;
            set;
        }
        private Double SelectivePressure
        {
            get;
            set;
        }
        public LinearSelectionRanking(Double selectivePressure)
        {
            Debug.Assert(selectivePressure > 1.0 && selectivePressure <= 2.0);
            SelectivePressure = selectivePressure;
        }
        public void SetPopulation(IChromosome[] population)
        {
            Population = (IChromosome[])population.Clone();
            ArrayAlgorithm.ParallelQuickSort(Population, comparer);
        }
        public Double GetRank(Int32 index)
        {
            Double m = index + 1.0;
            return (2.0 - SelectivePressure) / m + 2.0 * m * (SelectivePressure - 1.0) / (m * (m - 1));
        }
        public IChromosome GetChromosome(Int32 index)
        {
            return Population[index];
        }
    }
}
