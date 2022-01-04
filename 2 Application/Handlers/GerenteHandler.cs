using AutoMapper;
using FilmesAPI.Application.Handlers.Interfaces;
using FilmesAPI.DomainModel.Request.RequestGerente;
using FilmesAPI.DomainModel.Models;
using FilmesAPI.Infra.Repositories.Interfaces;
using System.Threading.Tasks;

namespace FilmesAPI.Application.Handlers
{
    public class GerenteHandler : IGerenteHandler
    {
        private readonly IMapper mapper;
        private readonly IGerenteRepository gerenteRepositorio;

        public GerenteHandler(IMapper mapper, IGerenteRepository gerenteRepositorio)
        {
            this.mapper = mapper;
            this.gerenteRepositorio = gerenteRepositorio;
        }

        public async Task<Gerente> Adiciona(CreateGerenteRequest gerenteRequest)
        {
            var gerente = mapper.Map<Gerente>(gerenteRequest);
            return await this.gerenteRepositorio.Insert(gerente);
        }

        public async Task<int> Atualiza(int id, UpdateGerenteRequest gerenteRequest)
        {
            var gerente = await this.gerenteRepositorio.Get(id);

            this.mapper.Map(gerenteRequest, gerente);

            if (gerente == null)
                return 0;

            return await this.gerenteRepositorio.Update(gerente);
        }

        public async Task<int> Deleta(int id)
        {
            var gerente = await this.gerenteRepositorio.Get(id);

            if (gerente == null)
                return 0;

            return await this.gerenteRepositorio.Delete(gerente);
        }

        public async Task<ReadGerenteRequest> RecuperaGerentesPorId(int id)
        {
            var gerente = await this.gerenteRepositorio.Get(id);

            if (gerente == null)
                return null;

            var gerenteRequest = mapper.Map<ReadGerenteRequest>(gerente);
            return gerenteRequest;
        }
    }
}
