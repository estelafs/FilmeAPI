using AutoMapper;
using FilmesAPI.DomainModel.Request.RequestGerente;
using FilmesAPI.DomainModel.Models;
using System.Linq;

namespace FilmesAPI.Application.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteRequest, Gerente>();
            CreateMap<Gerente, ReadGerenteRequest>() //pra lista de cinemas gerenciados pelo gerente não retornar os dados do gerente junto
                .ForMember(gerente => gerente.Cinemas, opts => opts
                .MapFrom(gerente => gerente.Cinemas.Select
                (c => new { c.Id, c.Nome, c.Endereco, c.EnderecoId }))); //retorna da tabela cliente uma lista com os dados: Id, Nome, Endereco e EnderecoId
        }
    }
}
