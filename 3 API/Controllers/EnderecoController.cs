using FilmesAPI.DomainModel.Request.RequestEndereco;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using FilmesAPI.Application.Handlers.Interfaces;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoHandler enderecoHandler;

        public EnderecoController(IEnderecoHandler enderecoHandler)
        {
            this.enderecoHandler = enderecoHandler;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionaEndereco([FromBody] CreateEnderecoRequest enderecoRequest)
        {
            var endereco = await this.enderecoHandler.Adiciona(enderecoRequest);

            return CreatedAtAction(nameof(RecuperaEnderecosPorId), new { Id = endereco.Id }, endereco);
        }

        [HttpGet]
        public async Task<List<ReadEnderecoRequest>> RecuperaEnderecos()
            => await this.enderecoHandler.RecuperaEnderecos();

        [HttpGet("{id}")]
        public async Task<IActionResult> RecuperaEnderecosPorId([FromRoute] int id)
        {
            var enderecoRequest = await this.enderecoHandler.RecuperaEnderecosPorId(id);

            if (enderecoRequest != null)
                return Ok(enderecoRequest);

            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizaEndereco([FromRoute] int id, [FromBody] UpdateEnderecoRequest enderecoRequest)
        {
            var endereco = await this.enderecoHandler.Atualiza(id, enderecoRequest);

            if (endereco == 0)
                return NotFound();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletaEndereco([FromRoute] int id)
        {
            var endereco = await this.enderecoHandler.Deleta(id);

            if (endereco == 0)
                return NotFound();

            return Ok();
        }
    }
}
