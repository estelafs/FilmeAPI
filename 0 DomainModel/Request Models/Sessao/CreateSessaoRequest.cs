using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.DomainModel.Request.RequestSessao
{
    public class CreateSessaoRequest
    {
        [Required(ErrorMessage = "É obrigatório informar o Id do cinema")]
        public int CinemaId { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o Id do filme")]
        public int FilmeId { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o horário de encerramento da sessão")]
        public DateTime HorarioDeEncerramento { get; set; }
    }
}
