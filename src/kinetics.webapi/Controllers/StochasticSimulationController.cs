using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StochasticChemicalKinetics.src.kinetics.library.SSA;
using StochasticChemicalKinetics.src.kinetics.library;
using StochasticChemicalKinetics.src.kinetics.library.Parsing;
using kinetics.webapi;
using log4net;

namespace kinetics.webapi.Controllers
{
    [Route("ssa/gillespie")]
    public class StochasticSimulationController : Controller
    {
        private readonly GillespieDirect _gillespieDirect = new GillespieDirect(new StochasticChemicalKinetics.src.kinetics.library.Random(DateTime.Now.Millisecond));

        private ILog log = LogManager.GetLogger(typeof(StochasticSimulationController));

        [HttpGet("{steps}")]
        public JsonResult Get(int steps)
        {
            return Json("please use POST");
        }

        [HttpPost]
        public JsonResult Post([FromBody] Simulation simulation)
        {
            log.Info(String.Join(";", simulation.reactions.Select(r => r.equation)));

            return Json( _gillespieDirect
                        .GetPath( 
                            GetReactions(simulation.reactions), 
                            GetSystem(simulation.initialPopulations), 
                            simulation.timeLimit, 
                            simulation.steps)
                        .Select( r => new { r.Time, A = r.Value.Count("A"), B = r.Value.Count("B") }));
        }

        private IList<Reaction> GetReactions(IEnumerable<ReactionPair> reactions)
        {
            return reactions
                .Select( kv => EquationParser.Parse( kv.equation, kv.rate ))
                .ToList();
        }

        private ChemicalSystem GetSystem(IEnumerable<Populations> initialPopulations)
        {
            return new ChemicalSystem( initialPopulations.ToDictionary(p => new Species(p.species), p => p.count) );
        }
    }
}