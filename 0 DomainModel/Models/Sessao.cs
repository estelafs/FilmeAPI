using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.DomainModel.Models
{
    public class Sessao
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public virtual Cinema Cinema { get; set; } //é virtual pra ser carregada de maneira lazy

        [Required]
        public int CinemaId { get; set; }

        [Required]
        public virtual Filme Filme { get; set; }

        [Required]
        public int FilmeId { get; set; }

        [Required]
        public DateTime HorarioDeEncerramento { get; set; }
    }
}
