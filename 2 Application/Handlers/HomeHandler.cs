using FilmesAPI.Application.Handlers.Interfaces;
using FilmesAPI.DomainModel.Request.RequestCinema;
using FilmesAPI.DomainModel.Request.RequestSessao;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmesAPI.Application.Handlers
{
    public class HomeHandler : IHomeHandler
    {
        private readonly IFilmeHandler filmeHandler;
        private readonly IGerenteHandler gerenteHandler;
        private readonly IEnderecoHandler enderecoHandler;
        private readonly ICinemaHandler cinemaHandler;
        private readonly ISessaoHandler sessaoHandle;


        public HomeHandler(
            IFilmeHandler filmeHandler,
            IGerenteHandler gerenteHandler,
            IEnderecoHandler enderecoHandler,
            ICinemaHandler cinemaHandler,
            ISessaoHandler sessaoHandle)
        {
            this.filmeHandler = filmeHandler;
            this.gerenteHandler = gerenteHandler;
            this.enderecoHandler = enderecoHandler;
            this.cinemaHandler = cinemaHandler;
            this.sessaoHandle = sessaoHandle;
        }

        public async Task<List<ReadSessaoRequest>> SessoesFilme(string nomeFilme)
        {
            var cinemasComSessao = await this.cinemaHandler.RecuperaCinemas(nomeFilme);

            if (cinemasComSessao == null)
                return null;

            List<ReadSessaoRequest> sessoesRequest = new List<ReadSessaoRequest>();

            foreach (ReadCinemaRequest cinema in cinemasComSessao)
                sessoesRequest.AddRange(await this.sessaoHandle.RecuperaSessaoPorFilmeCinema(cinema.Id, nomeFilme));

            return sessoesRequest;
        }

        public async Task<List<ReadSessaoRequest>> SessoesCinema(string nomeCinema)
        {
            var sessoesDoCinema = await this.sessaoHandle.RecuperaSessaoPorCinema(nomeCinema);

            if (sessoesDoCinema == null)
                return null;

            return sessoesDoCinema;
        }
    }
}
