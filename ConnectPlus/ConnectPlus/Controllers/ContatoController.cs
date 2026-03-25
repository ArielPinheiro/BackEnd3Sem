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