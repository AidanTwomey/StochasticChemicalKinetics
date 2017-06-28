using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StochasticChemicalKinetics.src.kinetics.library.SSA;
using StochasticChemicalKinetics.src.kinetics.library;

namespace kinetics.webapi.Controllers
{
    public class Simulation
    {
        public double timeLimit { get;set;}

        public int steps { get;set;}

        public IEnumerable<KeyValuePair<string,double>> reactions { get;set;}
    }

    [Route("ssa/gillespie")]
    public class StochasticSimulationController : Controller
    {
        private readonly GillespieDirect _gillespieDirect = new GillespieDirect(new StochasticChemicalKinetics.src.kinetics.library.Random(DateTime.Now.Millisecond));

        [HttpGet("{steps}")]
        public JsonResult Get(int steps)
        {
            return Json("please use POST");
        }

        [HttpPost]
        public JsonResult Post([FromBody] Simulation simulation)
        {
            return Json( _gillespieDirect
                        .GetPath( GetReactions(), GetSystem(), simulation.timeLimit, simulation.steps)
                        .Select( r => new { r.Time, A = r.Value.Count("A"), B = r.Value.Count("B") }));
        }

        private IList<Reaction> GetReactions()
        {
            //TODO: parse these from request
            var r1 = new Reaction(
                new Dictionary<Species,int>(){{"A",2} },
                new Dictionary<Species,int>(),
                0.001);

            var r2 = new Reaction(
                new Dictionary<Species,int>(){{"A",1}, {"B", 1} },
                new Dictionary<Species,int>(),
                0.01);
                
            var r3 = new Reaction(
                new Dictionary<Species,int>(),
                new Dictionary<Species,int>(){{"A",1}},
                1.2);                


            var r4 = new Reaction(
                new Dictionary<Species,int>(),
                new Dictionary<Species,int>(){{"B",1}},
                1.0);    

            return new List<Reaction>(){ r1, r2, r3, r4};
        }

        private ChemicalSystem GetSystem()
        {
            return new ChemicalSystem( new Dictionary<Species,int>{
                {"A", 0},
                {"B", 0}
            } );
        }
    }
}