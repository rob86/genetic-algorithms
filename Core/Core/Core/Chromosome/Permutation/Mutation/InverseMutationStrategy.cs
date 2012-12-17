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
        /// Implementuje mutację przez odwracanie kolejności elementów losowego fragmentu chromosomu.
        /// </summary>
        public class InverseMutationStrategy : IMutationStrategy
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

                    Array.Reverse(chromosome.Data, mpLower, mpUpper - mpLower);
                }
            }
            /// <summary>
            /// Zwraca nazwę algorytmu mutacji.
            /// </summary>
            /// <returns>Nazwa algorytmu mutacji</returns>
            public string GetName()
            {
                return "InverseMutationStrategy";
            }
        }
    }
}
