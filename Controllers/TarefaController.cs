using Microsoft.AspNetCore.Mvc;
using TrilhaApiDesafio.Application.UseCases.Tarefas.AtualizarTarefa;
using TrilhaApiDesafio.Application.UseCases.Tarefas.CriarTarefa;
using TrilhaApiDesafio.Application.UseCases.Tarefas.DeletarTarefa;
using TrilhaApiDesafio.Application.UseCases.Tarefas.ObterTarefaPorData;
using TrilhaApiDesafio.Application.UseCases.Tarefas.ObterTarefaPorId;
using TrilhaApiDesafio.Application.UseCases.Tarefas.ObterTarefaPorStatus;
using TrilhaApiDesafio.Application.UseCases.Tarefas.ObterTarefaPorTitulo;
using TrilhaApiDesafio.Application.UseCases.Tarefas.ObterTarefas;
using TrilhaApiDesafio.Domain.Entities;
using TrilhaApiDesafio.Shared.Comunication.Responses;

namespace TrilhaApiDesafio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        //private readonly OrganizadorContext _context;

        //public TarefaController(OrganizadorContext context)
        //{
        //    _context = context;
        //}

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RespostaTarefaJson), StatusCodes.Status200OK)]
        public async Task<IActionResult> ObterPorId([FromServices] IObterTarefaPorId useCase, [FromRoute] int id)
        {
            var result = await useCase.Execute(id);
            return Ok(result);
        }

        [HttpGet("ObterTodos")]
        [ProducesResponseType(typeof(RespostaTarefaJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ObterTodos([FromServices] IObterTarefas useCase)
        {
            var result = await useCase.Execute();

            if (result.Any())
            {
                return Ok(result);
            }

            return NoContent();
        }

        [HttpGet("ObterPorTitulo")]
        [ProducesResponseType(typeof(RespostaTarefaJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ObterPorTitulo([FromServices] IObterTarefasPorTitulo useCase, [FromQuery] string titulo)
        {
            var result = await useCase.Execute(titulo);

            if (result.Any())
            {
                return Ok(result);
            }

            return NoContent();
        }

        [HttpGet("ObterPorData")]
        [ProducesResponseType(typeof(RespostaTarefaJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ObterPorData([FromServices] IObterTarefasPorData useCase, [FromQuery] DateTime data)
        {
            var result = await useCase.Execute(data);

            if (result.Any())
            {
                return Ok(result);
            }

            return NoContent();
        }

        [HttpGet("ObterPorStatus")]
        [ProducesResponseType(typeof(RespostaTarefaJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ObterPorStatus([FromServices] IObterTarefasPorStatus useCase, [FromQuery] EnumStatusTarefa status)
        {
            var result = await useCase.Execute(status);

            if (result.Any())
            {
                return Ok(result);
            }

            return NoContent();
        }


        [HttpPost]
        [ProducesResponseType(typeof(RespostaTarefaJson), StatusCodes.Status201Created)]
        public async Task<IActionResult> Criar(
            [FromServices] ICriarTarefaUseCase useCase,
            [FromBody] CriarTarefaRequest request)
        {
            var result = await useCase.Execute(request);

            return Created(string.Empty, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar([FromServices] IAtualizarTarefaUseCase useCase , int id, AtualizarTarefaRequest tarefa)
        {
            await useCase.Execute(id, tarefa);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar([FromServices] IDeletarTarefa useCase, [FromRoute] int id)
        {
            await useCase.Execute(id);
            return NoContent();
        }
    }
}
