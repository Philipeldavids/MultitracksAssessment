using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multitracks.Models;
using Multitracks.Repository;
using System.Collections.Generic;
using System;
using Microsoft.Extensions.Configuration;
using System.Linq;
using Multitracks.Services;
using Multitracks.Interface;

namespace Multitracks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        
        private readonly ISongService _songService;
        public SongController(ISongService songService)
        {
            _songService = songService;
        }

        [HttpGet]
        [Route("list")]
        public IActionResult GetAllSongs([FromQuery]PaginationFilter filter)
        {
            try
            {
                var pagedSongs = _songService.GetAllSongs(filter);

                return Ok(pagedSongs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
