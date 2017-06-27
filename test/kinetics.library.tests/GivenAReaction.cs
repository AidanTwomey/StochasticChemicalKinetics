using System;
using Xunit;
using StochasticChemicalKinetics.src.kinetics.library;
using System.Collections.Generic;

namespace StochasticChemicalKinetics.test.kinetics.library.tests
{
    public class GivenAReaction
    {
        [Fact]
        public void should_calculate_propensity()
        {
            var reaction = new Reaction(
                new Dictionary<Species,int>(){{"A",1}},
                new Dictionary<Species,int>(){{"B",1}},
                0.5);

            var system = new ChemicalSystem( new Dictionary<Species,int>{
                {"A", 2},
                {"B", 3}
            } );

            Assert.Equal( 3.0, reaction.Propensity(system) );
        }
    }
}