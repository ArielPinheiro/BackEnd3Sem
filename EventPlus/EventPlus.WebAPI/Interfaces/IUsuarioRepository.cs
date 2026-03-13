using EventPlus.WebAPI.Models;
using FilmesMoura1.WebAPI.Controllers;

namespace EventPlus.WebAPI.Interfaces;

public interface IUsuarioRepository
{
    void Cadastrar(Usuario usuario);
    Usuario BuscarPorId(Guid IdUsuario);
    Usuario BuscarPorEmailESenha(string Email, string Senha);
}