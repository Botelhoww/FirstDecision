using FirstDecision.Business.Services.Interfaces;
using FirstDecision.Model.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace FirstDecision.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly IPessoaService _pessoaService;

        public PessoasController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>> GetPessoas()
        {
            return Ok(await _pessoaService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> GetPessoa(int id)
        {
            var pessoa = await _pessoaService.GetById(id);

            if (pessoa == null)
                return NotFound("Pessoa não encontrada.");

            return Ok(pessoa);
        }

        [HttpPost]
        public async Task<ActionResult> CadastrarPessoa(Pessoa pessoa)
        {
            try
            {
                await _pessoaService.Incluir(pessoa);

                return Ok("Pessoa cadastrada com sucesso!");
            }
            catch (ValidationException e)
            {
                if (e.Errors.Count() > 0)
                    throw new ValidationException(e.Errors);

                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> AlterarPessoa(Pessoa pessoa)
        {
            try
            {
                await _pessoaService.Alterar(pessoa);

                return Ok("Alteração feita com sucesso!");
            }
            catch (ValidationException e)
            {
                if (e.Errors.Count() > 0)
                    throw new ValidationException(e.Errors);

                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> ExcluirPessoa(int id)
        {
            try
            {
                var pessoa = await _pessoaService.GetById(id);

                if (pessoa == null)
                    return NotFound("Pessoa não encontrada");

                await _pessoaService.Excluir(pessoa);

                return Ok("Exclusão feita com sucesso!");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}