using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

using GA.Core.Fitness;
using GA.Core.Chromosome;
using GA.Core.Util;
using GA.Core.Comparer;

namespace GA.Core.Selection
{
    public class FitnessProportionateSelectionStrategy : ISelectionStrategy
    {
        private IRandomGenerator RandomGenerator
        {
            get;
            set;
        }
        private ISelectionSizeStrategy Size
        {
            get;
            set;
        }
        public FitnessProportionateSelectionStrategy(ISelectionSizeStrategy size, IRandomGenerator randomGenerator)
        {
            Size = size;
            RandomGenerator = randomGenerator;
        }
        public IChromosome[] Select(IChromosome[] population)
        {
            // Stochastic universal sampling

            IChromosome[] subpopulation = population.Where(ch => ch.Evaluate() > 0).ToArray();
            Double totalFitness = subpopulation.Sum(ch => 1.0 / ch.Evaluate());

            Int32 newPopulationSize = (Int32)Size.ComputeSize(subpopulation);
            IChromosome[] result = new IChromosome[newPopulationSize];

            Double ptrstep = 1.0 / newPopulationSize;
            Double ptr = RandomGenerator.NextDouble() * ptrstep;

            Int32 pos = 0;
            Double sum = 0.0;
            for (Int32 i = 0; i < subpopulation.Length; i++)
            {
                Double fitness = 1.0 / subpopulation[i].Evaluate();
                for (sum += fitness / totalFitness; sum > ptr; ptr += ptrstep)
                {
                    result[pos++] = subpopulation[i];

                    if (pos == newPopulationSize)
                    {
                        return result;
                    }
                }
            }

            // it shouldn't happen
            Debug.Assert(false);
            return result;
        }
    }
}
