using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GA.Core.Chromosome.Permutation;

namespace GA.Core.Fitness
{
    /// <summary>
    /// Interfejs algorytmu wyznaczania oceny dopasowania.
    /// </summary>
    public interface IFitness
    {
        /// <summary>
        /// Dokonuje oceny dopasowania.
        /// </summary>
        /// <param name="chromosome">Oceniany chromosom.</param>
        /// <returns>Ocena dopasowania.</returns>
        double Evaluate(PermutationChromosome chromosome);
    }
}
