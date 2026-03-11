using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Repositories
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
        private readonly EventContext _context;
        //Injetar a dependencia  Recebe o context pelo contrutor
        public TipoEventoRepository(EventContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Atualiza Um Tipo De Evento Usando Rastreamento Automatico 
        /// </summary>
        /// <param name="id">Id Do Tipo evento a ser atualizado</param>
        /// <param name="tipoEvento">Novos Dados do tipo evento</param>
        public void Atualizar(Guid id, TipoEvento tipoEvento)
        {
            var TipoEventoBuscado = _context.TipoEventos.Find(id);
            if (TipoEventoBuscado != null)
            {
                TipoEventoBuscado.Titulo = tipoEvento.Titulo;

                //O Save changes detecta a mudança da propriedade titulo e automaticamente salva as alterações no banco de dados
                _context.SaveChanges();
            }
        }
        /// <summary>
        /// Busca Um Tipo De Evento Por Id 
        /// </summary>
        /// <param name="id">Id do tipo evento a ser buscado</param>
        /// <returns>Objeto do tipo evento com as informaçoes do tipo de evento buscado</returns>
        public TipoEvento BuscarPorId(Guid id)
        {
            return _context.TipoEventos.Find(id)!;

        }
        /// <summary>
        /// Cadastra um novo tipo de evento no banco de dados
        /// </summary>
        /// <param name="tipoEvento">Tipo de evento a ser cadastrado</param>
        public void Cadastrar(TipoEvento tipoEvento)
        {
            _context.TipoEventos.Add(tipoEvento);
            _context.SaveChanges();
        }
        /// <summary>
        /// Deleta um tipo de evento do banco de dados usando o id para localizar o tipo de evento a ser deletado
        /// </summary>
        /// <param name="id">id do tipo evento a ser deletado</param>
        public void Deletar(Guid id)
        {
            var tipoEventoBuscado = _context.TipoEventos.Find(id);
            if (tipoEventoBuscado != null)
            {
                _context.TipoEventos.Remove(tipoEventoBuscado);
                _context.SaveChanges();
            }
        }
        /// <summary>
        /// Busca a lsita de tipo de eventos cadastrados no banco de dados
        /// </summary>
        /// <returns></returns>
        public List<TipoEvento> Listar()
        {
           return _context.TipoEventos.OrderBy(tipoevento => tipoevento.Titulo).ToList();
        }
    }
}
