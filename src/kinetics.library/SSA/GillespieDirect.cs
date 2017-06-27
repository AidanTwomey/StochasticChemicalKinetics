using System.Collections.Generic;
using StochasticChemicalKinetics.src.kinetics.library.SSA;
using System;
using System.Linq;

namespace StochasticChemicalKinetics.src.kinetics.library.SSA
{
    public struct TimePoint<T>
    {
        public TimePoint(double time, T value)
        {
            Time = time;
            Value = value;
        }

        public readonly double Time;
        public readonly T Value;
    }

    public class GillespieDirect
    {
        private readonly IRandom _random;

        public GillespieDirect(IRandom random)
        {
            _random = random;
        }

        public IEnumerable<TimePoint<ChemicalSystem>> GetPath(IList<Reaction> reactions, ChemicalSystem initialSystem, double endTime)
        {
            double t = 0;
            var evolvingSystem = initialSystem;
            int numReactions = reactions.Count;

            var zeroPoint = new []{0.0};
            var endPoint = new []{1.0};

            do{
                var randoms = _random.GetNext();
                var propensities = reactions.Select(r => r.Propensity(evolvingSystem) );

                var totalPropensity = propensities.Sum();

                var normalisedPropensities = propensities.Select( p => p / totalPropensity).ToList();

                var partitionedPropensities =  Partitioner.ToIntervals(normalisedPropensities)
                        .Zip( reactions, (interval,reaction) => new Tuple<Tuple<double,double>,Reaction>(interval, reaction) );

                var selectedReaction = partitionedPropensities
                        .Single( pair => randoms.r2 > pair.Item1.Item1 && randoms.r2 < pair.Item1.Item2)
                        .Item2;
                
                t = Math.Log(1.0/randoms.r1) / totalPropensity;

                evolvingSystem = evolvingSystem.React(selectedReaction);

                yield return new TimePoint<ChemicalSystem>(0.0, evolvingSystem);

            }while (t <= endTime);
        }
    }
}