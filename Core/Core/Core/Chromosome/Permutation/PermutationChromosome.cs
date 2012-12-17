using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using GA.Core.Fitness;
using GA.Core.Util;

namespace GA.Core.Chromosome.Permutation
{
    /// <summary>
    /// Chromosom reprezentujący permutacje.
    /// </summary>
    public partial class PermutationChromosome : IChromosome
    {
        /// <summary>
        /// Wykorzystywany generator liczb losowych.
        /// </summary>
        public IRandomGenerator RandomGenerator
        {
            get;
            set;
        }
        /// <summary>
        /// Wykorzystywany algorytm mutacji.
        /// </summary>
        public IMutationStrategy MutationStrategy
        {
            get;
            set;
        }
        /// <summary>
        /// Wykorzystywany algorytm krzyżowania.
        /// </summary>
        public ICrossOverStrategy CrossOverStrategy
        {
            get;
            set;
        }
        /// <summary>
        /// Wykorzystywany algorytm oceny dopasowania.
        /// </summary>
        public IFitness Fitness
        {
            get;
            set;
        }
        /// <summary>
        /// Ostatnia ocena dopasowania.
        /// </summary>
        private Double Evaluation
        {
            get;
            set;
        }
        /// <summary>
        /// Allele chromosomu.
        /// </summary>
        public Int32[] Data
        {
            get;
            private set;
        }
        /// <summary>
        /// Wartość licznia pokoleń.
        /// </summary>
        public Int32 Age
        {
            get;
            private set;
        }
        /// <summary>
        /// Konstruktor. Inicjalizacja na podstawie zadanej permutacji.
        /// </summary>
        /// <param name="data">Allele.</param>
        public PermutationChromosome(Int32[] data)
        {
            Debug.Assert(data.Length > 3);

            Age = 0;
            Evaluation = Double.NaN;
            Data = (Int32[])data.Clone();
        }
        /// <summary>
        /// Konstruktor. Inicjalizacja na postawie zakresu wartości permutacji.
        /// </summary>
        /// <param name="minValue">Minimalna wartość w permutacji.</param>
        /// <param name="maxValue">Maksymalna wartość w permutacji.</param>
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
        /// <summary>
        /// Kopiuje instancję obiektu chromosomu.
        /// </summary>
        /// <returns></returns>
        public IChromosome Clone()
        {
            PermutationChromosome chromosome = new PermutationChromosome(Data);

            chromosome.RandomGenerator = RandomGenerator;
            chromosome.MutationStrategy = MutationStrategy;
            chromosome.CrossOverStrategy = CrossOverStrategy;
            chromosome.Fitness = Fitness;

            return chromosome;
        }
        /// <summary>
        /// Realizuje algorytm mutacji na allelach chromosomu.
        /// </summary>
        public void Mutate()
        {
            Evaluation = Double.NaN;
            MutationStrategy.Mutate(this);
        }
        /// <summary>
        /// Realizuje algorytm krzyżowania z chromosomem chromosome, z użyciem algorytmu przypisanego do tego chromosomu.
        /// </summary>
        /// <param name="chromosome">Chromosom, który będzie skrzyżowany z tym chromosomem.</param>
        public void CrossOver(IChromosome chromosome)
        {
            Evaluation = Double.NaN;
            CrossOverStrategy.CrossOver(this, (PermutationChromosome)chromosome);
        }
        /// <summary>
        /// Dokonuje oceny chromosomu.
        /// </summary>
        /// <returns></returns>
        public Double Evaluate()
        {
            if (Double.IsNaN(Evaluation))
            {
                Evaluation = Fitness.Evaluate(this);
            }
            return Evaluation;
        }
        /// <summary>
        /// Inicjalizuje allele chromosomu w sposób losowy.
        /// </summary>
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
        /// <summary>
        /// Tworzy tekstową reprezentację chromosomu.
        /// </summary>
        /// <returns>Tekstowa reprezentacja chromosomu.</returns>
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
        /// <summary>
        /// Inkrementuje licznik pokoleń dla tego chromosomu.
        /// </summary>
        public void IncrementAge()
        {
            ++Age;
        }
        /// <summary>
        /// Porównuje allele dwóch chromosomów.
        /// </summary>
        /// <param name="chromosome">Chromosom, z którym jest realizowane porównywanie.</param>
        /// <returns>True, jeżeli oba chromosomy mają takie same allele na odpowiadających sobie pozycjach.</returns>
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
