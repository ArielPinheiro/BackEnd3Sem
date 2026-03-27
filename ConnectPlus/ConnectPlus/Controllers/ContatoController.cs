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
        /// EndPoint da API que cadastra um novo contato
        /// </summary>
        /// <param name="contato">Contato a ser cadastrado</param>
        /// <returns>O contato foi cadastrado com sucesso, Status Code 201</returns>
        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromForm] ContatoDTO contato)
        {
            try
            {
                var novoContato = new Contato
                {
                    Nome = contato.Nome!,
                    FormaContato = contato.FormaContato!,
                    IdTipoContato = contato.IdTipoContato
                };

                if (contato.Imagem != null && contato.Imagem.Length > 0)
                {
                    var extensao = Path.GetExtension(contato.Imagem.FileName);
                    var nomeArquivo = $"{Guid.NewGuid()}{extensao}";
                    var pastaRelativa = "wwwroot/imagens";
                    var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);

                    if (!Directory.Exists(caminhoPasta))
                        Directory.CreateDirectory(caminhoPasta);

                    var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);

                    using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                    {
                        await contato.Imagem.CopyToAsync(stream);
                    }

                    novoContato.Imagem = nomeArquivo;
                }

                _contatoRepository.Cadastrar(novoContato);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
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
        /// EndPoint da API que atualiza os dados de um contato já existente
        /// </summary>
        /// <param name="Id">Id do contato a ser atualizado</param>
        /// <param name="contato">Informacoes do contato a serem atualizadas</param>
        /// <returns>O Contato atualizado e Status Code 204</returns>
        [HttpPut("{Id}")]
        public async Task<IActionResult> Atualizar(Guid Id, [FromForm] ContatoDTO contato)
        {
            try
            {
                var contatoBuscado = new Contato
                {
                    Nome = contato.Nome!,
                    FormaContato = contato.FormaContato!,
                    IdTipoContato = contato.IdTipoContato
                };

                if (contato.Imagem != null && contato.Imagem.Length > 0)
                {
                    var extensao = Path.GetExtension(contato.Imagem.FileName);
                    var nomeArquivo = $"{Guid.NewGuid()}{extensao}";
                    var pastaRelativa = "wwwroot/imagens";
                    var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);

                    if (!Directory.Exists(caminhoPasta))
                        Directory.CreateDirectory(caminhoPasta);

                    var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);

                    using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                    {
                        await contato.Imagem.CopyToAsync(stream);
                    }

                    contatoBuscado.Imagem = nomeArquivo;
                }

                _contatoRepository.Atualizar(Id, contatoBuscado);
                return StatusCode(204, contatoBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
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