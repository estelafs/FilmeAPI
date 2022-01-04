using FilmesAPI.DomainModel.Request.RequestFilmes;
using FilmesAPI.DomainModel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmesAPI.Application.Handlers.Interfaces
{
    public interface IFilmeHandler
    {
        Task<Filme> Adiciona(CreateFilmeRequest filmeRequest); //AdicionaFilme

        Task<ReadFilmeRequest> RecuperaFilmesPorId(int id); //RecuperaFilmesPorId

        Task<List<ReadFilmeRequest>> RecuperaFilmes(int? classificacaoEtaria); //RecuperaFilmes

        Task<int> Atualiza(int id, UpdateFilmeRequest filmeRequest); //AtualizaFilme

        Task<int> Deleta(int id); //DeletaFilme
    }
}
