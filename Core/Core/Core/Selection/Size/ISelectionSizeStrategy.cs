using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GA.Core.Chromosome;

namespace GA.Core.Selection
{
	/*
	 * Strategia wyznaczania rozmiaru grupy lub populacji.
	 */
    public interface ISelectionSizeStrategy
    {
        UInt32 ComputeSize(IChromosome[] population);
    }
}
