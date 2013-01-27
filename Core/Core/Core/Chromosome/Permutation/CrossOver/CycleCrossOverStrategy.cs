using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace GA.Core.Chromosome.Permutation
{
    /// <summary>
    /// Chromosom reprezentujący permutacje.
    /// </summary>
    public partial class PermutationChromosome
    {
        /// <summary>
        /// Krzyżowanie cykliczne.
        /// </summary>
        public class CycleCrossOverStrategy : ICrossOverStrategy
        {
            /// <summary>
            /// Krzyżuje dwa osobniki modyfikując je.
            /// </summary>
            /// <param name="ch1">Osobnik pierwszy.</param>
            /// <param name="ch2">Osobnik drugi.</param>
            public void CrossOver(PermutationChromosome ch1, PermutationChromosome ch2)
            {
#if DEBUG
                Debug.Assert(ch1.RandomGenerator.GetType() == ch2.RandomGenerator.GetType());
                Debug.Assert(ch1.CrossOverStrategy.GetType() == ch2.CrossOverStrategy.GetType());
                Debug.Assert(ch1.HasSameData(ch2));
#endif
                Int32[] child1 = new Int32[ch1.Data.Length];
                Int32[] child2 = new Int32[ch2.Data.Length];

                Boolean[] visited = new Boolean[ch2.Data.Length];

                Int32 pos = 0;
                do
                {
                    // odd circle
                    pos = Array.IndexOf(visited, false);
                    while (pos >= 0 && false == visited[pos])
                    {
                        visited[pos] = true;

                        child1[pos] = ch1.Data[pos];
                        child2[pos] = ch2.Data[pos];

                        pos = Array.IndexOf(ch1.Data, ch2.Data[pos]);
                    }

                    // even circle
                    pos = Array.IndexOf(visited, false);
                    while (pos >= 0 && false == visited[pos])
                    {
                        visited[pos] = true;

                        child1[pos] = ch2.Data[pos];
                        child2[pos] = ch1.Data[pos];

                        pos = Array.IndexOf(ch2.Data, ch1.Data[pos]);
                    }
                } while (Array.IndexOf(visited, false) >= 0);

                ch1.Data = child1;
                ch2.Data = child2;
            }
            public override string ToString()
            {
                return "CycleCrossOverStrategy";
            }
        }
    }
}
