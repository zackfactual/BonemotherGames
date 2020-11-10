using System.Linq;
using System.Text.Json;
using BonemotherGames2.Entities;
using BonemotherGames2.Services;
using Microsoft.AspNetCore.Mvc;

namespace BonemotherGames2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NameController : ControllerBase
    {
        [HttpGet("{ancestryId}")]
        public string Get(int ancestryId) 
        { 
            return JsonSerializer.Serialize(CharacterNameGenerator.GetRandomAncestralName(ancestryId, null));
        }

        [HttpGet("{ancestryId}/{subancestryId}")]
        public string Get(int ancestryId, int subancestryId)
        {
            return JsonSerializer.Serialize(CharacterNameGenerator.GetRandomAncestralName(ancestryId, subancestryId));
        }
    }
}