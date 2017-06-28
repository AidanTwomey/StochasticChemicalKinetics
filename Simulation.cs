namespace aidantwomey.src.dotnetcore.StochasticChemicalKinetics
{
    public class Simulation
    {
        public double timeLimit { get;set;}

        public int steps { get;set;}

        public IEnumerable<KeyValuePair<string,double>> reactions { get;set;}
    }
}