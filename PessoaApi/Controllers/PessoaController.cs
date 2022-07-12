using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PessoaApi.Models;
using PessoaApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PessoaApi.Controllers
{
    [Route("api/pessoa")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }


        /// <summary>
        /// Endpoint para buscar lista de pessoas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Pessoa>>> GetPessoa()
        {
            try
            {
                var pessoas = await _pessoaService.GetPessoa();
                return Ok(pessoas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Endpoint para buscar lista de pessoas por id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("porid/{id}")]
        public async Task<ActionResult<Pessoa>> GetPessoaPorId(Guid id)
        {
            try
            {
                var pessoas = await _pessoaService.GetPessoaPorId(id);
                return Ok(pessoas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Endpoint criar pessoas
        /// </summary>
        /// <returns></returns>       
        [HttpPost]
        [Route("createpessoa")]
        public async Task<ActionResult<Pessoa>> CretePessoa(Pessoa pessoa)
        {
            try
            {
                await _pessoaService.CreatePessoa(pessoa);
                return Ok("Inserido com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Endpoint para atualizar pessoas
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<List<Pessoa>>> UpdatePessoa(Guid id, [FromBody]Pessoa pessoa)
        {
            try
            {
               if(pessoa.Id.Equals(id))
                {
                    await _pessoaService.UpdatePessoa(pessoa);
                    return Ok("Pessoa alterada com sucesso.");
                }
                else
                {
                    return BadRequest("Não foi possível alterar pessoa");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Endpoint para excluir pessoas
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("deletepessoa/{id}")]
        public async Task<ActionResult<Pessoa>> DeletePessoa(Guid id)
        {
            try
            {
                var pessoa = await  _pessoaService.GetPessoaPorId(id);
                if (pessoa != null)
                {
                    await _pessoaService.DeletePessoa(pessoa);
                    return Ok("Pessoa excluída com sucesso");
                }
                else
                {
                    return BadRequest("Não foi possível excluir");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


    }
}
