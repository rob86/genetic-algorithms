using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GA.Core.Chromosome;

namespace GA.Core.Stop
{
    public interface IStopCondition
    {
        Boolean ShouldContinue(IChromosome[] population);
    }
}
