using System;
using System.Collections.Generic;

namespace StochasticChemicalKinetics.src.kinetics.library
{
    public class ChemicalSystem
    {
        private readonly IDictionary<Species, int> _system;

        public ChemicalSystem( IDictionary<Species,int> system )
        {
            _system = system;
        }

        public int Count(Species species)
        {
            return _system[species];
        }
    }
}