using Microsoft.AspNetCore.Mvc;
using MoviesApi.Logic;
using MoviesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace MoviesApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private MovieLogic MovieLogic { get; }
        public MoviesController(MovieLogic movieLogic)
        {
            MovieLogic = movieLogic;
        }

        [HttpGet("Stats")]
        public async Task<ActionResult<List<Movie>>> Get()
        {
            
            List<Movie> movieStats = await MovieLogic.GetAllStats();
            return Ok(movieStats);
        }

    }
}
