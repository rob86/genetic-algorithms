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
    /*
	 * Wykładniczy ranking osobników.
	 */
    public class ExponentialSelectionRanking : ISelectionRanking
    {
        private IComparer<IChromosome> comparer = new FitnessComparer();

        private IChromosome[] Population
        {
            get;
            set;
        }
        private Double NormalizationConstant
        {
            get;
            set;
        }
        public ExponentialSelectionRanking(Double normalizationConstant)
        {
            Debug.Assert(normalizationConstant > 0.0 && normalizationConstant <= 1.0);
            NormalizationConstant = normalizationConstant;
        }
        public void SetPopulation(IChromosome[] population)
        {
            Population = (IChromosome[])population.Clone();
            ArrayAlgorithm.ParallelQuickSort(Population, comparer);
        }
        public Double GetRank(Int32 index)
        {
            Double m = index + 1.0;
            return (1.0 - Math.Exp(-m)) / NormalizationConstant;
        }
        public IChromosome GetChromosome(Int32 index)
        {
            return Population[index];
        }
    }
}
