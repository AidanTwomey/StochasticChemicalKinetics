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

        public double Propensity(ChemicalSystem system)
        {
            return _inputs
                    .Select( s => (double)(system.Count(s.Key)) )
                    .Aggregate(_rate, (acc, count) => acc * count);
        }
    }
}