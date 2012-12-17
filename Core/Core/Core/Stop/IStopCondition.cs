using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GA.Core.Chromosome;

namespace GA.Core.Stop
{
    /// <summary>
    /// Interfejs algorytmu kontroli warunku stopu.
    /// </summary>
    public interface IStopCondition
    {
        /// <summary>
        /// Sprawdza warunek stopu.
        /// </summary>
        /// <param name="population">Populacja, dla której ma być sprawdzony warunek stopu.</param>
        /// <returns>True, gdy warunek stopu nie został osiągnięty dla populacji population.</returns>
        Boolean ShouldContinue(IChromosome[] population);
    }
}
