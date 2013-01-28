using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GA.Core.Chromosome;
using GA.Core.Fitness;
using GA.Core.Selection;
using GA.Core.Util;
using GA.Core.Stop;

namespace GA.Core.Population
{
    /// <summary>
    /// Domyślna implementacja interfejsu populacji.
    /// </summary>
    public class DefaultPopulation : IPopulation
    {
        /// <summary>
        /// Wykorzystywany generator liczb losowych.
        /// </summary>
        public IRandomGenerator RandomGenerator
        {
            get;
            set;
        }

        /// <summary>
        /// Algorytm selekcji dla populacji.
        /// </summary>
        public ISelectionStrategy SelectionStrategy
        {
            get;
            set;
        }

        /// <summary>
        /// Algorytm warunku stopu.
        /// </summary>
        public IStopCondition StopCondition
        {
            get;
            set;
        }

        /// <summary>
        /// Aktualny wiek populacji.
        /// </summary>
        public UInt32 Generation
        {
            get;
            private set;
        }

        /// <summary>
        /// Osobniki populacji.
        /// </summary>
        public IChromosome[] Specimens
        {
            get;
            private set;
        }

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="prototype">Osobnik-wzorzec, który będzie kopiowany na potrzeby utworzenia populacji.</param>
        /// <param name="initialSize">Początkowy rozmiar populacji.</param>
        public DefaultPopulation(IChromosome prototype, UInt32 initialSize)
        {
            Generation = 0;
            Specimens = new IChromosome[initialSize];
            for (Int32 i = 0; i < initialSize; ++i)
            {
                IChromosome chromosome = prototype.Clone();
                chromosome.Randomize();
                Specimens[i] = chromosome;
            }
        }

        /// <summary>
        /// Realizuje pojedynczą iterację algorytmu genetycznego.
        /// </summary>
        /// <returns>True, jeżeli warunek stopu zwrócił true, tzn. należy kontynuować algorytm genetyczny.</returns>
        public Boolean NextGeneration()
        {
            if (StopCondition.ShouldContinue(Specimens) == false)
            {
                return false;
            }

            // shuffle before selection
            ArrayAlgorithm.Shuffle(Specimens, RandomGenerator);

            // select parents
            Specimens = SelectionStrategy.Select(Specimens);

            if (Specimens.Length == 0)
            {
                return false;
            }

            // shuffle before mating
            ArrayAlgorithm.Shuffle(Specimens, RandomGenerator);

            // crossover & mutate

            IChromosome[] offspring = new IChromosome[(Int32)(Specimens.Length / 2) * 2];

            var evens = Enumerable.Range(0, Specimens.Length - 1).Where(i => i % 2 != 1);
            Parallel.ForEach(evens, i =>
                {
                    // crossover
                    offspring[i + 0] = Specimens[i + 0].Clone();
                    offspring[i + 1] = Specimens[i + 1].Clone();

                    offspring[i + 0].CrossOver(offspring[i + 1]);

                    // mutate
                    offspring[i + 0].Mutate();
                    offspring[i + 1].Mutate();             
                });

            // new population
            Specimens = offspring;
            Parallel.ForEach(Specimens, specimen =>
                {
                    specimen.IncrementAge();
                });

            ++Generation;

            return true;
        }
    }
}
