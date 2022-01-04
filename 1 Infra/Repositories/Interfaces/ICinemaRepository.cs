using FilmesAPI.DomainModel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmesAPI.Infra.Repositories.Interfaces
{
    public interface ICinemaRepository
    {
        Task<Cinema> Get(int id);

        Task<List<Cinema>> Get();

        Task<List<Cinema>> GetReducedByFilter(string nomeDoFilme);

        Task<Cinema> Insert(Cinema cinema);

        Task<int> Update(Cinema cinema);

        Task<int> Delete(Cinema cinema);
    }
}
