using Microsoft.AspNetCore.Mvc;
using MoviesApi.Logic;
using MoviesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MoviesApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MetaDataController : ControllerBase
    {
        private MovieLogic MovieLogic { get; }
        public MetaDataController(MovieLogic movieLogic)
        {
            MovieLogic = movieLogic;
        }

        [HttpGet("{movieId}")]
        public async Task<ActionResult<List<Metadata>>> Get(int movieId)
        {
            List<Metadata> movies = await MovieLogic.GetByMovieId(movieId);

            if (movies.Count == 0)
                return StatusCode((int)HttpStatusCode.NotFound);

            return Ok(movies);
        }
     
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Metadata newMovie)
        {
            await MovieLogic.CreateMovie(newMovie);
            return Ok();
        }     
    }
}
