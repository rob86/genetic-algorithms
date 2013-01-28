using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA.Core.Util
{
    /// <summary>
    /// Generator liczb losowych bezpieczny ze względu na wielowątkowość.
    /// </summary>
    public class ThreadSafeRandomGenerator : IRandomGenerator
    {
        /// <summary>
        /// Wykorzystywany generator liczb losowych.
        /// </summary>
        private Random generator = new Random();

        /// <summary>
        /// Następna losowa wartość całkowita.
        /// </summary>
        /// <param name="minValue">Minimalna zwracana wartość.</param>
        /// <param name="maxValue">Maksymalna zwracana wartość.</param>
        /// <returns>Liczba losowa całkowita z zadanego zakresu.</returns>
        public Int32 Next(Int32 minValue, Int32 maxValue)
        {
            lock(this)
            {
                return generator.Next(minValue, maxValue);
            }
        }

        /// <summary>
        /// Następna losowa wartość całkowita.
        /// </summary>
        /// <param name="maxValue">Maksymalna zwracana wartość.</param>
        /// <returns>Liczba losowa całkowita z zakresu [0, maxValue].</returns>
        public Int32 Next(Int32 maxValue)
        {
            return Next(0, maxValue);
        }

        /// <summary>
        /// Następna losowa wartość całkowita.
        /// </summary>
        /// <returns>Liczba losowa całkowita.</returns>
        public Int32 Next()
        {
            return Next(0, Int32.MaxValue);
        }

        /// <summary>
        /// Następna losowa wartość zmiennoprzecinkowa.
        /// </summary>
        /// <returns>Losowa wartość zmiennoprzecinkowa z zakresu [0, 1]</returns>
        public Double NextDouble()
        {
            lock (this)
            {
                return generator.NextDouble();
            }
        }

        /// <summary>
        /// Nastepny losowy ciąg bajtów.
        /// </summary>
        /// <param name="buffer">Bufor, do którego zostanie zapisany losowy ciąg.</param>
        public void NextBytes(Byte[] buffer)
        {
            lock (this)
            {
                generator.NextBytes(buffer);
            }
        }
    }
}
