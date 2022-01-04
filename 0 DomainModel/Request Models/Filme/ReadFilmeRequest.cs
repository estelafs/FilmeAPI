using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.DomainModel.Request.RequestFilmes
{
    public class ReadFilmeRequest
    {
        [Key]
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Diretor { get; set; }

        public string Genero { get; set; }

        public int Duracao { get; set; }

        public int ClassificacaoEtaria { get; set; }

        public DateTime HoraDaConsulta { get; set; }
    }
}
