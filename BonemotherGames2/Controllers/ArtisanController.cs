﻿using System.Text.Json;
using BonemotherGames2.Services;
using Microsoft.AspNetCore.Mvc;

namespace BonemotherGames2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArtisanController : ControllerBase
    {
        [HttpGet("{artisanLookupId}")]
        public string Get(int artisanLookupId)
        {
            Artisan artisan = new Artisan();
            artisan = artisan.ConstructArtisan(artisanLookupId);
            return JsonSerializer.Serialize(artisan);
        }
    }
}