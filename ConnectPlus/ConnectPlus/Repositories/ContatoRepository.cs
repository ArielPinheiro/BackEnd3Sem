using ConnectPlus.BdContextConnect;
using ConnectPlus.Interfaces;
using ConnectPlus.Models;

namespace ConnectPlus.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly ConnectContext _context;
        public ContatoRepository(ConnectContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Atualiza um contato existente no banco de dados. Ele busca o contato pelo ID fornecido, e se encontrado, atualiza suas propriedades com os valores do objeto contato passado como parâmetro. Após a atualização, as alterações são salvas no banco de dados.
        /// </summary>
        /// <param name="Id">Id Do Contato para atualizar</param>
        /// <param name="contato"></param>
        public void Atualizar(Guid Id, Contato contato)
        {
            var contatoExistente = _context.Contatos.Find(Id);
            if (contatoExistente != null)
            {
               contatoExistente.Nome = contato.Nome;
               contatoExistente.FormaContato = contato.FormaContato;
               contatoExistente.Imagem = contato.Imagem;
               contatoExistente.IdTipoContato = contato.IdTipoContato;
               _context.SaveChanges();
            }
        }
        /// <summary>
        /// Busca um contato no banco de dados pelo seu ID. Ele utiliza o método Find do contexto para localizar o contato correspondente ao ID fornecido e retorna o resultado. Se o contato não for encontrado, o método retornará null.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Contato BuscarPorIdContato(Guid Id)
        {
            return _context.Contatos.Find(Id)!;
        }
        /// <summary>
        /// Cadastra um novo contato no banco de dados. Ele adiciona o objeto contato passado como parâmetro à coleção de contatos do contexto e, em seguida, salva as alterações para persistir o novo contato no banco de dados.
        /// </summary>
        /// <param name="contato"></param>
        public void Cadastrar(Contato contato)
        {
            _context.Contatos.Add(contato);
            _context.SaveChanges();
        }
        /// <summary>
        /// Deleta o contato do banco de dados. Ele busca o contato pelo ID fornecido, e se encontrado, remove o contato da coleção de contatos do contexto e salva as alterações para refletir a exclusão no banco de dados.
        /// </summary>
        /// <param name="Id"></param>
        public void Deletar(Guid Id)
        {
            var contatoExistente = _context.Contatos.Find(Id);
            if (contatoExistente != null)
            {
                _context.Contatos.Remove(contatoExistente);
                _context.SaveChanges();
            }
        }
        /// <summary>
        /// Lista todos os contatos presentes no banco de dados. Ele utiliza o método ToList para converter a coleção de contatos do contexto em uma lista e retorna essa lista como resultado.
        /// </summary>
        /// <returns>Retorna a lista de contatos</returns>
        public List<Contato> Listar()
        {
            return _context.Contatos.ToList();
        }
    }
}
