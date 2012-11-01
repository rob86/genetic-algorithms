using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using GA.Core.Chromosome;

namespace GA.Core.Fitness
{
    public class TSPFitness : IFitness
    {
        private Double[,] costMatrix;

        public TSPFitness(Double[,] costMatrix)
        {
            this.costMatrix = (Double[,])costMatrix.Clone();
        }
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
            return cost;
        }
    }
}
