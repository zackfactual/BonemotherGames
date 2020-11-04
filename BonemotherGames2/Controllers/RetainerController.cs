using System.Collections.Generic;
using System.Text.Json;
using BonemotherGames.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BonemotherGames.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RetainerController : ControllerBase
    {
        private readonly ILogger<RetainerController> _logger;

        public RetainerController(ILogger<RetainerController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            List<Retainer> retainers = new List<Retainer>();

            Retainer retainer = new Retainer();
            retainer.RetainerClass = retainer.GetRandomRetainerClass();
            retainer.Ancestry = retainer.GetRandomAncestry();
            retainer.Name = retainer.GetRandomName();
            retainer.PrimaryAbilities = retainer.GetPrimaryAbilities(retainer.RetainerClass);
            retainer.Saves = retainer.GetSaves(retainer.RetainerClass);
            retainer.Skills = retainer.GetSkills(retainer.RetainerClass);
            retainer.Actions = retainer.GetRetainerActions(retainer.RetainerClass);

            retainers.Add(retainer);
            return JsonSerializer.Serialize(retainers);
        }
    }
}
