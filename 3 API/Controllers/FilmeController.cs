using FilmesAPI.DomainModel.Request.RequestFilmes;
using FilmesAPI.Application.Handlers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] // define q a rota para acessa a API será sempre 'nome' + 'Controller', ou seja, FilmeController
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeHandler filmeHandler;

        public FilmeController(IFilmeHandler filmeHandler)
        {
            this.filmeHandler = filmeHandler;
        }

        [HttpPost] //criando um recurso novo no nosso sistema
        public async Task<IActionResult> AdicionaFilme([FromBody] CreateFilmeRequest filmeRequest) //o [FromBody] prepara a API pra receber requisições
        {
            var filme = await this.filmeHandler.Adiciona(filmeRequest);

            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = filme.Id }, filme); //vamos executar o RecuperaFilmesPorId com o id do filme que acabamos de criar pra retornar o filme criado e a localização de onde ele pode ser encontrado no nisso sistema
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> RecuperaFilmesPorId([FromRoute] int id)
        {
            var filmeRequest = await this.filmeHandler.RecuperaFilmesPorId(id);

            if (filmeRequest != null)
                return Ok(filmeRequest);

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> RecuperaFilmes([FromQuery] int? classificacaoEtaria = null)
        {
            var filmeRequest = await this.filmeHandler.RecuperaFilmes(classificacaoEtaria);

            if (filmeRequest != null)
                return Ok(filmeRequest);

            return NotFound();
        }

        [HttpPut("{id}")] //put é o  verbo especifico pra atualização de algum recurso dentro do nosso sistema
        public async Task<IActionResult> AtualizaFilme([FromRoute] int id, [FromBody] UpdateFilmeRequest filmeRequest)
        {
            var filme = await this.filmeHandler.Atualiza(id, filmeRequest);

            if (filme == 0)
                return NotFound();

            return Ok(); //boa pratica pra  requisição de atualização : não retorna o recurso mas tb não retorna informação nenhuma
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletaFilme([FromRoute] int id)
        {
            var filme = await this.filmeHandler.Deleta(id);

            if (filme == 0)
                return NotFound();

            return Ok();
        }
    }
}
