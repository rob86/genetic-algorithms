using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;

namespace GA.Core.Util
{
    /// <summary>
    /// Zbiór algorytmów operujących na kolekcjach.
    /// </summary>
    static class ArrayAlgorithm
    {
        /// <summary>
        /// Wykorzystywany generator liczb losowych.
        /// </summary>
        private static IRandomGenerator RandomGenerator = new ThreadSafeRandomGenerator();

        /// <summary>
        /// Realizuje algorytm quick sort w sposób równoległy.
        /// </summary>
        /// <typeparam name="T">Typ elementów sortowanej kolekcji.</typeparam>
        /// <param name="collection">Kolekcja do posortowania.</param>
        /// <param name="comparator">Komparator elementów kolekcji.</param>
        public static void ParallelQuickSort<T>(IList<T> collection, IComparer<T> comparator)
        {
            ParallelQuickSort(collection, 0, collection.Count - 1, comparator);
        }

        /// <summary>
        /// Realizuje algorytm quick sort w sposób równoległy.
        /// </summary>
        /// <typeparam name="T">Typ elementów sortowanej kolekcji.</typeparam>
        /// <param name="collection">Kolekcja do posortowania.</param>
        /// <param name="comparator">Komparator elementów kolekcji.</param>
        /// <param name="lowerIndex">Dolny indeks zakresu do posortowania.</param>
        /// <param name="upperIndex">Górny indeks zakresu do posortowania.</param>
        public static void ParallelQuickSort<T>(IList<T> collection, IComparer<T> comparator, Int32 lowerIndex, Int32 upperIndex)
        {
            ParallelQuickSort(collection, lowerIndex, upperIndex, comparator);
        }

        /// <summary>
        /// Metoda pomocnicza. Realizuje algorytm quick sort w sposób równoległy.
        /// </summary>
        /// <typeparam name="T">Typ elementów sortowanej kolekcji.</typeparam>
        /// <param name="collection">Kolekcja do posortowania.</param>
        /// <param name="left">Dolny indeks zakresu do posortowania.</param>
        /// <param name="right">Górny indeks zakresu do posortowania.</param>
        /// <param name="comparator">Komparator elementów kolekcji.</param>
        /// <returns>Posortowana kolekcja (nie kopia!)</returns>
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

        /// <summary>
        /// Metoda pomocnicza. Wyznacza pivot w algorytmie quick sort.
        /// </summary>
        /// <typeparam name="T">Typ elementów sortowanej kolekcji.</typeparam>
        /// <param name="collection">Kolekcja do posortowania.</param>
        /// <param name="left">Dolny indeks zakresu do posortowania.</param>
        /// <param name="right">Górny indeks zakresu do posortowania.</param>
        /// <param name="pivotIndex">Nowa wartość pivotu.</param>
        /// <param name="comparator">Komparator elementów kolekcji.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Miesza elementy kolekcji.
        /// </summary>
        /// <typeparam name="T">Typ elementów sortowanej kolekcji.</typeparam>
        /// <param name="collection">Kolekcja do wymieszania.</param>
        public static void Shuffle<T>(IList<T> collection)
        {
            Shuffle(collection, 0, collection.Count - 1, RandomGenerator);
        }

        /// <summary>
        /// Miesza elementy kolekcji.
        /// </summary>
        /// <typeparam name="T">Typ elementów sortowanej kolekcji.</typeparam>
        /// <param name="collection">Kolekcja do wymieszania.</param>
        /// <param name="generator">Generator liczb losowych do wyznaczania pozycji elementów.</param>
        public static void Shuffle<T>(IList<T> collection, IRandomGenerator generator)
        {
            Shuffle(collection, 0, collection.Count - 1, generator);
        }

        /// <summary>
        /// Miesza elementy kolekcji.
        /// </summary>
        /// <typeparam name="T">Typ elementów sortowanej kolekcji.</typeparam>
        /// <param name="collection">Kolekcja do wymieszania.</param>
        /// <param name="lowerLimit">Dolny indeks fragmentu do wymieszania.</param>
        /// <param name="upperLimit">Górny indeks fragmentu do wymieszania.</param>
        public static void Shuffle<T>(IList<T> collection, Int32 lowerLimit, Int32 upperLimit)
        {
            Shuffle(collection, lowerLimit, upperLimit, RandomGenerator);
        }

        /// <summary>
        /// Miesza elementy kolekcji.
        /// </summary>
        /// <typeparam name="T">Typ elementów sortowanej kolekcji.</typeparam>
        /// <param name="collection">Kolekcja do wymieszania.</param>
        /// <param name="lowerLimit">Dolny indeks fragmentu do wymieszania.</param>
        /// <param name="upperLimit">Górny indeks fragmentu do wymieszania.</param>
        /// <param name="generator">Generator liczb losowych do wyznaczania pozycji elementów.</param>
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
