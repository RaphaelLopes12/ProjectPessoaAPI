using ProjectPessoa.Models;

namespace ProjectPessoa.Services.Interfaces;

public interface IPessoaService
{
    Task<IEnumerable<Pessoa>> GetPessoas();
    Task<Pessoa?> GetPessoa(int id);
    Task<int> AddPessoa(Pessoa pessoa);
    Task<bool> UpdatePessoa(Pessoa pessoa);
    Task<bool> DeletePessoa(int id);
}
