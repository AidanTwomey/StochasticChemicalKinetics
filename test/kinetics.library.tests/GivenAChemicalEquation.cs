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
        [InlineData("2A->0", new []{"A"}, new string[]{}, new []{2}, new int[]{})]
        [InlineData("A -> 0", new []{"A"}, new string[]{}, new []{1}, new int[]{})]
        [InlineData("A + B -> 0", new []{"A", "B"}, new string[]{}, new []{1, 1}, new int[]{})]
        [InlineData("A+B->0", new []{"A", "B"}, new string[]{}, new []{1, 1}, new int[]{})]
        [InlineData("A + B -> C", new []{"A", "B"}, new []{"C"}, new []{1, 1}, new []{1})]
        [InlineData("0 -> C", new string[]{}, new []{"C"}, new int[]{}, new []{1})]
        [InlineData("2A + B -> 0", new []{"A", "B"}, new string[]{}, new []{2, 1}, new int[]{})]
        [InlineData("12A + B -> 0", new []{"A", "B"}, new string[]{}, new []{12, 1}, new int[]{})]
        public void parse_into_a_reaction(string equation, string[] expectedInputs, string[] expectedOutputs, int[] expectedInputCounts, int[] expectedOutputCounts)
        {
            var reaction = EquationParser.Parse(equation);

            var inputSpecies = reaction.Inputs.Select(i => new { Species = i.Key.ToString(), Count = i.Value } );
            var outputSpecies = reaction.Outputs.Select(i => new { Species = i.Key.ToString(), Count = i.Value });

            Assert.Equal(expectedInputs, inputSpecies.Select(s => s.Species).ToArray());
            Assert.Equal(expectedInputCounts, inputSpecies.Select(s => s.Count).ToArray());

            Assert.Equal(expectedOutputs, outputSpecies.Select(s => s.Species).ToArray());
            Assert.Equal(expectedOutputCounts, outputSpecies.Select(s => s.Count).ToArray());      
        }
    }
}
