using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

using GA.Core.Fitness;

namespace GA.Core.Chromosome
{
    public interface IChromosome
    {
        IChromosome Clone();
        void Randomize();

        void Mutate();
        void CrossOver(IChromosome chromosome);

        Double Evaluate();

        String ToString();

        void IncrementAge();
        Int32 Age { get; }
    }
}
