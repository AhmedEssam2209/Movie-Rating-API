using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRateApp.Data;
using MovieRateApp.DTO;
using MovieRateApp.Models;
using MovieRateApp.Services;

namespace MovieRateApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _service;
        private readonly IMapper _mapper;

        public MovieController(IMovieService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Movie>))]

        public IActionResult GetMovies()
        {
            var movies = _mapper.Map<List<MovieDTO>>(_service.GetMovies());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(movies);
        }

        [HttpGet("{name}")]
        [ProducesResponseType(200, Type = typeof(Movie))]
        public IActionResult GetMovie(string name)
        {
            var movie = _mapper.Map<MovieDTO>(_service.Getmovie(name));
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(movie);
        }

        [HttpPost]
        [ProducesResponseType(204)]

        public IActionResult Createmovie([FromBody] MovieDTO mOvie)
        {
            if (mOvie == null)
                return BadRequest(ModelState);
            var movie = _service.GetMovies()
                .Where(m => m.Title.Trim().ToUpper() == mOvie.Title.Trim().ToUpper()).
                FirstOrDefault();
            if (movie != null)
            {
                ModelState.AddModelError("", "Movie already exists");
                return StatusCode(422, ModelState);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var MOvie = _mapper.Map<Movie>(mOvie);
            if (!_service.Createmovie(MOvie))
            {
                ModelState.AddModelError("", "Error happened while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("Movie Succesfully Added");
        }

        [HttpPut("{movieID}")]
        [ProducesResponseType(204)]

        public IActionResult Updatemovie(int movieID, [FromBody] MovieDTO updatedmovie)
        {
            if (updatedmovie == null)
                return BadRequest(ModelState);
            if (movieID != updatedmovie.ID)
                return BadRequest(ModelState);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var MOvie = _mapper.Map<Movie>(updatedmovie);
            if (!_service.Updatemovie(MOvie))
            {
                ModelState.AddModelError("", "Error happened while updating");
                return StatusCode(500, ModelState);
            }
            return Ok("Movie Succesfully Updated");
        }

        [HttpDelete]
        [ProducesResponseType(200)]
        public IActionResult Deletemovie(string name)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var movieTodelete = _service.Getmovie(name);
            if (!_service.Deletemovie(movieTodelete))
            {
                ModelState.AddModelError("", "Error happened while deleting");
                return StatusCode(500, ModelState);
            }
            return Ok("Movie Succesfully Deleted");
        }
    }

}
