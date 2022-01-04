using FilmesAPI.DomainModel.Models;
using FilmesAPI.Infra.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Infra.Repositories
{
    public class EnderecoRepository : AbstractRepository, IEnderecoRepository
    {
        public EnderecoRepository(AppDbContext context)
            : base(context) { }

        public async Task<Endereco> Get(int id) 
            => this.context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);

        public async Task<IEnumerable<Endereco>> Get() 
            => this.context.Enderecos;

        public async Task<Endereco> Insert(Endereco endereco)
        {
            await base.Insert(endereco);
            return endereco;
        }

        public async Task<int> Update(Endereco endereco)
            => await base.Update(endereco);

        public async Task<int> Delete(Endereco endereco)
            => await base.Delete(endereco);
    }
}
