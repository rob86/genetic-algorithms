using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GA.Core.Chromosome;

namespace GA.Core.Selection
{
    public interface ISelectionRanking
    {
        void SetPopulation(IChromosome[] population);

        Double GetRank(Int32 index);
        IChromosome GetChromosome(Int32 index);
    }
}
