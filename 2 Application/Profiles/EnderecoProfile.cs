using AutoMapper;
using FilmesAPI.DomainModel.Request.RequestEndereco;
using FilmesAPI.DomainModel.Models;

namespace FilmesAPI.Application.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoRequest, Endereco>();
            CreateMap<Endereco, ReadEnderecoRequest>();
            CreateMap<UpdateEnderecoRequest, Endereco>();
        }
    }
}
