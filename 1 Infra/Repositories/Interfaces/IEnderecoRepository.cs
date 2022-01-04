using FilmesAPI.DomainModel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmesAPI.Infra.Repositories.Interfaces
{
    public interface IEnderecoRepository
    {
        Task<Endereco> Get(int id);

        Task<IEnumerable<Endereco>> Get();

        Task<Endereco> Insert(Endereco endereco);

        Task<int> Update(Endereco endereco);

        Task<int> Delete(Endereco endereco);
    }
}
