using FilmesAPI.DomainModel.Request.RequestCinema;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using FilmesAPI.Application.Handlers.Interfaces;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private readonly ICinemaHandler cinemaHandler;

        public CinemaController(ICinemaHandler cinemaHandler)
        {
            this.cinemaHandler = cinemaHandler;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionaCinema([FromBody] CreateCinemaRequestFull cinemaRequestFull)
        {
            var cinema = await this.cinemaHandler.Adiciona(cinemaRequestFull);

            return CreatedAtAction(nameof(RecuperaCinemasPorId), new { Id = cinema.Id }, cinema);
        }

        [HttpGet]
        public async Task<IActionResult> RecuperaCinemas([FromQuery] string nomeDoFilme) // retorno tb pode ser Task<ActionResult<Cinema>>
        {
            List<ReadCinemaRequest> cinemas = await this.cinemaHandler.RecuperaCinemas(nomeDoFilme);

            if (cinemas != null)
                return Ok(cinemas);

            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> RecuperaCinemasPorId([FromRoute] int id)
        {
            var cinemaRequest = await this.cinemaHandler.RecuperaCinemasPorId(id);

            if (cinemaRequest != null)
                return Ok(cinemaRequest);

            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizaCinema([FromRoute] int id, [FromBody] UpdateCinemaRequestFull cinemaRequestFull)
        {
            var cinema = await this.cinemaHandler.Atualiza(id, cinemaRequestFull);

            if (cinema == 0)
                return NotFound();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletaCinema([FromRoute] int id)
        {
            var cinema = await this.cinemaHandler.Deleta(id);

            if (cinema == 0)
                return NotFound();

            return Ok();
        }
    }
}
