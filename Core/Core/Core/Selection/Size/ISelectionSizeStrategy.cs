using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GA.Core.Chromosome;

namespace GA.Core.Selection
{
    public interface ISelectionSizeStrategy
    {
        UInt32 ComputeSize(IChromosome[] population);
    }
}
