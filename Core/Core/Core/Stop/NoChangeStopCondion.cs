using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GA.Core.Chromosome;

namespace GA.Core.Stop
{
	/*
	 * Warunek stopu, który kontynuje wykonywanie do momentu, gdy najlepiej dopasowany osobnik nie będzie się zmieniać przez określoną liczbę iteracji.
	 */
    public class NoChangeStopCondion : IStopCondition
    {
		/*
		 * Najlepiej dopasowany osobnik w populacji.
		 */
        public IChromosome Leader
        {
            get;
            private set;
        }

		/*
		 * Wymagana liczba powtórzeń najlepszego osobnika, aby ShouldContinue zwróciło false.
		 */
        private UInt32 maxNumberOfRepeats;

		/*
		 * Dotychczasowa liczba powtórzeń.
		 */
        private UInt32 numberOfRepeats = 0;

        public NoChangeStopCondion(UInt32 maxNumberOfRepeats)
        {
            Leader = null;
            this.maxNumberOfRepeats = maxNumberOfRepeats;
        }
        public Boolean ShouldContinue(IChromosome[] population)
        {
            IChromosome newLeaderReference = null;
            Double newLeaderFitness = Double.MinValue;
            foreach(IChromosome chromosome in population)
            {
                if (chromosome.Evaluate() > newLeaderFitness)
                {
                    newLeaderFitness = chromosome.Evaluate();
                    newLeaderReference = chromosome;
                }
            }
            if (Leader == null || Leader.ToString().Equals(newLeaderReference.ToString()) == false)
            {
                numberOfRepeats = 0;
                Leader = newLeaderReference;
            }

            return numberOfRepeats++ < maxNumberOfRepeats;
        }
    }
}
