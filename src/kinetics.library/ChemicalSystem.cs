using System;
using System.Collections.Generic;
using System.Linq;

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

        public ChemicalSystem React(Reaction reaction)
        {
            var updatedSystem = _system
                .ToDictionary( kv => kv.Key, kv => kv.Value - DestroyedSpecies(reaction, kv.Key) + CreatedSpecies(reaction, kv.Key));
                        
            return new ChemicalSystem(updatedSystem);
        }

        private int DestroyedSpecies(Reaction reaction, Species species)
        {
            return reaction.Inputs.Keys.Contains(species) ? reaction.Inputs[species] : 0;
        }

        private int CreatedSpecies(Reaction reaction, Species species)
        {
            return reaction.Outputs.Keys.Contains(species) ? reaction.Inputs[species] : 0;
        }
    }
}