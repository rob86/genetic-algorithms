using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GA.Core.Chromosome;
using GA.Core.Selection;
using GA.Core.Stop;


namespace GA.Core.Population
{
    public interface IPopulation
    {
        ISelectionStrategy ParentSelectionStrategy { get; set; }
        ISelectionStrategy SurvivorSelectionStrategy { get; set; }

        IStopCondition StopCondition { get; set; }

        UInt32 Generation { get; }
        Boolean NextGeneration();

        IChromosome[] Specimens { get; }
    }
}
