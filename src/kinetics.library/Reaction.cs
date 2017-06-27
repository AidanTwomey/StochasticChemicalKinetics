using System;
using System.Collections.Generic;
using System.Linq;

namespace StochasticChemicalKinetics.src.kinetics.library
{
    public class Reaction
    {
        private readonly IDictionary<Species, int> _inputs;
        private readonly IDictionary<Species, int> _outputs;
        private readonly double _rate;

        public Reaction(IDictionary<Species, int> inputs, IDictionary<Species, int> outputs, double rate)
        {
            _inputs = inputs;
            _outputs = outputs;
            _rate = rate;
        }

        private double GetCounts( int coefficient, int speciesCount)
        {
            int count = 1;
            int i = 0;

            for( int c = coefficient ; c > 0 ; c--)
            {
                count *= (speciesCount - (i++) );
            }

            return (double)count;
        }

        public double Propensity(ChemicalSystem system)
        {
            return _inputs
                    .Select( s => new Tuple<int,int>( s.Value, (system.Count(s.Key))) )
                    .Select( t => GetCounts( t.Item1, t.Item2 ) )
                    .Aggregate(_rate, (acc, count) => acc * count);
        }
    }
}