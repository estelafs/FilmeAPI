using FilmesAPI.DomainModel.Request.RequestCinema;
using FilmesAPI.DomainModel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmesAPI.Application.Handlers.Interfaces
{
    public interface ICinemaHandler
    {
        Task<Cinema> Adiciona(CreateCinemaRequestFull cinemaRequestFull); //AdicionaCinema

        Task<ReadCinemaRequest> RecuperaCinemasPorId(int id); //RecuperaCinemasPorId

        Task<List<ReadCinemaRequest>> RecuperaCinemas(string nomeDoFilme); //RecuperaCinemas

        Task<int> Atualiza(int id, UpdateCinemaRequestFull cinemaRequestFull); //AtualizaCinema

        Task<int> Deleta(int id); //DeletaCinema
    }
}
