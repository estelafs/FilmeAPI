
namespace FilmesAPI.DomainModel.Request.RequestGerente
{
    public class ReadGerenteRequest
    {
        public int Id { get; set; }
       
        public string Nome { get; set; }
       
        public object Cinemas { get; set; }
    }
}
