namespace StochasticChemicalKinetics.src.kinetics.library
{
    public struct RandomPair
    {
        public RandomPair(double r1, double r2)
        {
            this.r1 = r1;
            this.r2 = r2;
        }
        public readonly double r1;
        public readonly double r2;
    }

    public interface IRandom
    {
         RandomPair GetNext();
    }
}