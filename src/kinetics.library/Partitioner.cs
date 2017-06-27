using System;
using System.Collections.Generic;
using System.Linq;

namespace StochasticChemicalKinetics.src.kinetics.library
{
    public class Partitioner
    {
        public static IEnumerable<Tuple<double,double>> ToIntervals(IList<double> sequence)
        {
            double runningTotal = 0.0;
            
            foreach( var point in sequence.Take(sequence.Count - 1) )
            {
                double startPoint = runningTotal;
                runningTotal += point;

                yield return new Tuple<double, double>(startPoint, runningTotal);
            }

            yield return new Tuple<double, double>(runningTotal, 1.0);
        }
    }
}