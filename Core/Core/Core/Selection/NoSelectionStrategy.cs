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
    /// <summary>
    /// Implementuje brak czynników selekcyjnych.
    /// </summary>
    public class NoSelectionStrategy : ISelectionStrategy
    {
        /// <summary>
        /// Realizuje algorytm selekcji.
        /// </summary>
        /// <param name="population">Populacja poddawana selekcji.</param>
        /// <returns>Zbiór osobników populacji, wybranych w wyniku selekcji do następnej generacji.</returns>
        public IChromosome[] Select(IChromosome[] population)
        {
            return population;
        }
    }
}
