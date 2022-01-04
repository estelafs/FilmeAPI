using AutoMapper;
using FilmesAPI.Application.Handlers.Interfaces;
using FilmesAPI.DomainModel.Request.RequestEndereco;
using FilmesAPI.DomainModel.Models;
using FilmesAPI.Infra.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmesAPI.Application.Handlers
{
    public class EnderecoHandler : IEnderecoHandler
    {
        private readonly IMapper mapper;
        private readonly IEnderecoRepository enderecoRepositorio;

        public EnderecoHandler(IMapper mapper, IEnderecoRepository enderecoRepositorio)
        {
            this.mapper = mapper;
            this.enderecoRepositorio = enderecoRepositorio;
        }

        public async Task<Endereco> Adiciona(CreateEnderecoRequest enderecoRequest)
        {
            var endereco = mapper.Map<Endereco>(enderecoRequest);
            return await this.enderecoRepositorio.Insert(endereco);
        }

        public async Task<int> Atualiza(int id, UpdateEnderecoRequest enderecoRequest)
        {
            var endereco = await this.enderecoRepositorio.Get(id);

            if (endereco == null)
                return 0;

            this.mapper.Map(enderecoRequest, endereco);

            return await this.enderecoRepositorio.Update(endereco);
        }

        public async Task<int> Deleta(int id)
        {
            var endereco = await this.enderecoRepositorio.Get(id);

            if (endereco == null)
                return 0;

            return await this.enderecoRepositorio.Delete(endereco);
        }

        public async Task<List<ReadEnderecoRequest>> RecuperaEnderecos()
        {
            var enderecos = await this.enderecoRepositorio.Get();

            List<ReadEnderecoRequest> enderecosRequest = new List<ReadEnderecoRequest>();
            foreach (Endereco e in enderecos)
                enderecosRequest.Add(this.mapper.Map<ReadEnderecoRequest>(e));

            return enderecosRequest;
        }

        public async Task<ReadEnderecoRequest> RecuperaEnderecosPorId(int id)
        {
            var endereco = await this.enderecoRepositorio.Get(id);

            if (endereco == null)
                return null;

            var enderecoRequest = mapper.Map<ReadEnderecoRequest>(endereco);
            return enderecoRequest;
        }
    }
}

