using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using GA.Core.Chromosome.Permutation;

namespace GA.Core.Fitness
{
    /// <summary>
    /// Ocena dopasowania dla problemu komiwojażera.
    /// </summary>
    public class TSPFitness : IFitness
    {
        /// <summary>
        /// Macierz kosztu przejścia.
        /// </summary>
        private Double[,] costMatrix;

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="costMatrix">Macierz kosztu przejścia.</param>
        public TSPFitness(Double[,] costMatrix)
        {
            this.costMatrix = (Double[,])costMatrix.Clone();
        }
        /// <summary>
        /// Dokonuje oceny dopasowania.
        /// </summary>
        /// <param name="chromosome">Oceniany chromosom.</param>
        /// <returns>Ocena dopasowania.</returns>
        public double Evaluate(PermutationChromosome chromosome)
        {
            Int32[] permutation = chromosome.Data;
#if DEBUG
            Debug.Assert(costMatrix.GetLength(0) == costMatrix.GetLength(1));
            Debug.Assert(costMatrix.GetLength(0) == permutation.Length);
            Debug.Assert(permutation.Min() == 0);
            Debug.Assert(permutation.Max() == permutation.Length - 1);
#endif
            Double cost = 0.0;
            for (Int32 i = 1; i < permutation.Length; ++i)
            {
                cost += costMatrix[permutation[i - 1], permutation[i]];
            }
            cost += costMatrix[permutation[permutation.Length - 1], permutation[0]];
            return Double.IsInfinity(cost) ? 0.0 : 1.0 / cost;
        }
    }
}
