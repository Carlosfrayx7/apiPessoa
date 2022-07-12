using Microsoft.EntityFrameworkCore;
using PessoaApi.Context;
using PessoaApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PessoaApi.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly AppDbContext _dbContext;
        public PessoaService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<Pessoa>> GetPessoa()
        {
            return await _dbContext.Pessoa.ToListAsync();
        }

        public async Task<Pessoa> GetPessoaPorId(Guid id)
        {
            return await _dbContext.Pessoa.FirstOrDefaultAsync(x=> x.Id.Equals(id));
        }

        public async Task CreatePessoa(Pessoa pessoa)
        {
            _dbContext.Pessoa.Add(pessoa);
            await _dbContext.SaveChangesAsync();
        } 

        public async Task UpdatePessoa(Pessoa pessoa)
        {
            _dbContext.Entry(pessoa).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeletePessoa(Pessoa pessoa)
        {
            _dbContext.Remove(pessoa);
            await _dbContext.SaveChangesAsync();
        }
    }
}
