using FilmesAPI.DomainModel.Request.RequestEndereco;
using FilmesAPI.DomainModel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmesAPI.Application.Handlers.Interfaces
{
    public interface IEnderecoHandler
    {
        Task<Endereco> Adiciona(CreateEnderecoRequest enderecoRequest); //AdicionaEndereco

        Task<ReadEnderecoRequest> RecuperaEnderecosPorId(int id); //RecuperaEnderecosPorId

        Task<List<ReadEnderecoRequest>> RecuperaEnderecos(); //RecuperaEnderecos

        Task<int> Atualiza(int id, UpdateEnderecoRequest enderecoRequest); //AtualizaEndereco

        Task<int> Deleta(int id); //DeletaEndereco
    }
}
