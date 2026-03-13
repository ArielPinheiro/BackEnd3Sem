using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO
{
    public class UsuarioDTO
    {
        [Required(ErrorMessage = "O Nome usuario é obrigatorio")]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "O Email do usuario é obrigatorio")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "A Senha do usuario é obrigatorio")]
        public string? Senha { get; set; }
        public Guid IdTipoUsuario { get; set; }

    }
}
