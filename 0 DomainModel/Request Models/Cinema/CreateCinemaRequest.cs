using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.DomainModel.Request.RequestCinema
{
    public class CreateCinemaRequest
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o Id do endereço")]
        public int EnderecoId { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o Id do gerente")]
        public int GerenteId { get; set; }
    }
}
