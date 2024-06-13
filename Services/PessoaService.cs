using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ProjectPessoa.Data;
using ProjectPessoa.Models;
using ProjectPessoa.Services.Interfaces;

namespace ProjectPessoa.Services;

public class PessoaService : IPessoaService
{
    private readonly ApplicationDbContext _context;

    public PessoaService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Pessoa>> GetPessoas()
    {
        return await _context.Pessoas.Include(p => p.Endereco).ToListAsync();
    }

    public async Task<Pessoa?> GetPessoa(int id)
    {
        return await _context.Pessoas.Include(p => p.Endereco).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<int> AddPessoa(Pessoa pessoa)
    {
        _context.Pessoas.Add(pessoa);
        await _context.SaveChangesAsync();
        return pessoa.Id;
    }

    public async Task<bool> UpdatePessoa(Pessoa pessoa)
    {
        var existePessoa = await _context.Pessoas.FindAsync(pessoa.Id);
        if (existePessoa == null)
        {
            return false;            
        }

        existePessoa.Name = pessoa.Name;
        existePessoa.DataNascimento = pessoa.DataNascimento;
        existePessoa.Cpf = pessoa.Cpf;
        existePessoa.Endereco = pessoa.Endereco;

        _context.Pessoas.Update(existePessoa);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeletePessoa(int id)
    {
        var pessoa = await _context.Pessoas.FindAsync(id);
        if (pessoa == null)
        {
            return false;            
        }
        _context.Pessoas.Remove(pessoa);
        await _context.SaveChangesAsync();
        return true;
    }
}
