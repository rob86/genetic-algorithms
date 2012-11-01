using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GA.Core.Chromosome;

namespace GA.Core.Fitness
{
    public interface IFitness
    {
        double Evaluate(PermutationChromosome chromosome);
    }
}
