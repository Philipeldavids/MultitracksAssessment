using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Multitracks.Repository;
using System.Net.Http;
using System.Net;
using System;
using Multitracks.Models;
using System.Threading.Tasks;
using Multitracks.Services;
using Multitracks.Interface;

namespace Multitracks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;
        public ArtistController(IArtistService artistService)
        {
            _artistService = artistService;
        }


        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> GetArtistByName(string name)
        { 
            try
            {
                var artist = await _artistService.GetArtistByName(name);
                return Ok(artist);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("Add")]

        public async Task<IActionResult> AddArtist(Artist artist)
        {
            try
            {
                var result = await _artistService.AddArtist(artist);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
