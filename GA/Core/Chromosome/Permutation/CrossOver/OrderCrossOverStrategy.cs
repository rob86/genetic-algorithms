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
        /// Krzyżowanie porządkowe.
        /// </summary>
        public class OrderCrossOverStrategy : ICrossOverStrategy
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
                Int32 crossOverPoint1 = ch1.RandomGenerator.Next(0, ch1.Data.Length);
                Int32 crossOverPoint2 = ch1.RandomGenerator.Next(0, ch1.Data.Length);

                if (crossOverPoint1 != crossOverPoint2)
                {
                    Int32 copLower = Math.Min(crossOverPoint1, crossOverPoint2);
                    Int32 copUpper = Math.Max(crossOverPoint1, crossOverPoint2);

                    Int32[] data1 = OrderCrossOver(ch1.Data, ch2.Data, copLower, copUpper);
                    Int32[] data2 = OrderCrossOver(ch2.Data, ch1.Data, copLower, copUpper);

                    ch1.Data = data1;
                    ch2.Data = data2;
                }
            }
            /// <summary>
            /// Metoda pomocnicza, która realizuje krzyżowanie porządkowe na kopii danych wejściowych.
            /// </summary>
            /// <param name="data1">Tablica reprezentująca pierwszy chromosom.</param>
            /// <param name="data2">Tablica reprezentująca pierwszy chromosom.</param>
            /// <param name="copLower">Początkowy indeks fragmentu tablicy data1, który będzie skopiowany wprost.</param>
            /// <param name="copUpper">Końcowy indeks fragmentu tablicy data1, który będzie skopiowany wprost.</param>
            /// <returns>Osobnik uzyskany w wyniku krzyżowania porządkowego.</returns>
            private Int32[] OrderCrossOver(Int32[] data1, Int32[] data2, Int32 copLower, Int32 copUpper)
            {
#if DEBUG
                Debug.Assert(data1.Length == data2.Length);
                Debug.Assert(copLower < copUpper);
#endif
                Int32 length = data1.Length;
                Int32[] result = new Int32[length];

                // Copy randomly selected set from first parent
                for (Int32 i = copLower; i <= copUpper; ++i)
                {
                    result[i] = data1[i];
                }

                // Copy rest from second parent in order
                Int32 rPosition = (copUpper + 1) % length;
                Int32 dPosition = (copUpper + 1) % length;
                while (rPosition != copLower)
                {
                    if (data2.Length > dPosition)
                    {
                        if (ValueInRange(data1, data2[dPosition], copLower, copUpper) == false)
                        {
                            result[rPosition] = data2[dPosition];
                            rPosition = ++rPosition % length;
                        }
                    }
                    dPosition = ++dPosition % length;
                }
                return result;
            }
            /// <summary>
            /// Metoda pomocnicza, która sprawdza, czy value występuje w fragmencie tablicy określonym przez indeksy copLower i copUpper.
            /// </summary>
            /// <param name="data">Tablica do sprawdzenia.</param>
            /// <param name="value">Poszukiwana wartość.</param>
            /// <param name="copLower">Indeks początku fragmentu tablicy.</param>
            /// <param name="copUpper">Indeks końca fragmentu tablicy.</param>
            /// <returns>True, jeżeli wartość value występuje we wskazanym fragmencie tablicy data.</returns>
            private Boolean ValueInRange(Int32[] data, Int32 value, Int32 copLower, Int32 copUpper)
            {
                for (Int32 i = copLower; i <= copUpper; ++i)
                {
                    if (data[i] == value)
                    {
                        return true;
                    }
                }
                return false;
            }
            public override string ToString()
            {
                return "OrderCrossOver";
            }
        }
    }
}
