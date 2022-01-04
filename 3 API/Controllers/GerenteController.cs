using FilmesAPI.DomainModel.Request.RequestGerente;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FilmesAPI.Application.Handlers.Interfaces;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        private readonly IGerenteHandler gerenteHandler;

        public GerenteController(IGerenteHandler gerenteHandler)
        {
            this.gerenteHandler = gerenteHandler;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionaGerente([FromBody] CreateGerenteRequest gerenteRequest)
        {
            var gerente = await this.gerenteHandler.Adiciona(gerenteRequest);

            return CreatedAtAction(nameof(RecuperaGerentesPorId), new { Id = gerente.Id }, gerente);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> RecuperaGerentesPorId(int id)
        {
            var gerenteRequest = await this.gerenteHandler.RecuperaGerentesPorId(id);

            if (gerenteRequest != null)
                return Ok(gerenteRequest);

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletaGerente(int id)
        {
            var gerente = await this.gerenteHandler.Deleta(id);

            if (gerente == 0)
                return NotFound();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizaGerente([FromRoute] int id, [FromBody] UpdateGerenteRequest gerenteRequest)
        {
            var gerente = await this.gerenteHandler.Atualiza(id, gerenteRequest);

            if (gerente == 0)
                return NotFound();

            return Ok();
        }
    }
}
