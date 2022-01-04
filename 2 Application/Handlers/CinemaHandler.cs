using AutoMapper;
using FilmesAPI.Application.Handlers.Interfaces;
using FilmesAPI.DomainModel.Request.RequestCinema;
using FilmesAPI.DomainModel.Models;
using FilmesAPI.Infra.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using FilmesAPI.DomainModel.Request.RequestEndereco;
using FilmesAPI.DomainModel.Request.RequestGerente;

namespace FilmesAPI.Application.Handlers
{
    public class CinemaHandler : ICinemaHandler
    {
        private readonly IMapper mapper;
        private readonly ICinemaRepository cinemaRepositorio;
        private readonly IEnderecoHandler enderecoHandler;
        private readonly IGerenteHandler gerenteHandler;

        public CinemaHandler(
            IMapper mapper, 
            ICinemaRepository cinemaRepositorio, 
            IEnderecoHandler enderecoHandler,
            IGerenteHandler gerenteHandler)
        {
            this.mapper = mapper;
            this.cinemaRepositorio = cinemaRepositorio;
            this.enderecoHandler = enderecoHandler;
            this.gerenteHandler = gerenteHandler;
        }

        public async Task<Cinema> Adiciona(CreateCinemaRequestFull cinemaRequestFull)
        {
            int gerenteId;
            CreateCinemaRequest cinemaRequest;

            var enderecoRequest = new CreateEnderecoRequest
            {
                Logradouro = cinemaRequestFull.Logradouro,
                Bairro = cinemaRequestFull.Bairro,
                Numero = cinemaRequestFull.Numero
            };

            var endereco = await this.enderecoHandler.Adiciona(enderecoRequest);

            if (int.TryParse(cinemaRequestFull.Gerente, out gerenteId))
                cinemaRequest = new CreateCinemaRequest
                {
                    Nome = cinemaRequestFull.Nome,
                    EnderecoId = endereco.Id,
                    GerenteId = gerenteId
                };

            else
            {
                var gerenteRequest = new CreateGerenteRequest
                {
                    Nome = cinemaRequestFull.Gerente
                };

                var gerente = await this.gerenteHandler.Adiciona(gerenteRequest);

                cinemaRequest = new CreateCinemaRequest
                {
                    Nome = cinemaRequestFull.Nome,
                    EnderecoId = endereco.Id,
                    GerenteId = gerente.Id
                };
            }

            var cinema = mapper.Map<Cinema>(cinemaRequest);
            return await this.cinemaRepositorio.Insert(cinema);
        }

        public async Task<int> Atualiza(int id, UpdateCinemaRequestFull cinemaRequestFull)
        {
            var cinema = await this.cinemaRepositorio.Get(id);
            if (cinema == null) return 0;

            var enderecoRequest = new UpdateEnderecoRequest
            {
                Logradouro = cinemaRequestFull.Logradouro,
                Bairro = cinemaRequestFull.Bairro,
                Numero = cinemaRequestFull.Numero
            };

            var enderecoUpdate = await this.enderecoHandler.Atualiza(cinemaRequestFull.EnderecoId, enderecoRequest);
            if (enderecoUpdate == 0) return 0;

            int gerenteId;
            UpdateCinemaRequest cinemaRequest;

            if (int.TryParse(cinemaRequestFull.Gerente, out gerenteId))
                cinemaRequest = new UpdateCinemaRequest
                {
                    Nome = cinemaRequestFull.Nome,
                    EnderecoId = cinemaRequestFull.EnderecoId,
                    GerenteId = gerenteId
                };
            else
            {
                var gerenteRequest = new CreateGerenteRequest
                {
                    Nome = cinemaRequestFull.Gerente
                };

                var gerente = await this.gerenteHandler.Adiciona(gerenteRequest);

                cinemaRequest = new UpdateCinemaRequest
                {
                    Nome = cinemaRequestFull.Nome,
                    EnderecoId = cinemaRequestFull.EnderecoId,
                    GerenteId = gerente.Id
                };
            }

            cinema = this.mapper.Map<Cinema>(cinemaRequest);
            return await this.cinemaRepositorio.Update(cinema);
        }

        public async Task<int> Deleta(int id)
        {
            var cinema = await this.cinemaRepositorio.Get(id);

            if (cinema == null)
                return 0;

            return await this.cinemaRepositorio.Delete(cinema);
        }

        public async Task<List<ReadCinemaRequest>> RecuperaCinemas(string nomeDoFilme)
        {
            var cinemas = await this.cinemaRepositorio.GetReducedByFilter(nomeDoFilme);

            if (cinemas != null)
            {
                var cinemasRequest = this.mapper.Map<List<ReadCinemaRequest>>(cinemas);
                return cinemasRequest;
            }

            return null;
        }

        public async Task<ReadCinemaRequest> RecuperaCinemasPorId(int id)
        {
            var cinema = await this.cinemaRepositorio.Get(id);

            if (cinema == null)
                return null;

            var cinemaRequest = mapper.Map<ReadCinemaRequest>(cinema);
            return cinemaRequest;
        }
    }
}
