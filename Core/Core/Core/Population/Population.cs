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
    public class DefaultPopulation : IPopulation
    {
        public IRandomGenerator RandomGenerator
        {
            get;
            set;
        }
        public ISelectionStrategy ParentSelectionStrategy
        {
            get;
            set;
        }
        public ISelectionStrategy SurvivorSelectionStrategy
        {
            get;
            set;
        }
        public IStopCondition StopCondition
        {
            get;
            set;
        }
        public UInt32 Generation
        {
            get;
            private set;
        }
        public IChromosome[] Specimens
        {
            get;
            private set;
        }
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
        public Boolean NextGeneration()
        {
            if (StopCondition.ShouldContinue(Specimens) == false)
            {
                return false;
            }

            // shuffle before selection
            ArrayAlgorithm.Shuffle(Specimens, RandomGenerator);

            // select parents
            Specimens = ParentSelectionStrategy.Select(Specimens);

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

            // select survivors
            Specimens = SurvivorSelectionStrategy.Select(Specimens.Concat(offspring).ToArray());

            if (Specimens.Length == 0)
            {
                return false;
            }

            // new population
            Parallel.ForEach(Specimens, specimen =>
                {
                    specimen.IncrementAge();
                });

            ++Generation;

            return true;
        }
    }
}
