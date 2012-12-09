using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GA.Core.Chromosome;
using GA.Core.Fitness;

namespace GA.Core.Selection
{
    /// <summary>
    /// Selekcja
    /// </summary>
    public interface ISelectionStrategy
    {
        IChromosome[] Select(IChromosome[] population);
    }
}
