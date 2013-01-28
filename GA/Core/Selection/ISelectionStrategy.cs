using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GA.Core.Chromosome;
using GA.Core.Fitness;

namespace GA.Core.Selection
{
    /// <summary>
    /// Interfejs algorymu selekcji.
    /// </summary>
    public interface ISelectionStrategy
    {
        /// <summary>
        /// Realizuje algorytm selekcji.
        /// </summary>
        /// <param name="population">Populacja poddawana selekcji.</param>
        /// <returns>Zbiór osobników populacji, wybranych w wyniku selekcji do następnej generacji.</returns>
        IChromosome[] Select(IChromosome[] population);
    }
}
