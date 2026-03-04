namespace FilmesMoura1.WebAPI.DTO
{
    public class FilmeDTO
    {
        // ? = pode ser nulo ou não 
        public string? Titulo { get; set; }
        public IFormFile? Imagem { get; set; }
        public Guid? IdGenero { get; set; }
    }
}