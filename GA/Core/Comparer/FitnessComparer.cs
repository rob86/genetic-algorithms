using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GA.Core.Chromosome;

namespace GA.Core.Comparer
{
    /// <summary>
    /// Porównuje chromosomy na podstawie ich oceny dopasowania.
    /// </summary>
    public class FitnessComparer : IComparer<IChromosome>
    {
        /// <summary>
        /// Porównuje chromosomy na podstawie ich oceny dopasowania.
        /// </summary>
        /// <param name="ch1">Pierwszy chromosom do porównania.</param>
        /// <param name="ch2">Drugi chromosom do porównania.</param>
        /// <returns>Liczbę ujemną, jeżeli ch2 jest lepiej dopasowany; liczbe dodatnią, jeżeli ch1 jest lepiej dopasowany; zero jeżeli oba chromosomy są tak samo dobrze dopasowane.</returns>
        public Int32 Compare(IChromosome ch1, IChromosome ch2)
        {
            if (ch1.Evaluate() < ch2.Evaluate())
            {
                return -1;
            }
            else if (ch1.Evaluate() > ch2.Evaluate())
            {
                return 1;
            }
            return 0;
        }
    }
}
