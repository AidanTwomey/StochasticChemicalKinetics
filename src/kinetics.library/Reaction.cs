using System;
using System.Collections.Generic;
using System.Linq;

namespace StochasticChemicalKinetics.src.kinetics.library
{
    public class Reaction
    {
        public readonly IDictionary<Species, int> Inputs;
        public readonly IDictionary<Species, int> Outputs;
        private readonly double _rate;

        public Reaction(IDictionary<Species, int> inputs, IDictionary<Species, int> outputs, double rate)
        {
            Inputs = inputs;
            Outputs = outputs;
            _rate = rate;
        }

        public double Propensity(ChemicalSystem system)
        {
            return Inputs
                    .Select( s => CountCollisions( s.Value, (system.Count(s.Key)) ) )
                    .Aggregate(_rate, (acc, count) => acc * count);
        }

        private double CountCollisions( int coefficient, int speciesCount)
        {
            int count = 1;
            int i = 0;

            for( int c = coefficient ; c > 0 ; c--)
            {
                count *= (speciesCount - (i++) );
            }

            return (double)count;
        }
    }
}