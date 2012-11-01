using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

using GA.Core.Chromosome;
using GA.Core.Fitness;
using GA.Core.Selection;
using GA.Core.Util;

namespace GA.Core.Population
{
    public class DefaultPopulation : IPopulation
    {
        [Required]
        public IRandomGenerator RandomGenerator
        {
            get;
            set;
        }
        [Required]
        public ISelectionStrategy SelectionStrategy
        {
            get;
            set;
        }
        public UInt32 Generation
        {
            get;
            private set;
        }
        public IChromosome BestFitness
        {
            get;
            private set;
        }
        [Required]
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
        public void NextGeneration()
        {
            // select
            Specimens = SelectionStrategy.Select(Specimens);
            BestFitness = Specimens[0];

            // shuffle
            for (Int32 i = 0; i < Specimens.Length; ++i)
            {
                IChromosome value = Specimens[i];
                Int32 point = RandomGenerator.Next(i, Specimens.Length);
                Specimens[i] = Specimens[point];
                Specimens[point] = value;
            }

            // crossover & mutate

            IChromosome[] offspring = new IChromosome[(Int32)(Specimens.Length / 2) * 2];
            for (Int32 i = 0; i < Specimens.Length - 1; i += 2)
            {
                // crossover
                offspring[i + 0] = Specimens[i + 0].Clone();
                offspring[i + 1] = Specimens[i + 1].Clone();

                offspring[i + 0].CrossOver(offspring[i + 1]);
                
                // mutate
                offspring[i + 0].Mutate();
                offspring[i + 1].Mutate();
            }

            // new population
            Specimens = (IChromosome[])Specimens.Concat(offspring).ToArray();

            ++Generation;
        }

    }
}
