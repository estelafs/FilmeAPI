using FilmesAPI.DomainModel.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.DomainModel.Request.RequestSessao
{
    public class ReadSessaoRequest
    {
        [Key]
        public int Id { get; set; }

        public Cinema Cinema { get; set; }
        
        public Filme Filme { get; set; }
        
        public DateTime HorarioDeEncerramento { get; set; }
        
        public DateTime HorarioDeInicio { get; set; }
    }
}
