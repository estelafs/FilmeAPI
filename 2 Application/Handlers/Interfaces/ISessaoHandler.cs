using FilmesAPI.DomainModel.Request.RequestSessao;
using FilmesAPI.DomainModel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmesAPI.Application.Handlers.Interfaces
{
    public interface ISessaoHandler
    {
        Task<Sessao> Adiciona(CreateSessaoRequest sessaoRequest); //AdicionaSessao

        Task<ReadSessaoRequest> RecuperaSessoesPorId(int id); //RecuperaSessoesPorId

        Task<List<ReadSessaoRequest>> RecuperaSessoes();

        Task<int> Atualiza(int id, UpdateSessaoRequest sessaoRequest); //AtualizaSessao

        Task<int> Deleta(int id); //DeletaSessao

        Task<List<ReadSessaoRequest>> RecuperaSessaoPorFilmeCinema(int cinemaID, string nomeFilme);

        Task<List<ReadSessaoRequest>> RecuperaSessaoPorCinema(string nomeCinema);
    }
}
