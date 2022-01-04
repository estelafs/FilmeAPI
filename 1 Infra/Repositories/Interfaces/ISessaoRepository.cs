using FilmesAPI.DomainModel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmesAPI.Infra.Repositories.Interfaces
{
    public interface ISessaoRepository
    {
        Task<Sessao> Get(int id);

        Task<List<Sessao>> Get();

        Task<List<Sessao>> GetCinemaEmSessao(int cinemaID, string nomeFilme);

        Task<List<Sessao>> GetSessoesCinema(string nomeCinema);

        Task<Sessao> Insert(Sessao sessao);

        Task<int> Update(Sessao sessao);

        Task<int> Delete(Sessao sessao);
    }
}
