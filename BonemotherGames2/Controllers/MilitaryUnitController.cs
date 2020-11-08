using System.Text.Json;
using BonemotherGames2.Services;
using Microsoft.AspNetCore.Mvc;

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
            militaryUnit = militaryUnit.BuildUnit(rollableUnitId);
            return JsonSerializer.Serialize(militaryUnit);
        }
    }
}