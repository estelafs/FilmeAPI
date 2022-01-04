using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.DomainModel.Request.RequestCinema
{
    public class CreateCinemaRequestFull
    {
        [Required(ErrorMessage = "O campo de nome do Cinema é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo logradouro do endereço é obrigatório")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O campo bairro do endereço é obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo numero do endereço é obrigatório")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o gerente")]
        public string Gerente { get; set; }
    }
}
