using Microsoft.AspNetCore.Mvc;
using ProjectPessoa.Models;
using ProjectPessoa.Services.Interfaces;

namespace ProjectPessoa.Controllers;

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
        var pessoas = await _pessoaService.GetPessoas();
        return Ok(pessoas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Pessoa>> GetPessoa(int id)
    {
        var pessoa = await _pessoaService.GetPessoa(id);
        if (pessoa == null)
        {
            return BadRequest("Não foi encontrado pessoa com esse id");
        }
        return Ok(pessoa);
    }

    [HttpPost]
    public async Task<ActionResult<int>> AddPessoa(Pessoa pessoa)
    {
        int id = await _pessoaService.AddPessoa(pessoa);
        return CreatedAtAction(nameof(GetPessoas), new { id = pessoa.Id }, id);
    }

    [HttpPut]
    public async Task<IActionResult> PutPessoa(Pessoa pessoa)
    {
        var existePessoa = await _pessoaService.GetPessoa(pessoa.Id);
        if (existePessoa == null)
        {
            return BadRequest("Pessoa informada não existe cadastrada na base de dados.");
        }
        bool resultadoUpdate = await _pessoaService.UpdatePessoa(pessoa);
        if (!resultadoUpdate)
        {
            return NotFound("Não foi possível atualizar, a pessoa não existe.");
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePessoa(int id)
    {
        bool resultadoDelete = await _pessoaService.DeletePessoa(id);
        if (!resultadoDelete)
        {
            return BadRequest("Pessoa informada não existe cadastrada na base de dados.");
        }

        return NoContent();
    }

}
