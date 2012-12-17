using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GA.Core.Chromosome;

namespace GA.Core.Comparer
{
    /// <summary>
    /// Porównuje chromosomy na podstawie ich wieku.
    /// </summary>
    public class AgeComparer : IComparer<IChromosome>
    {
        /// <summary>
        /// Porównuje chromosomy na podstawie ich wieku.
        /// </summary>
        /// <param name="ch1">Pierwszy chromosom do porównania.</param>
        /// <param name="ch2">Drugi chromosom do porównania.</param>
        /// <returns>Liczbę ujemną, jeżeli ch1 jest młodszy; liczbe dodatnią, jeżeli ch2 jest młodszy; zero jeżeli oba chromosomy są w tym samym wieku.</returns>
        public Int32 Compare(IChromosome ch1, IChromosome ch2)
        {
            if (ch1.Age < ch2.Age)
            {
                return -1;
            }
            else if (ch1.Age > ch2.Age)
            {
                return 1;
            }
            return 0;
        }
    }
}
