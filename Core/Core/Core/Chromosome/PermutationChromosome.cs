using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using GA.Core.Fitness;
using GA.Core.Util;

namespace GA.Core.Chromosome
{
    public class PermutationChromosome : IChromosome
    {

        #region MutationStrategy

        public interface IMutationStrategy
        {
            void Mutate(PermutationChromosome chromosome);
        }
        public class SwapMutationStrategy : IMutationStrategy
        {
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
        }
        public class InsertMutationStrategy : IMutationStrategy
        {
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
        }
        public class InverseMutationStrategy : IMutationStrategy
        {
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
        }
        public class ScrambleMutationStrategy : IMutationStrategy
        {
            public void Mutate(PermutationChromosome chromosome)
            {
                Int32 mutationPoint1 = chromosome.RandomGenerator.Next(0, chromosome.Data.Length);
                Int32 mutationPoint2 = chromosome.RandomGenerator.Next(0, chromosome.Data.Length);

                if (mutationPoint1 != mutationPoint2)
                {
                    Int32 mpLower = Math.Min(mutationPoint1, mutationPoint2);
                    Int32 mpUpper = Math.Max(mutationPoint1, mutationPoint2);

                    for (Int32 i = mpLower; i < mpUpper; ++i)
                    {
                        Int32 value = chromosome.Data[i];
                        Int32 point = chromosome.RandomGenerator.Next(i, mpUpper);
                        chromosome.Data[i] = chromosome.Data[point];
                        chromosome.Data[point] = value;
                    }
                }
            }
        }

        #endregion

        #region CrossOverStrategy

        public interface ICrossOverStrategy
        {
            void CrossOver(PermutationChromosome ch1, PermutationChromosome ch2);
        }
        public class OrderCrossOverStrategy : ICrossOverStrategy
        {
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
                Int32 rPosition = copUpper + 1;
                Int32 dPosition = copUpper + 1;
                while (rPosition != copLower)
                {
                    if (ValueInRange(data1, data2[dPosition], copLower, copUpper) == false)
                    {
                        result[rPosition] = data2[dPosition];
                        rPosition = ++rPosition % length;
                    }
                    dPosition = ++dPosition % length;
                }
                return result;
            }
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
        }
        public class PartiallyMappedCrossOverStrategy : ICrossOverStrategy
        {
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

                    Int32[] data1 = PartiallyMappedCrossOver(ch1.Data, ch2.Data, copLower, copUpper);
                    Int32[] data2 = PartiallyMappedCrossOver(ch2.Data, ch1.Data, copLower, copUpper);

                    ch1.Data = data1;
                    ch2.Data = data2;
                }
            }
            private Int32[] PartiallyMappedCrossOver(Int32[] data1, Int32[] data2, Int32 copLower, Int32 copUpper)
            {
#if DEBUG
                Debug.Assert(data1.Length == data2.Length);
                Debug.Assert(copLower < copUpper);
#endif
                Int32 length = data1.Length;
                Int32[] result = new Int32[length];
                Boolean[] visited = new Boolean[length];

                // Copy randomly selected set from first parent
                for (Int32 i = copLower; i <= copUpper; ++i)
                {
                    result[i] = data1[i];
                    visited[i] = true;
                }

                // Copy rest from second parent with mapping
                for (Int32 i = copLower; i <= copUpper; ++i)
                {
                    if (false == ValueInRange(data1, data2[i], copLower, copUpper))
                    {
                        Int32 position2 = MapValue(data1, data2, data1[i], copLower, copUpper);
                        result[position2] = data2[i];
                        visited[position2] = true;
                    }
                }

                for (Int32 i = 0; i < length; ++i)
                {
                    if (false == visited[i])
                    {
                        result[i] = data2[i];
                    }
                }

                return result;
            }
            private Int32 MapValue(Int32[] data1, Int32[] data2, Int32 value, Int32 copLower, Int32 copUpper)
            {
#if DEBUG
                Debug.Assert(data1.Length == data2.Length);
                Debug.Assert(copLower < copUpper);
#endif
                Int32 position1 = Array.IndexOf(data1, value);
                Int32 position2 = Array.IndexOf(data2, value);

                Debug.Assert(position1 >= copLower && position1 <= copUpper);

                if (position1 == position2)
                {
                    return position1;
                }
                if (position2 >= copLower && position2 <= copUpper)
                {
                    return MapValue(data1, data2, data1[position2], copLower, copUpper);
                }
                return position2;
            }
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
        }
        public class CycleCrossOverStrategy : ICrossOverStrategy
        {
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
        }
        #endregion

        public IRandomGenerator RandomGenerator
        {
            get;
            set;
        }
        public IMutationStrategy MutationStrategy
        {
            get;
            set;
        }
        public ICrossOverStrategy CrossOverStrategy
        {
            get;
            set;
        }
        public IFitness Fitness
        {
            get;
            set;
        }
        private Double Evaluation
        {
            get;
            set;
        }
        public Int32[] Data
        {
            get;
            private set;
        }
        public Int32 Age
        {
            get;
            private set;
        }
        public PermutationChromosome(Int32[] data)
        {
            Debug.Assert(data.Length > 3);

            Age = 0;
            Evaluation = Double.NaN;
            Data = (Int32[])data.Clone();
        }
        public PermutationChromosome(Int32 minValue, Int32 maxValue)
        {
            Debug.Assert(maxValue > minValue);
            Debug.Assert(maxValue - minValue > 3);

            Age = 0;
            Evaluation = Double.NaN;
            Data = new Int32[maxValue - minValue + 1];

            for (Int32 i = minValue; i <= maxValue; ++i)
            {
                Data[i - minValue] = i;
            }
        }
        public IChromosome Clone()
        {
            PermutationChromosome chromosome = new PermutationChromosome(Data);

            chromosome.RandomGenerator = RandomGenerator;
            chromosome.MutationStrategy = MutationStrategy;
            chromosome.CrossOverStrategy = CrossOverStrategy;
            chromosome.Fitness = Fitness;

            return chromosome;
        }
        public void Mutate()
        {
            Evaluation = Double.NaN;
            MutationStrategy.Mutate(this);
        }
        public void CrossOver(IChromosome chromosome)
        {
            Evaluation = Double.NaN;
            CrossOverStrategy.CrossOver(this, (PermutationChromosome)chromosome);
        }
        public Double Evaluate()
        {
            if (Double.IsNaN(Evaluation))
            {
                Evaluation = Fitness.Evaluate(this);
            }
            return Evaluation;
        }
        public void Randomize()
        {
            for (Int32 i = 0; i < Data.Length; ++i)
            {
                Int32 value = Data[i];
                Int32 point = RandomGenerator.Next(i, Data.Length);
                Data[i] = Data[point];
                Data[point] = value;
            }
        }
        public String ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (Int32 i = 0; i < Data.Length; ++i)
            {
                builder.Append(Data[i]);
                builder.Append("\t");
            }
            return builder.ToString();
        }
        public void IncrementAge()
        {
            ++Age;
        }
        private bool HasSameData(PermutationChromosome chromosome)
        {
            foreach (Int32 value in chromosome.Data)
            {
                if (false == Data.Contains(value))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
