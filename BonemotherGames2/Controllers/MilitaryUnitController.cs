using BonemotherGames2.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BonemotherGames2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MilitaryUnitController : ControllerBase
    {
        [HttpGet("{rollableUnitId}")]
        public string Get(int rollableUnitId)
        {
            MilitaryUnit militaryUnit = new MilitaryUnit();
            militaryUnit = militaryUnit.BuildUnit(rollableUnitId, null, null);
            var json = JsonConvert.SerializeObject(militaryUnit, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }

        [HttpGet("{rollableUnitId}/{ancestryId}")]
        public string Get(int rollableUnitId, int ancestryId)
        {
            MilitaryUnit militaryUnit = new MilitaryUnit();
            militaryUnit = militaryUnit.BuildUnit(rollableUnitId, ancestryId, null);
            var json = JsonConvert.SerializeObject(militaryUnit, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }

        [HttpGet("{rollableUnitId}/{ancestryId}/{subancestryId}")]
        public string Get(int rollableUnitId, int ancestryId, int subancestryId)
        {
            MilitaryUnit militaryUnit = new MilitaryUnit();
            militaryUnit = militaryUnit.BuildUnit(rollableUnitId, ancestryId, subancestryId);
            var json = JsonConvert.SerializeObject(militaryUnit, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }
    }
}