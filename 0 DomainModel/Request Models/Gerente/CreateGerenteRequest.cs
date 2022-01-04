using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.DomainModel.Request.RequestGerente
{
    public class CreateGerenteRequest
    {
        [Required]
        public string Nome { get; set; }

    }
}
