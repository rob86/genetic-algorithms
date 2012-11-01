using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA.Core.Util
{
    public class ThreadSafeRandomGenerator : IRandomGenerator
    {
        private Random generator = new Random();

        public Int32 Next(Int32 minValue, Int32 maxValue)
        {
            lock(this)
            {
                return generator.Next(minValue, maxValue);
            }
        }
        public Int32 Next(Int32 maxValue)
        {
            return Next(0, maxValue);
        }
        public Int32 Next()
        {
            return Next(0, Int32.MaxValue);
        }
        public Double NextDouble()
        {
            lock (this)
            {
                return generator.NextDouble();
            }
        }
        public void NextBytes(Byte[] buffer)
        {
            lock (this)
            {
                generator.NextBytes(buffer);
            }
        }
    }
}
