using FilmesAPI.DomainModel.Request.RequestSessao;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FilmesAPI.Application.Handlers.Interfaces;
using System.Collections.Generic;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private readonly ISessaoHandler sessaoHandler;

        public SessaoController(ISessaoHandler sessaoHandler)
        {
            this.sessaoHandler = sessaoHandler;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionaSessao([FromBody] CreateSessaoRequest sessaoRequest)
        {
            var sessao = await this.sessaoHandler.Adiciona(sessaoRequest);

            return CreatedAtAction(nameof(RecuperaSessoesPorId), new { Id = sessao.Id }, sessao);
        }

        [HttpGet]
        public async Task<List<ReadSessaoRequest>> RecuperaSessoes()
            => await this.sessaoHandler.RecuperaSessoes();

        [HttpGet("{id}")]
        public async Task<IActionResult> RecuperaSessoesPorId([FromRoute] int id)
        {
            var sessaoRequest = await this.sessaoHandler.RecuperaSessoesPorId(id);

            if (sessaoRequest != null)
                return Ok(sessaoRequest);

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletaSessao([FromRoute] int id)
        {
            var sessao = await this.sessaoHandler.Deleta(id);

            if (sessao == 0)
                return NotFound();

            return Ok();
        }

        [HttpPut("{id}")] 
        public async Task<IActionResult> AtualizaSessao([FromRoute] int id, [FromBody] UpdateSessaoRequest sessaoRequest)
        {
            var sessao = await this.sessaoHandler.Atualiza(id, sessaoRequest);

            if (sessao == 0)
                return NotFound();

            return Ok();
        }
    }
}
