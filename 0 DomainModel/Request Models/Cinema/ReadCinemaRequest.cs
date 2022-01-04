using System.ComponentModel.DataAnnotations;
using FilmesAPI.DomainModel.Models;

namespace FilmesAPI.DomainModel.Request.RequestCinema
{
    public class ReadCinemaRequest
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public Endereco Endereco { get; set; }

        public Gerente Gerente { get; set; }

        public object Sessoes { get; set; }
    }
}
