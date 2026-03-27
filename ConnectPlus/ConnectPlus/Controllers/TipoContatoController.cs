using ConnectPlus.DTO;
using ConnectPlus.Interfaces;
using ConnectPlus.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConnectPlus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoContatoController : ControllerBase
    {
        private readonly ITipoContatoRepository _tipoContatoRepository;
        public TipoContatoController(ITipoContatoRepository tipoContatoRepository)
        {
            _tipoContatoRepository = tipoContatoRepository;
        }

        /// <summary>
        /// Cria um novo tipo de contato com base nos dados fornecidos no TipoContatoDTO e o salva no repositório.
        /// </summary>
        /// <param name="tipoContatoDTO"></param>
        /// <returns>Retorna TipoContato após ser criado</returns>
         [HttpPost]
         public IActionResult Cadastrar(TipoContatoDTO tipoContatoDTO)
            {
                try
                {
                    var tipoContato = new TipoContato
                    {
                        Titulo = tipoContatoDTO.Titulo
                    };
                    _tipoContatoRepository.Cadastrar(tipoContato);
                    return Ok("Tipo de contato cadastrado com sucesso!");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
         }
        /// <summary>
        /// Lista os tipos de Tipocontatos cadastrados no sistema
        /// </summary>
        /// <returns>Retorna os Tipocontatos listados</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                var tipoContatos = _tipoContatoRepository.Listar();
                return Ok(tipoContatos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
         }

        /// <summary>
        /// Atualiza um tipo de contato existente com base no ID fornecido.
        /// </summary>
        /// <param name="id">Id do TipoContato</param>
        /// <param name="tipoContatoDTO"></param>
        /// <returns>Retorna o TipoContato Atualizado</returns>
         [HttpPut("{id}")]
         public IActionResult Atualizar(Guid id, TipoContatoDTO tipoContatoDTO)
         {
             try
             {
                 var tipoContato = new TipoContato
                 {
                     Titulo = tipoContatoDTO.Titulo
                 };
                 _tipoContatoRepository.Atualizar(id, tipoContato);
                 return Ok("Tipo de contato atualizado com sucesso!");
             }
             catch (Exception ex)
             {
                 return BadRequest(ex.Message);
             }
          }
        /// <summary>
        /// Deleta um tipo de contato existente com base no ID fornecido.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna o TipoContato Deletado</returns>
        [HttpDelete("{id}")]
          public IActionResult Deletar(Guid id)
          {
              try
              {
                  _tipoContatoRepository.Deletar(id);
                  return Ok("Tipo de contato deletado com sucesso!");
              }
              catch (Exception ex)
              {
                  return BadRequest(ex.Message);
              }
          }
        /// <summary>
        /// Retorna um tipo de contato específico com base no ID fornecido.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um TipoContato Retornado com base no ID</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPorIdContato(Guid id)
        {
            try
            {
                var tipoContato = _tipoContatoRepository.BuscarPorIdContato(id);
                if (tipoContato == null)
                {
                    return NotFound("Tipo de contato não encontrado.");
                }
                return Ok(tipoContato);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
