using AutoMapper;
using FilmesAPI.DomainModel.Request.RequestFilmes;
using FilmesAPI.DomainModel.Models;

namespace FilmesAPI.Application.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeRequest, Filme>();
            CreateMap<Filme, ReadFilmeRequest>();
            CreateMap<UpdateFilmeRequest, Filme>();
        }
    }
}
