using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Financial.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaPFController : ControllerBase
    {
        private readonly ContaPFOperacoes _Operacoes;

        public ContaPFController(ContaPFOperacoes operacoes)
        {
            _Operacoes = operacoes;
        }

        /// <summary>
        /// Lista de contas pessoa física
        /// </summary>
        /// <returns></returns>
        [HttpGet("todos")]
        public IEnumerable<ContaPF> GetAll()
        {
            return _Operacoes.GetAll();
        }

        /// <summary>
        /// Retorna conta da pessoa física procurada
        /// </summary>
        /// <param name="id">Id da conta procurada</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ContaPF GetById(int id)
        {
            return _Operacoes.GetById(id);
        }

        /// <summary>
        /// Retorna conta da pessoa física procurada
        /// </summary>
        /// <param name="idConta">Conta procurada</param>
        /// <returns></returns>
        [HttpGet("conta/{idConta}")]
        public ContaPF GetByConta(int idConta)
        {
            return _Operacoes.GetByConta(idConta);
        }

        /// <summary>
        /// Retorna contas de pessoas físicas da agência procurada
        /// </summary>
        /// <param name="idAgencia">Conta procurada</param>
        /// <returns></returns>
        [HttpGet("agencia/{idAgencia}")]
        public List<ContaPF> GetByAgencia(int idAgencia)
        {
            return _Operacoes.GetByAgencia(idAgencia);
        }
    }
}
