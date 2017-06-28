using System.Collections.Generic;
using StochasticChemicalKinetics.src.kinetics.library.SSA;
using System;
using System.Linq;

namespace StochasticChemicalKinetics.src.kinetics.library.Parsing
{
    public class EquationParser
    {
        public static Reaction Parse(string equation)
        {
            var divider = equation.IndexOf( "->" );

            var inputs = equation.Substring(0, divider-1);
            var outputs = equation.Substring( divider+2, equation.Length - divider - 2);

            return new Reaction( new Dictionary<Species,int>(){ {"A",1}}, null, 0.0 );
        }
    }
}