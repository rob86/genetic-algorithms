using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GA.Core.Fitness;
using GA.Core.Chromosome;

namespace GA.Core.Selection
{
    public class EliteSelectionStrategy : ISelectionStrategy
    {
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
            Array.Sort(population, (IChromosome ch1, IChromosome ch2) => 
            {
                if (ch1.Evaluate() > ch2.Evaluate())
                    return 1;
                else if (ch1.Evaluate() < ch2.Evaluate())
                    return -1;
                else
                    return 0;
            });
            return (IChromosome[])population.Take((Int32)Size.ComputeSize(population)).ToArray();
        }
    }
}
