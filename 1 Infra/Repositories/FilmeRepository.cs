using FilmesAPI.DomainModel.Models;
using FilmesAPI.Infra.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Infra.Repositories
{
    public class FilmeRepository : AbstractRepository, IFilmeRepository
    {
        public FilmeRepository(AppDbContext context)
            : base(context) { }

        public async Task<Filme> Get(int id)
            => this.context.Filmes.FirstOrDefault(filme => filme.Id == id);

        public async Task<List<Filme>> GetReducedByFilter(int? classificacaoEtaria)
        {
            List<Filme> filmes;
            if (classificacaoEtaria == null)
                filmes = context.Filmes.ToList();
            else
                filmes = context.Filmes.Where(filme => filme.ClassificacaoEtaria <= classificacaoEtaria).ToList();

            if (filmes != null)
                return filmes;

            return null;
        }

        public async Task<Filme> Insert(Filme filme)
        {
            await base.Insert(filme);
            return filme;
        }

        public async Task<int> Update(Filme filme) 
            => await base.Update(filme);
        
        public async Task<int> Delete(Filme filme) 
            => await base.Delete(filme);
    }
}
