using ConnectPlus.DTO;
using ConnectPlus.Interfaces;
using ConnectPlus.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConnectPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoRepository _contatoRepository;
        public ContatoController(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }


        /// <summary>
        /// Cria um novo contato com base nos dados fornecidos no ContatoDTO e o cadastra usando o repositório de contatos. Retorna uma resposta indicando o sucesso ou falha da operação.
        /// </summary>
        /// <param name="contatoDTO"></param>
        /// <returns>Retorna um contato cadastrado</returns>
        [HttpPost]
        public IActionResult Cadastrar(ContatoDTO contatoDTO)
        {
            try
            {
                var contato = new Contato
                {
                    Nome = contatoDTO.Nome,
                    FormaContato = contatoDTO.FormaContato,
                    Imagem = contatoDTO.Imagem,
                    IdTipoContato = contatoDTO.IdTipoContato
                };
                _contatoRepository.Cadastrar(contato);
                return Ok("Contato cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Retorna uma lista de contatos cadastrados no sistema.
        /// </summary>
        /// <returns>retorna uma lista de contatos</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                var contatos = _contatoRepository.Listar();
                return Ok(contatos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// atualiza um contato existente com base no ID fornecido e nos dados do ContatoDTO
        /// </summary>
        /// <param name="id">Id do contato</param>
        /// <param name="contatoDTO">Contato DTO</param>
        /// <returns>Retorna o contato Mudado apos a atualização</returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, ContatoDTO contatoDTO)
        {
            try
            {
                var contato = new Contato
                {
                    Nome = contatoDTO.Nome,
                    FormaContato = contatoDTO.FormaContato,
                    Imagem = contatoDTO.Imagem,
                    IdTipoContato = contatoDTO.IdTipoContato
                };
                _contatoRepository.Atualizar(id, contato);
                return Ok("Contato atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Deleta o contato correspondente ao ID fornecido usando o repositório de contatos
        /// </summary>
        /// <param name="id">Id do contato a ser deletado</param>
        /// <returns>retorna dps de ter deletado</returns>
        [HttpDelete("{id}")]
        public IActionResult Deletar(Guid id)
        {
            try
            {
                _contatoRepository.Deletar(id);
                return Ok("Contato deletado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Lista o contato por id fornecido usando o repositório de contatos.
        /// </summary>
        /// <param name="id">Id do contato a ser listado</param>
        /// <returns>Retorna o contato listado pelo id</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(Guid id)
        {
            try
            {
                var tipoContato = _contatoRepository.BuscarPorIdContato(id);
                return Ok(tipoContato);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}