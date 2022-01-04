using System.Collections.Generic;
using System.Threading.Tasks;
using FilmesAPI.DomainModel.Models;

namespace FilmesAPI.Infra.Repositories.Interfaces
{
    public interface IFilmeRepository
    {
        Task<Filme> Get(int id);

        Task<List<Filme>> GetReducedByFilter(int? classificacaoEtaria);

        Task<Filme> Insert(Filme filme);

        Task<int> Update(Filme filme);

        Task<int> Delete(Filme filme);
    }
}
