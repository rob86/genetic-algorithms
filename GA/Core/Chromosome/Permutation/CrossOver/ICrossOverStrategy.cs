using System;
namespace GA.Core.Chromosome.Permutation
{
    /// <summary>
    /// Chromosom reprezentujący permutacje.
    /// </summary>
    public partial class PermutationChromosome
    {
        /// <summary>
        /// Interfejs dla algorytmów krzyżowania dla problemu optymalnej permutacji.
        /// </summary>
        public interface ICrossOverStrategy
        {
            /// <summary>
            /// Krzyżuje dwa osobniki modyfikując je.
            /// </summary>
            /// <param name="ch1">Osobnik pierwszy.</param>
            /// <param name="ch2">Osobnik drugi.</param>
            void CrossOver(PermutationChromosome ch1, PermutationChromosome ch2);
        }
    }
}
