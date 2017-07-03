using System.Collections.Generic;
using StochasticChemicalKinetics.src.kinetics.library.SSA;
using System;
using System.Linq;

namespace StochasticChemicalKinetics.src.kinetics.library.Parsing
{
    public class EquationParser
    {
        public static Reaction Parse(string equation, double rate)
        {
            equation = RemoveNullPlaceholder(equation);

            var divider = equation.IndexOf( "->" );

            var inputs = equation.Substring(0, divider).Trim();
            var outputs = equation.Substring( divider+2, equation.Length - divider - 2).Trim();

            return new Reaction( 
                ToDictionary(inputs), 
                ToDictionary(outputs), 
                rate
            );
        }

        public static Reaction Parse(string equation)
        {
            return Parse(equation, 0.0);
        }

        private static Dictionary<Species,int> ToDictionary(string expression)
        {
            if ( string.IsNullOrEmpty(expression))
            {
                return new Dictionary<Species, int>();
            }

            return expression
                .Split('+')
                .Select(s => s.Trim())
                .Select(ToSpeciesCount)
                .ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        private static KeyValuePair<Species,int> ToSpeciesCount(string element)
        {
            if (element.Length == 1)
            {
                return new KeyValuePair<Species,int>(new Species(element), 1);
            }

            return new KeyValuePair<Species,int>(
                new Species(element.Substring(element.Length-1,1) ), 
                int.Parse(element.Substring(0,element.Length - 1)));
        }

        private static string RemoveNullPlaceholder(string equation)
        {
            return equation.Replace("0","");
        }
    }
}