using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GA.Core.Chromosome;
using GA.Core.Selection;
using GA.Core.Stop;


namespace GA.Core.Population
{
    /// <summary>
    /// Interfejs populacji osobników.
    /// </summary>
    public interface IPopulation
    {
        /// <summary>
        /// Algorytm selekcji dla populacji.
        /// </summary>
        ISelectionStrategy SelectionStrategy { get; set; }

        /// <summary>
        /// Algorytm warunku stopu.
        /// </summary>
        IStopCondition StopCondition { get; set; }

        /// <summary>
        /// Aktualny wiek populacji.
        /// </summary>
        UInt32 Generation { get; }

        /// <summary>
        /// Realizuje pojedynczą iterację algorytmu genetycznego.
        /// </summary>
        /// <returns>True, jeżeli warunek stopu zwrócił true, tzn. należy kontynuować algorytm genetyczny i populacja nie osiągnęła rozmiaru 0.</returns>
        Boolean NextGeneration();

        /// <summary>
        /// Osobniki populacji.
        /// </summary>
        IChromosome[] Specimens { get; }
    }
}
