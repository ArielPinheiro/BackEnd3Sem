using ConnectPlus.Models;
using ConnectPlus.Repositories;

namespace ConnectPlus.Interfaces
{
    public interface IContatoRepository
    {
        void Cadastrar(Contato contato);
        void Deletar (Guid Id);
        void Atualizar (Guid Id, Contato contato);
        List<Contato> Listar ();
        Contato BuscarPorIdContato(Guid Id);
    }
}
