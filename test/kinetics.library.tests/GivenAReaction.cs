using System;
using Xunit;
using StochasticChemicalKinetics.src.kinetics.library;
using System.Collections.Generic;

namespace StochasticChemicalKinetics.test.kinetics.library.tests
{
    public class GivenAReaction
    {
        //A + B --> 0
        [Fact]
        public void should_calculate_propensity_for_mono_species()
        {
            var reaction = new Reaction(
                new Dictionary<Species,int>(){{"A",1}, {"B", 1} },
                new Dictionary<Species,int>(),
                0.5);

            var system = new ChemicalSystem( new Dictionary<Species,int>{
                {"A", 2},
                {"B", 3}
            } );

            Assert.Equal( 3.0, reaction.Propensity(system) );
        }

        //2A + 2B --> 0
        [Fact]
        public void should_calculate_propensity_for_multiple_species()
        {
            var reaction = new Reaction(
                new Dictionary<Species,int>(){{"A",2}, {"B", 2} },
                new Dictionary<Species,int>(),
                0.5);

            var system = new ChemicalSystem( new Dictionary<Species,int>{
                {"A", 2},
                {"B", 3}
            } );

            Assert.Equal( 6.0, reaction.Propensity(system) );
        }
    }
}