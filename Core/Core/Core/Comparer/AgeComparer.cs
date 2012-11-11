using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GA.Core.Chromosome;

namespace GA.Core.Comparer
{
    public class AgeComparer : IComparer<IChromosome>
    {
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
