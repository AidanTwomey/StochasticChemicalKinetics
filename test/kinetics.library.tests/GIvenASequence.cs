using System;
using Xunit;
using StochasticChemicalKinetics.src.kinetics.library;
using System.Collections.Generic;

namespace StochasticChemicalKinetics.test.kinetics.library.tests
{
    public class GivenASequence
    {
        [Fact]
        public void should_partition_unit_interval()
        {
            var sequence = new []{0.5, 0.25, 0.125, 0.06025};
            var expected = new []{
                new Tuple<double,double>(0, 0.5), 
                new Tuple<double,double>(0.5, 0.75), 
                new Tuple<double,double>(0.75, 0.875), 
                new Tuple<double,double>(0.875, 1.0)
                };

            Assert.Equal(expected, Partitioner.ToIntervals(sequence) );
        }
    }
}