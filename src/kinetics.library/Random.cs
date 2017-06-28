//using StochasticChemicalKinetics.src.kinetics.library;
using System;


namespace StochasticChemicalKinetics.src.kinetics.library
{
    public class Random : IRandom
    {
        private readonly System.Random _random;
        public Random(int seed)
        {
            _random = new System.Random(seed);
        }

        public RandomPair GetNext()
        {
            return new RandomPair(_random.NextDouble(), _random.NextDouble());
        }
    }
}
