using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA.Core.Util
{
    /// <summary>
    /// Interfejs generator liczb losowych.
    /// </summary>
    public interface IRandomGenerator
    {
        /// <summary>
        /// Następna losowa wartość całkowita.
        /// </summary>
        /// <param name="minValue">Minimalna zwracana wartość.</param>
        /// <param name="maxValue">Maksymalna zwracana wartość.</param>
        /// <returns>Liczba losowa całkowita z zadanego zakresu.</returns>
        Int32 Next(Int32 minValue, Int32 maxValue);

        /// <summary>
        /// Następna losowa wartość całkowita.
        /// </summary>
        /// <param name="maxValue">Maksymalna zwracana wartość.</param>
        /// <returns>Liczba losowa całkowita z zakresu [0, maxValue].</returns>
        Int32 Next(Int32 maxValue);

        /// <summary>
        /// Następna losowa wartość całkowita.
        /// </summary>
        /// <returns>Liczba losowa całkowita.</returns>
        Int32 Next();

        /// <summary>
        /// Następna losowa wartość zmiennoprzecinkowa.
        /// </summary>
        /// <returns>Losowa wartość zmiennoprzecinkowa z zakresu [0, 1]</returns>
        Double NextDouble();

        /// <summary>
        /// Nastepny losowy ciąg bajtów.
        /// </summary>
        /// <param name="buffer">Bufor, do którego zostanie zapisany losowy ciąg.</param>
        void NextBytes(Byte[] buffer);
    }
}
