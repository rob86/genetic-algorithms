using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

using GA.Core.Chromosome;

namespace GA.Core.Selection
{
    /// <summary>
    /// Rozmiar populacji proporcjonalny do bieżącego rozmiaru.
    /// </summary>
    public class ProportionalSizeStrategy : ISelectionSizeStrategy
    {
        /// <summary>
        /// Współczynnik proporcjonalności w zakresie [0.0, 1.0]
        /// </summary>
        private Double Percent
        {
            get;
            set;
        }

        public ProportionalSizeStrategy(Double percent)
        {
            Debug.Assert(percent >= 0.0);
            Debug.Assert(percent <= 1.0);

            Percent = percent;
        }

        /// <summary>
        /// Wyznacza nowy rozmiar grupy/populacji na podstawie jej bieżących cech.
        /// </summary>
        /// <param name="population">Populacja, dla której ma byc wyznaczony nowy rozmiar.</param>
        /// <returns>Nowy rozmiar populacji.</returns>
        public UInt32 ComputeSize(IChromosome[] population)
        {
            return (UInt32)Math.Round(population.Length * Percent);
        }
    }
}
