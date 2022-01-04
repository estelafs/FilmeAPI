using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.DomainModel.Request.RequestSessao
{
    public class UpdateSessaoRequest
    {
        [Required(ErrorMessage = "É obrigatório informar o novo horário de encerramento da sessão")]
        public DateTime HorarioDeEncerramento { get; set; }
    }
}
