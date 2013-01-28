using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GA.Core.Chromosome;

namespace GA.Core.Selection
{
	/// <summary>
	/// Stały rozmiar populacji.
	/// </summary>
    public class FixedSizeStrategy : ISelectionSizeStrategy
    {
        /// <summary>
        /// Romiar populacji.
        /// </summary>
        private UInt32 Size
        {
            get;
            set;
        }

        /// <summary>
        /// Konstruktor.
        /// </summary>
        /// <param name="size">Romiar populacji.</param>
        public FixedSizeStrategy(UInt32 size)
        {
            Size = size;
        }

        /// <summary>
        /// Wyznacza nowy rozmiar grupy/populacji na podstawie jej bieżących cech.
        /// </summary>
        /// <param name="population">Populacja, dla której ma byc wyznaczony nowy rozmiar.</param>
        /// <returns>Nowy rozmiar populacji.</returns>
        public UInt32 ComputeSize(IChromosome[] population)
        {
            return Size;
        }
    }
}
