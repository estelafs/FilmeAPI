using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesAPI.DomainModel.Models
{
    public class Filme
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage ="O campo título é obrigatório!")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo diretor é obrigatório!")]
        public string Diretor { get; set; }

        [Required(ErrorMessage = "O campo genêro é obrigatório!")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "O campo duração é obrigatório!")]
        public int Duracao { get; set; }

        [Required(ErrorMessage = "O campo classificação etária é obrigatório!")]
        public int ClassificacaoEtaria { get; set; }

        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; }

    }
}
