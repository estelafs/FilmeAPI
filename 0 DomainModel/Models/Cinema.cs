﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmesAPI.DomainModel.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public virtual Endereco Endereco { get; set; }

        [Required]
        public int EnderecoId { get; set; }

        [Required]
        public virtual Gerente Gerente { get; set; }

        [Required]
        public int GerenteId { get; set; }

        [JsonIgnore]
        public virtual List<Sessao> Sessoes { get; set; }
    }
}
