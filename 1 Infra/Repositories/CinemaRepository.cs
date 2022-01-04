using FilmesAPI.DomainModel.Models;
using FilmesAPI.Infra.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Infra.Repositories
{
    public class CinemaRepository : AbstractRepository, ICinemaRepository
    {
        public CinemaRepository(AppDbContext context)
            : base(context) { }
        
        public async Task<Cinema> Get(int id)
            => this.context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

        public async Task<List<Cinema>> Get()
            => this.context.Cinemas.ToList();

        public async Task<List<Cinema>> GetReducedByFilter(string nomeDoFilme)
        {
            var cinemas = await this.Get();

            if (cinemas == null)
                return null;

            if (!string.IsNullOrEmpty(nomeDoFilme))
            {
                IEnumerable<Cinema> query = from cinema in cinemas
                                            where cinema.Sessoes.Any(sessao =>
                                            sessao.Filme.Titulo == nomeDoFilme)
                                            select cinema;

                cinemas = query.ToList();
            }

            return cinemas;
        }

        public async Task<Cinema> Insert(Cinema cinema)
        {
            await base.Insert(cinema);
            return cinema;
        }

        public async Task<int> Update(Cinema cinema)
            => await base.Update(cinema);

        public async Task<int> Delete(Cinema cinema)
            => await base.Delete(cinema);
    }
}
