using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BonemotherGames2.Models;
using BonemotherGames2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BonemotherGames2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IRetainerController : ControllerBase
    {
        private readonly ILogger<IRetainerController> _logger;
        private readonly IRetainer _retainer;
        public IRetainerController(ILogger<IRetainerController> logger,
            IRetainer retainer)
        {
            _logger = logger;
            _retainer = retainer;
        }

        [HttpGet]
        public IEnumerable<Retainer> Get()
        {
            List<Retainer> retainers = new List<Retainer>();

            Retainer retainer1 = new Retainer();
            retainer1.RetainerClass = _retainer.GetRandomRetainerClass();
            retainer1.Ancestry = _retainer.GetRandomAncestry();
            retainer1.Name = _retainer.GetRandomName(retainer1.Ancestry);

            Retainer retainer2 = new Retainer();
            retainer2.RetainerClass = _retainer.GetRandomRetainerClass();
            retainer2.Ancestry = _retainer.GetRandomAncestry();
            retainer2.Name = _retainer.GetRandomName(retainer2.Ancestry);

            retainers.Add(retainer1);
            retainers.Add(retainer2);
            return retainers;
        }
    }
}