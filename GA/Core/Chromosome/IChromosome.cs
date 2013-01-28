using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

using GA.Core.Fitness;

namespace GA.Core.Chromosome
{
    /// <summary>
    /// Interfejs chromosomu.
    /// </summary>
    public interface IChromosome
    {
        /// <summary>
        /// Kopiuje instancję obiektu chromosomu.
        /// </summary>
        /// <returns></returns>
        IChromosome Clone();

        /// <summary>
        /// Inicjalizuje allele chromosomu w sposób losowy.
        /// </summary>
        void Randomize();

        /// <summary>
        /// Realizuje algorytm mutacji na allelach chromosomu.
        /// </summary>
        void Mutate();

        /// <summary>
        /// Realizuje algorytm krzyżowania z chromosomem chromosome, z użyciem algorytmu przypisanego do tego chromosomu.
        /// </summary>
        /// <param name="chromosome">Chromosom, który będzie skrzyżowany z tym chromosomem.</param>
        void CrossOver(IChromosome chromosome);

        /// <summary>
        /// Dokonuje oceny chromosomu.
        /// </summary>
        /// <returns></returns>
        Double Evaluate();

        /// <summary>
        /// Tworzy tekstową reprezentację chromosomu.
        /// </summary>
        /// <returns>Tekstowa reprezentacja chromosomu.</returns>
        String ToString();

        /// <summary>
        /// Inkrementuje licznik pokoleń dla tego chromosomu.
        /// </summary>
        void IncrementAge();

        /// <summary>
        /// Wartość licznia pokoleń.
        /// </summary>
        Int32 Age { get; }
    }
}
