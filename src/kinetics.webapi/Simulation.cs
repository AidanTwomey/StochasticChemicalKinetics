using System.Collections.Generic;
using System;

namespace kinetics.webapi
{
    public class ReactionPair
    {
        public string equation { get;set;}
        public double rate { get;set;}
    }

    public class Populations
    {
        public string species { get;set;}

        public int count { get;set;}
    }

    public class Simulation
    {
        public double timeLimit { get;set;}

        public int steps { get;set;}

        public IEnumerable<ReactionPair> reactions { get;set;}

        public IEnumerable<Populations> initialPopulations { get;set;}
    }
}