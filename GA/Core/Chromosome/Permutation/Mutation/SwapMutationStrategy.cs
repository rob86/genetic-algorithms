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
        /// Implementuje mutację przez zamiane elementów chromosomu.
        /// </summary>
        public class SwapMutationStrategy : IMutationStrategy
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
                    Int32 mutationValue = chromosome.Data[mutationPoint1];
                    chromosome.Data[mutationPoint1] = chromosome.Data[mutationPoint2];
                    chromosome.Data[mutationPoint2] = mutationValue;
                }
            }
            public override string ToString()
            {
                return "SwapMutationStrategy";
            }
        }
    }
}
