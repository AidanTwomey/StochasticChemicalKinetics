using NSubstitute;
using StochasticChemicalKinetics.src.kinetics.library;
using StochasticChemicalKinetics.src.kinetics.library.Parsing;
using System;
using Xunit;
using System.Linq;
using System.Collections.Generic;

namespace StochasticChemicalKinetics.test.kinetics.library.tests
{
    public class GivenAChemicalEquation
    {
        [Theory]
        [InlineData("A -> 0", "A")]
        public void parse_into_a_reaction(string equation, params string[] expected)
        {
            var reaction = EquationParser.Parse(equation);

            var inputs = reaction.Inputs.Select(i => i.Key).ToArray();

            Assert.True( expected.Zip( inputs, (e,i) => new {Expected = e, Actual = i} ).All( p => p.Expected == p.Actual));
            
        }
    }
}
