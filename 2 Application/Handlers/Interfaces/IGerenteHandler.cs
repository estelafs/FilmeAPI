using FilmesAPI.DomainModel.Request.RequestGerente;
using FilmesAPI.DomainModel.Models;
using System.Threading.Tasks;

namespace FilmesAPI.Application.Handlers.Interfaces
{
    public interface IGerenteHandler
    {
        Task<Gerente> Adiciona(CreateGerenteRequest gerenteRequest); //AdicionaGerente

        Task<ReadGerenteRequest> RecuperaGerentesPorId(int id); //RecuperaGerentesPorId

        Task<int> Atualiza(int id, UpdateGerenteRequest gerenteRequest); //AtualizaGerente

        Task<int> Deleta(int id); //DeletaGerente
    }
}
