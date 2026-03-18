using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO
{
    public class LoginDTO : TipoUsuarioDTO
    {
        [Required(ErrorMessage = "O Email Do Usuario É Obrigatorio!")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "A Senha Do Usuario É Obrigatorio!")]
        public string? Senha { get; set; }
        [Required(ErrorMessage = "Informe seu tipo de usuario!")]
        public string? Titulo { get; set; }
    }
}
