using System.Collections.Generic;
using StochasticChemicalKinetics.src.kinetics.library.SSA;
using System;

namespace StochasticChemicalKinetics.src.kinetics.library.SSA
{
    public class TimePoint<T>
    {
        public readonly double time;
        public T value;
    }

    public class GillespieDirect
    {
        private readonly IRandom _random;

        public GillespieDirect(IRandom random)
        {
            _random = random;
        }

        public IEnumerable<TimePoint<double>> GetPath(double endTime)
        {
            throw new NotImplementedException();
        }
    }
}