using AutoMapper;
using FilmesAPI.DomainModel.Request.RequestCinema;
using FilmesAPI.DomainModel.Models;
using System.Linq;

namespace FilmesAPI.Application.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile() 
        {
            CreateMap<CreateCinemaRequest, Cinema>();
            CreateMap<Cinema, ReadCinemaRequest>().
                ForMember(cinema => cinema.Sessoes, opts => opts.
                MapFrom(cinema => cinema.Sessoes.
                Select(s => new { s.FilmeId })));
            CreateMap<UpdateCinemaRequest, Cinema>();
        }
    }
}
