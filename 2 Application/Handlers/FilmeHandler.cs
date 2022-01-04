using AutoMapper;
using FilmesAPI.DomainModel.Request.RequestFilmes;
using FilmesAPI.Application.Handlers.Interfaces;
using FilmesAPI.DomainModel.Models;
using FilmesAPI.Infra.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmesAPI.Application.Handlers
{
    public class FilmeHandler : IFilmeHandler
    {
        private readonly IMapper mapper;
        private readonly IFilmeRepository filmeRepositorio;

        public FilmeHandler(IMapper mapper, IFilmeRepository filmeRepositorio)
        {
            this.mapper = mapper;
            this.filmeRepositorio = filmeRepositorio;
        }

        public async Task<Filme> Adiciona(CreateFilmeRequest filmeRequest)
        {
            var filme = mapper.Map<Filme>(filmeRequest);
            return await this.filmeRepositorio.Insert(filme);
        }

        public async Task<int> Atualiza(int id, UpdateFilmeRequest filmeRequest)
        {
            var filme = await this.filmeRepositorio.Get(id);

            this.mapper.Map(filmeRequest, filme);

            if (filme == null)
                return 0;

            return await this.filmeRepositorio.Update(filme);
        }

        public async Task<int> Deleta(int id)
        {
            var filme = await this.filmeRepositorio.Get(id);

            if (filme == null)
                return 0;

            return await this.filmeRepositorio.Delete(filme);
        }

        public async Task<List<ReadFilmeRequest>> RecuperaFilmes(int? classificacaoEtaria)
        {
            var filmes = await this.filmeRepositorio.GetReducedByFilter(classificacaoEtaria);

            if (filmes != null)
                return this.mapper.Map<List<ReadFilmeRequest>>(filmes);

            return null;
        }

        public async Task<ReadFilmeRequest> RecuperaFilmesPorId(int id)
        {
            var filme = await this.filmeRepositorio.Get(id);

            if (filme == null)
                return null;

            var filmeRequest = mapper.Map<ReadFilmeRequest>(filme);
            return filmeRequest;

        }
    }
}
