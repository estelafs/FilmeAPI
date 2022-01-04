using AutoMapper;
using FilmesAPI.Application.Handlers.Interfaces;
using FilmesAPI.DomainModel.Request.RequestSessao;
using FilmesAPI.DomainModel.Models;
using FilmesAPI.Infra.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmesAPI.Application.Handlers
{
    public class SessaoHandler : ISessaoHandler
    {
        private readonly IMapper mapper;
        private readonly ISessaoRepository sessaoRepositorio;

        public SessaoHandler(IMapper mapper, ISessaoRepository sessaoRepositorio)
        {
            this.mapper = mapper;
            this.sessaoRepositorio = sessaoRepositorio;
        }

        public async Task<Sessao> Adiciona(CreateSessaoRequest sessaoRequest)
        {
            var sessao = mapper.Map<Sessao>(sessaoRequest);
            return await this.sessaoRepositorio.Insert(sessao);
        }

        public async Task<List<ReadSessaoRequest>> RecuperaSessoes()
        {
            var sessoes = await this.sessaoRepositorio.Get();

            List<ReadSessaoRequest> sessoesRequest = new List<ReadSessaoRequest>();

            foreach (Sessao s in sessoes)
                sessoesRequest.Add(this.mapper.Map<ReadSessaoRequest>(s));

            return sessoesRequest;
        }

        public async Task<ReadSessaoRequest> RecuperaSessoesPorId(int id)
        {
            var sessao = await this.sessaoRepositorio.Get(id);

            if (sessao == null)
                return null;

            var sessaoRequest = mapper.Map<ReadSessaoRequest>(sessao);
            return sessaoRequest;
        }

        public async Task<List<ReadSessaoRequest>> RecuperaSessaoPorFilmeCinema(int cinemaID, string nomeFilme)
        {
            var sessoes = await this.sessaoRepositorio.GetCinemaEmSessao(cinemaID, nomeFilme);
         
            List<ReadSessaoRequest> sessoesRequest = new List<ReadSessaoRequest>();

            foreach (Sessao s in sessoes)
                sessoesRequest.Add(this.mapper.Map<ReadSessaoRequest>(s));

            return sessoesRequest;
        }

        public async Task<List<ReadSessaoRequest>> RecuperaSessaoPorCinema(string nomeCinema)
        {
            var sessoes = await this.sessaoRepositorio.GetSessoesCinema(nomeCinema);

            List<ReadSessaoRequest> sessoesRequest = new List<ReadSessaoRequest>();

            foreach (Sessao s in sessoes)
                sessoesRequest.Add(this.mapper.Map<ReadSessaoRequest>(s));

            return sessoesRequest;
        }

        public async Task<int> Atualiza(int id, UpdateSessaoRequest sessaoRequest)
        {
            var sessao = await this.sessaoRepositorio.Get(id);

            this.mapper.Map(sessaoRequest, sessao);

            if (sessao == null)
                return 0;

            return await this.sessaoRepositorio.Update(sessao);
        }

        public async Task<int> Deleta(int id)
        {
            var sessao = await this.sessaoRepositorio.Get(id);

            if (sessao == null)
                return 0;

            return await this.sessaoRepositorio.Delete(sessao);
        }
    }
}
