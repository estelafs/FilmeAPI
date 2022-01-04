using FilmesAPI.Application.Handlers.Interfaces;
using FilmesAPI.DomainModel.Request.RequestSessao;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmesAPI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IHomeHandler homeHandler;

        public HomeController(IHomeHandler homeHandler)
        {
            this.homeHandler = homeHandler;
        }

        [HttpGet("{NomeFilme}")]
        public async Task<IActionResult> SessoesFilme([FromRoute] string nomeFilme)
        {
            var sessoesFilme = await this.homeHandler.SessoesFilme(nomeFilme);

            if (sessoesFilme == null)
                return NotFound();

            return Ok(sessoesFilme);
        }

        [HttpGet("SessoesCinema/{nomeCinema}")]
        public async Task<IActionResult> SessoesCinema([FromRoute] string nomeCinema)
        {
            var sessoesFilme = await this.homeHandler.SessoesCinema(nomeCinema);

            if (sessoesFilme == null)
                return NotFound();

            return Ok(sessoesFilme);
        }

        [HttpGet("FilmesCinema/{nomeCinema}")]
        public async Task<IActionResult> FilmesCinema([FromRoute] string nomeCinema)
        {
            var sessoesFilme = await this.homeHandler.SessoesCinema(nomeCinema);

            if (sessoesFilme == null)
                return NotFound();

            List<String> filmes = new List<string>();
            foreach (ReadSessaoRequest sessao in sessoesFilme)
                filmes.Add(sessao.Filme.Titulo + " - Horário sessão: " + sessao.HorarioDeInicio + " - Id sessão: " + sessao.Id);

            return Ok(filmes);
        }
    }
}
