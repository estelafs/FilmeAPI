using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.DomainModel.Request.RequestEndereco
{
    public class CreateEnderecoRequest
    {
        [Required(ErrorMessage = "O campo logradouro é obrigatório")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O campo bairro é obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo numero é obrigatório")]
        public int Numero { get; set; }
    }
}
