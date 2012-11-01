using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

using GA.Core.Chromosome;

namespace GA.Core.Selection
{
    public class ProportionalSizeStrategy : ISelectionSizeStrategy
    {
        [Range(0.0, 1.0)]
        private Double Percent
        {
            get;
            set;
        }
        public ProportionalSizeStrategy(Double percent)
        {
            Percent = percent;
        }
        public UInt32 ComputeSize(IChromosome[] population)
        {
            return (UInt32)Math.Round(population.Length * Percent);
        }
    }
}
