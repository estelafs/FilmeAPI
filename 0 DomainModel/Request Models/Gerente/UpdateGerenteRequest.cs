using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.DomainModel.Request.RequestGerente
{
    public class UpdateGerenteRequest
    {
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }
    }
}
