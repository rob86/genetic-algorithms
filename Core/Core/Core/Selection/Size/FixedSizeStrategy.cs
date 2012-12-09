using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GA.Core.Chromosome;

namespace GA.Core.Selection
{
	/*
	 * Stały rozmiar grupy/populacji.
	 */
    public class FixedSizeStrategy : ISelectionSizeStrategy
    {
        private UInt32 Size
        {
            get;
            set;
        }
        public FixedSizeStrategy(UInt32 size)
        {
            Size = size;
        }
        public UInt32 ComputeSize(IChromosome[] population)
        {
            return Size;
        }
    }
}
