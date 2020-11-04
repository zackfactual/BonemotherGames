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
            Retainer retainer = new Retainer();
            retainer.RetainerClass = retainer.GetRandomRetainerClass();
            retainer.ConstructRetainer(retainer);

            return JsonSerializer.Serialize(retainer);
        }

        //[HttpGet]
        //public string Get()
        //{
        //    List<Retainer> retainers = new List<Retainer>();
        //    using (var ctx = new BonemotherGamesContext())
        //    {
        //        var retainerClasses = ctx.RetainerClass.ToList();
        //        foreach (var retainerClass in retainerClasses)
        //        {
        //            var retainer = new Retainer();
        //            retainer.ConstructRetainer(retainer, retainerClass.RetainerClassId);
        //            retainers.Add(retainer);
        //        }
        //    }

        //    return JsonSerializer.Serialize(retainers);
        //}

        [HttpGet("{retainerClassId}")]
        public string Get(int retainerClassId)
        {
            Retainer retainer = new Retainer();
            retainer.RetainerClass = retainer.GetRetainerClass(retainerClassId);
            retainer.ConstructRetainer(retainer);

            return JsonSerializer.Serialize(retainer);
        }
    }
}