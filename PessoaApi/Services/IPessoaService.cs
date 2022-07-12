using PessoaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PessoaApi.Services
{
    public interface IPessoaService
    {
        Task<List<Pessoa>> GetPessoa();
        Task<Pessoa> GetPessoaPorId(Guid id);
        Task CreatePessoa(Pessoa pessoa);
        Task UpdatePessoa(Pessoa pessoa);
        Task DeletePessoa(Pessoa pessoa);
    }
}
