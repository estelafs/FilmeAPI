using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.DomainModel.Request.RequestEndereco
{
    public class ReadEnderecoRequest
    {
        [Key]
        public int Id { get; set; }

        public string Logradouro { get; set; }
        
        public string Bairro { get; set; }
        
        public int Numero { get; set; }
    }
}
