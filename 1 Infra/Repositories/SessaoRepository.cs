using FilmesAPI.DomainModel.Models;
using FilmesAPI.Infra.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Infra.Repositories
{
    public class SessaoRepository : AbstractRepository, ISessaoRepository
    {
        public SessaoRepository(AppDbContext context)
            : base(context) { }

        public async Task<Sessao> Get(int id) 
            => this.context.Sessoes.FirstOrDefault(sessao => sessao.Id == id);

        public async Task<List<Sessao>> Get()
            => this.context.Sessoes.ToList();

        public async Task<List<Sessao>> GetCinemaEmSessao(int cinemaID, string nomeFilme)
            => this.context.Sessoes.Where(sessao => sessao.Cinema.Id == cinemaID && sessao.Filme.Titulo == nomeFilme).ToList();

        public async Task<List<Sessao>> GetSessoesCinema(string nomeCinema)
            => this.context.Sessoes.Where(sessao => sessao.Cinema.Nome == nomeCinema).ToList();

        public async Task<Sessao> Insert(Sessao sessao)
        {
            await base.Insert(sessao);
            return sessao;
        }

        public async Task<int> Update(Sessao sessao)
            => await base.Update(sessao);

        public async Task<int> Delete(Sessao sessao)
            => await base.Delete(sessao);
    }
}
