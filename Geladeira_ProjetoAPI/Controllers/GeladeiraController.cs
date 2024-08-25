using Geladeira_ProjetoAPI.Modes;
using Microsoft.AspNetCore.Mvc;



namespace Geladeira_ProjetoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeladeiraController : ControllerBase
    {
        private readonly Geladeira _geladeira;

        public GeladeiraController()
        {
            _geladeira = new Geladeira(); // Normalmente, você injetaria esse serviço.
        }

        [HttpGet("itens")]
        public IActionResult ObterItens()
        {
            var itens = _geladeira.ObterItens();
            return Ok(itens);
        }

        [HttpPost("adicionar")]
        public IActionResult AdicionarItem(int andar, int container, int posicao, string item)
        {
            try
            {
                _geladeira.Andares[andar].Containers[container].AdicionarItem(posicao, item);
                return Ok($"Item '{item}' adicionado ao andar {andar}, container {container}, posição {posicao}");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("remover")]
        public IActionResult RemoverItem(int andar, int container, int posicao)
        {
            try
            {
                _geladeira.Andares[andar].Containers[container].RemoverItem(posicao);
                return Ok($"Item removido do andar {andar}, container {container}, posição {posicao}");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("removerTodos")]
        public IActionResult RemoverTodosItens(int andar, int container)
        {
            try
            {
                _geladeira.Andares[andar].Containers[container].RemoverTodosItens();
                return Ok($"Todos os itens removidos do andar {andar}, container {container}");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}