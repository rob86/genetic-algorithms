using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;
using System.Threading;

namespace GA.Core.Util
{
    class ArrayAlgorithm
    {
        private static IRandomGenerator RandomGenerator = new ThreadSafeRandomGenerator();

        public static void ParallelQuickSort<T>(IList<T> collection, IComparer<T> comparator)
        {
            ParallelQuickSort(collection, 0, collection.Count - 1, comparator);
        }
        public static void ParallelQuickSort<T>(IList<T> collection, IComparer<T> comparator, Int32 lowerIndex, Int32 upperIndex)
        {
            ParallelQuickSort(collection, lowerIndex, upperIndex, comparator);
        }
        private static IList<T> ParallelQuickSort<T>(IList<T> collection, Int32 left, Int32 right, IComparer<T> comparator)
        {
            if (right > left)
            {
                int pivot = left;
                int newPivot = Partition(collection, left, right, pivot, comparator);

                Parallel.Invoke(delegate
                {
                    ParallelQuickSort(collection, left, newPivot - 1, comparator).AsParallel();
                },
                delegate
                {
                    ParallelQuickSort(collection, newPivot + 1, right, comparator).AsParallel();
                });
            }
            return collection;
        }
        private static int Partition<T>(IList<T> collection, Int32 left, Int32 right, Int32 pivotIndex, IComparer<T> comparator)
        {
            T pivotValue = collection[pivotIndex];
            collection[pivotIndex] = collection[right];
            collection[right] = pivotValue;

            int storeIndex = left;
            T storeVal = collection[storeIndex];
            for (int i = left; i < right; i++)
            {
                if (comparator.Compare(collection[i], pivotValue) < 0)
                {
                    collection[storeIndex] = collection[i];
                    collection[i] = storeVal;
                    ++storeIndex;
                }

                storeVal = collection[storeIndex];
                collection[storeIndex] = collection[right];
                collection[right] = storeVal;
            }

            return storeIndex;
        }
        public static void Shuffle<T>(IList<T> collection)
        {
            Shuffle(collection, 0, collection.Count - 1, RandomGenerator);
        }
        public static void Shuffle<T>(IList<T> collection, IRandomGenerator generator)
        {
            Shuffle(collection, 0, collection.Count - 1, generator);
        }
        public static void Shuffle<T>(IList<T> collection, Int32 lowerLimit, Int32 upperLimit)
        {
            Shuffle(collection, lowerLimit, upperLimit, RandomGenerator);
        }
        public static void Shuffle<T>(IList<T> collection, Int32 lowerLimit, Int32 upperLimit, IRandomGenerator generator)
        {
            for (Int32 i = lowerLimit; i < upperLimit; ++i)
            {
                T value = collection[i];
                Int32 point = generator.Next(i, collection.Count);
                collection[i] = collection[point];
                collection[point] = value;
            }
        }
    }
}
