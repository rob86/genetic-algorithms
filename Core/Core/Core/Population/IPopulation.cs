using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GA.Core.Chromosome;
using GA.Core.Selection;

namespace GA.Core.Population
{
    public interface IPopulation
    {
        ISelectionStrategy SelectionStrategy { get; set; }

        IChromosome BestFitness { get; }

        UInt32 Generation { get; }
        void NextGeneration();

        IChromosome[] Specimens { get; }
    }
}
