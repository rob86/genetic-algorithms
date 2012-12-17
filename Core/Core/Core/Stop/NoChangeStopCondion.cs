using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GA.Core.Chromosome;

namespace GA.Core.Stop
{
    /// <summary>
    /// Warunek stopu, który kontynuje wykonywanie do momentu, gdy najlepiej dopasowany osobnik nie będzie się zmieniać przez określoną liczbę iteracji.
    /// </summary>
    public class NoChangeStopCondion : IStopCondition
    {
        /// <summary>
        /// Najlepiej dopasowany osobnik w populacji.
        /// </summary>
        public IChromosome Leader
        {
            get;
            private set;
        }

        /// <summary>
        /// Wymagana liczba powtórzeń najlepszego osobnika, aby ShouldContinue zwróciło false.
        /// </summary>
        private UInt32 maxNumberOfRepeats;

        /// <summary>
        /// Dotychczasowa liczba powtórzeń.
        /// </summary>
        private UInt32 numberOfRepeats = 0;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="maxNumberOfRepeats">Wymagana liczba powtórzeń najlepszego osobnika, aby ShouldContinue zwróciło false.</param>
        public NoChangeStopCondion(UInt32 maxNumberOfRepeats)
        {
            Leader = null;
            this.maxNumberOfRepeats = maxNumberOfRepeats;
        }

        /// <summary>
        /// Sprawdza warunek stopu.
        /// </summary>
        /// <param name="population">Populacja, dla której ma być sprawdzony warunek stopu.</param>
        /// <returns>True, gdy warunek stopu nie został osiągnięty dla populacji population.</returns>
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
