using FilmesAPI.DomainModel.Models;
using System.Threading.Tasks;

namespace FilmesAPI.Infra.Repositories.Interfaces
{
    public interface IGerenteRepository
    {
        Task<Gerente> Get(int id);

        Task<Gerente> Insert(Gerente gerente);

        Task<int> Update(Gerente gerente);

        Task<int> Delete(Gerente gerente);
    }
}
