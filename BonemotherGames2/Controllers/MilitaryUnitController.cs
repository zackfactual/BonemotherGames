﻿using System.Text.Json;
using BonemotherGames2.Services;
using Microsoft.AspNetCore.Mvc;

namespace BonemotherGames2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MilitaryUnitController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            MilitaryUnit unit = new MilitaryUnit();
            unit.ConstructRandomUnit(unit);
            return JsonSerializer.Serialize(unit);
        }
    }
}