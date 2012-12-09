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
	 * Brak selekcji.
	 */
    public class NoSelectionStrategy : ISelectionStrategy
    {
        public IChromosome[] Select(IChromosome[] population)
        {
            return population;
        }
    }
}
