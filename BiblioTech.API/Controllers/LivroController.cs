using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BiblioTech.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase {

        [HttpPost]
        public IActionResult Criar() {


            return Ok();
        }

        [HttpPut]
        public IActionResult Atualizar() {


            return Ok();
        }

        [HttpGet]
        public IActionResult Listar() {


            return Ok();
        }

        [HttpGet]
        public IActionResult BuscarPorId() {


            return Ok();
        }

        [HttpDelete]
        public IActionResult Excluir() {


            return Ok();
        }

    }
}
