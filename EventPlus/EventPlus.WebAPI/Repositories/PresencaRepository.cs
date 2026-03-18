using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories;

public class PresencaRepository : IPresencaRepository
{
    private readonly EventContext _context;
    public PresencaRepository(EventContext context)
    {
        _context = context;
    }
    /// <summary>
    /// Metodo que alterna a situação da presença 
    /// </summary>
    /// <param name="id">id da presenca a ser alterado</param>
    public void Atualizar(Guid id, Presenca presenca)
    {
        var presencaBuscada = _context.Presencas.Find(id);
        if (presencaBuscada != null)
        {
            presencaBuscada.Situacao = !presencaBuscada.Situacao;
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Metodo que busca uma presenca por ID 
    /// </summary>
    /// <param name="id">id da presenca a ser buscada</param>
    /// <returns>presenca buscada</returns>
    public Presenca BuscarPorId(Guid id)
    {
        return _context.Presencas.Include(p => p.IdEventoNavigation).ThenInclude(e => e!.IdInstituicaoNavigation).FirstOrDefault(p => p.IdPresenca == id)!;
    }

    public void Deletar(Guid id)
    {
        var presencaBuscada = _context.Presencas.Find(id);
            if (presencaBuscada != null) 
        {
            _context.Presencas.Remove(presencaBuscada);
            _context.SaveChanges();
        }
}

    public void Inscrever(Presenca presenca)
    {
        _context.Presencas.Add(presenca);
        _context.SaveChanges();
    }
    public List<Presenca> Listar()
    {
        return _context.Presencas.OrderBy(Presenca => Presenca.IdPresenca).ToList();
    }
    /// <summary>
    /// Metodo que lista as presencas do usuario expecifico
    /// </summary>
    /// <param name="IdUsuario">Id do usuario para a filtragem</param>
    /// <returns>retorna a lista de presenca para o usuario</returns>
    public List<Presenca> ListarMinhas(Guid IdUsuario)
    {
        return _context.Presencas.Include(p => p.IdEventoNavigation).ThenInclude(e => e.IdInstituicaoNavigation).Where(p => p.IdUsuario == IdUsuario).ToList();
    }
}
