using NSubstitute;
using StochasticChemicalKinetics.src.kinetics.library;
using StochasticChemicalKinetics.src.kinetics.library.SSA;
using System;
using Xunit;
using System.Linq;
using System.Collections.Generic;

namespace StochasticChemicalKinetics.test.kinetics.library.tests
{
    public class GillespieDirectTests
    {
        [Fact]
        public void should_return_()
        {
            var random = Substitute.For<IRandom>();

            random.GetNext().Returns(new RandomPair(0.1,0.8));

            var gillespieAlgorithm = new GillespieDirect(random);

            var r1 = new Reaction(
                new Dictionary<Species,int>(){{"A",2}, {"B", 2} },
                new Dictionary<Species,int>(){{"C",1}},
                0.5);

            var r2 = new Reaction(
                new Dictionary<Species,int>(){{"A",1}, {"B", 1} },
                new Dictionary<Species,int>(),
                0.25);
                
            var r3 = new Reaction(
                new Dictionary<Species,int>(),
                new Dictionary<Species,int>(){{"A",1}},
                0.2);                

            var system = new ChemicalSystem( new Dictionary<Species,int>{
                {"A", 2},
                {"B", 3}
            } );

            var evolvedSystem = gillespieAlgorithm.GetPath(new []{r1,r2,r3}, system, 0.0).Single().Value;

            Assert.Equal(1, evolvedSystem.Count("A") );
            Assert.Equal(2, evolvedSystem.Count("B") );
        }
    }
}