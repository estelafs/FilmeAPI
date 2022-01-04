using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.DomainModel.Request.RequestFilmes
{
    public class CreateFilmeRequest
    {
        [Required(ErrorMessage = "O campo título é obrigatório!")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo diretor é obrigatório!")]
        public string Diretor { get; set; }

        [Required(ErrorMessage = "O campo genêro é obrigatório!")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "O campo duração é obrigatório!")]
        public int Duracao { get; set; }

        [Required(ErrorMessage = "O campo classificação etária é obrigatório")]
        public int ClassificacaoEtaria { get; set; }
    }
}
