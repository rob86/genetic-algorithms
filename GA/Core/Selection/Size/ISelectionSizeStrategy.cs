using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GA.Core.Chromosome;

namespace GA.Core.Selection
{
	/// <summary>
	/// Interfejs algorytmu wyznaczania rozmiaru grupy/populacji.
	/// </summary>
    public interface ISelectionSizeStrategy
    {
        /// <summary>
        /// Wyznacza nowy rozmiar grupy/populacji na podstawie jej bieżących cech.
        /// </summary>
        /// <param name="population">Populacja, dla której ma byc wyznaczony nowy rozmiar.</param>
        /// <returns>Nowy rozmiar populacji.</returns>
        UInt32 ComputeSize(IChromosome[] population);
    }
}
