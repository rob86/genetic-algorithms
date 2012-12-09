using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GA.Core.Chromosome;

namespace GA.Core.Stop
{
    /*
	 * Interfejs dla warunku stopu.
	 */
    public interface IStopCondition
    {
		/*
		 * Zwraca true, gdy warunek stopu nie został osiągnięty dla populacji population.
		 */
        Boolean ShouldContinue(IChromosome[] population);
    }
}
