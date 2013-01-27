using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA.Core.Chromosome.Permutation
{
    /// <summary>
    /// Chromosom reprezentujący permutacje.
    /// </summary>
    public partial class PermutationChromosome
    {
        /// <summary>
        /// Implementuje mutację przez wstawianie.
        /// </summary>
        public class InsertMutationStrategy : IMutationStrategy
        {
            /// <summary>
            /// Realizuje algorytm mutacji na zadanym chromosomie.
            /// </summary>
            /// <param name="chromosome">Chromosom, który zostanie poddany mutacji.</param>
            public void Mutate(PermutationChromosome chromosome)
            {
                Int32 mutationPoint1 = chromosome.RandomGenerator.Next(0, chromosome.Data.Length);
                Int32 mutationPoint2 = chromosome.RandomGenerator.Next(0, chromosome.Data.Length);

                if (mutationPoint1 != mutationPoint2)
                {
                    Int32 mpLower = Math.Min(mutationPoint1, mutationPoint2);
                    Int32 mpUpper = Math.Max(mutationPoint1, mutationPoint2);

                    Int32 mutationValueLower = chromosome.Data[mpLower];
                    Int32 mutationValueUpper = chromosome.Data[mpUpper];

                    Int32 position = mpUpper;
                    while ((--position) > mpLower)
                    {
                        chromosome.Data[position + 1] = chromosome.Data[position];
                    }
                    chromosome.Data[mpLower + 0] = mutationValueLower;
                    chromosome.Data[mpLower + 1] = mutationValueUpper;
                }
            }
            public override string ToString()
            {
                return "InsertMutationStrategy";
            }
        }
    }
}
