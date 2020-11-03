using System.Collections.Generic;
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
        public IEnumerable<Retainer> Get()
        {
            List<Retainer> retainers = new List<Retainer>();

            Retainer retainer1 = new Retainer();
            retainer1.RetainerClass = retainer1.GetRandomRetainerClass();
            retainer1.Ancestry = retainer1.GetRandomAncestry();
            retainer1.Name = retainer1.GetRandomName();

            Retainer retainer2 = new Retainer();
            retainer2.RetainerClass = retainer2.GetRandomRetainerClass();
            retainer2.Ancestry = retainer2.GetRandomAncestry();
            retainer2.Name = retainer2.GetRandomName();

            retainers.Add(retainer1);
            retainers.Add(retainer2);
            return retainers;
        }
    }
}
