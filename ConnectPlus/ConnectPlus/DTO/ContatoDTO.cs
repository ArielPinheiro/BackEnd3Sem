namespace ConnectPlus.DTO
{
    public class ContatoDTO
    {
        public Guid IdContato { get; set; }
        public string Nome { get; set; } = null!;
        public string FormaContato { get; set; } = null!;
        public string Imagem { get; set; } = null!;
        public Guid IdTipoContato { get; set; }
    }
}
