using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GA.Core.Util
{
    public interface IRandomGenerator
    {
        Int32 Next(Int32 minValue, Int32 maxValue);
        Int32 Next(Int32 maxValue);
        Int32 Next();

        Double NextDouble();

        void NextBytes(Byte[] buffer);
    }
}
