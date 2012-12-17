﻿using System;
namespace GA.Core.Chromosome.Permutation
{
    /// <summary>
    /// Chromosom reprezentujący permutacje.
    /// </summary>
    public partial class PermutationChromosome
    {
        /// <summary>
        /// Interfejs dla algorytmów mutacji dla problemu optymalnej permutacji.
        /// </summary>
        public interface IMutationStrategy
        {
            /// <summary>
            /// Zwraca nazwę algorytmu mutacji.
            /// </summary>
            /// <returns>Nazwa algorytmu mutacji</returns>
            string GetName();

            /// <summary>
            /// Realizuje algorytm mutacji na zadanym chromosomie.
            /// </summary>
            /// <param name="chromosome">Chromosom, który zostanie poddany mutacji.</param>
            void Mutate(PermutationChromosome chromosome);
        }
    }
}
