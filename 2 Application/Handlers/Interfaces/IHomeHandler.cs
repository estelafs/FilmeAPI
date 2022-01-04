using FilmesAPI.DomainModel.Request.RequestSessao;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmesAPI.Application.Handlers.Interfaces
{
    public interface IHomeHandler
    {
        Task<List<ReadSessaoRequest>> SessoesFilme(string nomeFilme);

        Task<List<ReadSessaoRequest>> SessoesCinema(string nomeCinema);
    }
}
