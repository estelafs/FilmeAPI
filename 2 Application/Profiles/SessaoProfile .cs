using AutoMapper;
using FilmesAPI.DomainModel.Request.RequestSessao;
using FilmesAPI.DomainModel.Models;

namespace FilmesAPI.Application.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoRequest, Sessao>();
            CreateMap<Sessao, ReadSessaoRequest>()
                .ForMember(request => request.HorarioDeInicio, opts => opts
                .MapFrom(request =>
                request.HorarioDeEncerramento.AddMinutes(request.Filme.Duracao * (-1))));
            CreateMap<UpdateSessaoRequest, Sessao>();
        }
    }
}
