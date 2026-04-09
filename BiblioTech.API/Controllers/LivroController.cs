using BiblioTech.API.Models;
using BiblioTech.API.Services;
using BiblioTech.Infra.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BiblioTech.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase {

        private readonly LivroService _livroService;

        public LivroController(LivroService livroService) {
            _livroService = livroService;
        }

        [HttpPost]
        public IActionResult Criar([FromBody] DadosLivroRequest dadosLivroRequest) {

            try {

                _livroService.CriarLivro(dadosLivroRequest);

                return Ok("Livro cadastrado com sucesso!");

            } catch (ApplicationException e) {

                return BadRequest(e.Message);
            }

        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, [FromBody] DadosLivroRequest dadosLivroRequest) {

            try {

                _livroService.AtualizarLivro(id, dadosLivroRequest);

                return Ok("Livro atualizado com sucesso!");

            } catch (ApplicationException e) {

                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult ListarResumido() {

            try {

                var livros = _livroService.ListarResumido();

                var resultado = livros.Select(l => new {
                    l.Id,
                    l.Nome,
                    l.Editora,
                    l.Autor,
                    l.Status
                });

                return Ok(resultado);

            } catch (ApplicationException e) {

                return BadRequest(e.Message);
            }

        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(Guid id) {

            try {

                var livro = _livroService.ListarPorId(id);

                if (livro == null)
                    return NotFound("Livro não encontrado.");

                return Ok(livro);

            } catch (ApplicationException e) {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(Guid id) {

            try {

                _livroService.Deletar(id);

                return Ok(new { mensagem = "Livro excluído com sucesso." });

            } catch (ApplicationException e) {

                return BadRequest(new { mensagem = e.Message });
            }
        }

    }
}
