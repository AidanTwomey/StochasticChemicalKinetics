namespace StochasticChemicalKinetics.src.kinetics.library
{
    public class Species
    {
        public Species(string species) { val = species; }
        
        public string val;
        
        public static implicit operator string(Species species)
        {
            return species.val;
        }
        
        public static implicit operator Species(string species)
        {
            return new Species(species);
        }

        public override string ToString()
        {
            return val;
        }

		protected bool Equals(Species other)
		{
			return string.Equals(val, other.val);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Species) obj);
		}

		public override int GetHashCode()
		{
			return (val != null ? val.GetHashCode() : 0);
		}


    }
}