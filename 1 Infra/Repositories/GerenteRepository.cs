using FilmesAPI.DomainModel.Models;
using FilmesAPI.Infra.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Infra.Repositories
{
    public class GerenteRepository : AbstractRepository, IGerenteRepository
    {
        public GerenteRepository(AppDbContext context)
            : base(context) { }

        public async Task<int> Delete(Gerente gerente)
            => await base.Delete(gerente);

        public async Task<Gerente> Get(int id)
            => this.context.Gerentes.FirstOrDefault(gerente => gerente.Id == id);

        public async Task<Gerente> Insert(Gerente gerente)
        {
            await base.Insert(gerente);
            return gerente;
        }

        public async Task<int> Update(Gerente gerente)
            => await base.Update(gerente);
    }
}
