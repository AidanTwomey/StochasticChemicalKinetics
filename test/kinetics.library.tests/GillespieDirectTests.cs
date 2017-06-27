using NSubstitute;
using StochasticChemicalKinetics.src.kinetics.library;
using StochasticChemicalKinetics.src.kinetics.library.SSA;
using System;
using Xunit;
using System.Linq;

namespace StochasticChemicalKinetics.test.kinetics.library.tests
{
    public class GillespieDirectTests
    {
        [Fact]
        public void should_return_()
        {
            var random = Substitute.For<IRandom>();

            var gillespieAlgorithm = new GillespieDirect(random);

            Assert.Equal(0.0, gillespieAlgorithm.GetPath(0.0).Single().value );
        }
    }
}