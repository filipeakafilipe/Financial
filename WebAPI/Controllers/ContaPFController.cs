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

        #region Get
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
        public ActionResult<ContaPF> GetById(int id)
        {
            return _Operacoes.GetById(id);
        }

        /// <summary>
        /// Retorna conta da pessoa física procurada
        /// </summary>
        /// <param name="idConta">Conta procurada</param>
        /// <returns></returns>
        [HttpGet("conta/{idConta}")]
        public ActionResult<ContaPF> GetByConta(int idConta)
        {
            return _Operacoes.GetByConta(idConta);
        }

        /// <summary>
        /// Retorna contas de pessoas físicas da agência procurada
        /// </summary>
        /// <param name="idAgencia">Conta procurada</param>
        /// <returns></returns>
        [HttpGet("agencia/{idAgencia}")]
        public ActionResult<List<ContaPF>> GetByAgencia(int idAgencia)
        {
            return _Operacoes.GetByAgencia(idAgencia);
        }

        #endregion

        #region Post

        /// <summary>
        /// Cria uma nova conta 
        /// </summary>
        /// <param name="conta">Conta com todos os dados</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<ContaPF> CriarConta([FromBody] ContaPF conta)
        {
            return _Operacoes.CriarConta(conta);
        }

        /// <summary>
        /// Cria várias contas ao mesmo tempo
        /// </summary>
        /// <param name="contas"></param>
        /// <returns></returns>
        [HttpPost("varias")]
        public ActionResult<List<ContaPF>> CriarContas([FromBody] List<ContaPF> contas)
        {
            return _Operacoes.CriarContas(contas);
        }

        #endregion

        #region Delete

        /// <summary>
        /// Deleta uma conta por seu id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void DeletarContaPorId(int id)
        {
            _Operacoes.DeletarContaPorId(id);
        }

        /// <summary>
        /// Deleta todas contas
        /// </summary>
        [HttpDelete("todos")]
        public void DeletarTodos()
        {
            _Operacoes.DeletarTodos();
        }

        /// <summary>
        /// Deleta conta pelo número da conta
        /// </summary>
        /// <param name="numeroConta"></param>
        [HttpDelete("conta/{numeroConta}")]
        public void DeletarContaPorConta(int numeroConta)
        {
            _Operacoes.DeletarContaPorConta(numeroConta);
        }

        /// <summary>
        /// Deleta todas contas de uma agência
        /// </summary>
        /// <param name="numeroAgencia"></param>
        [HttpDelete("agencia/{numeroAgencia}")]
        public void DeletarContasPorAgencia(int numeroAgencia)
        {
            _Operacoes.DeletarContasPorAgencia(numeroAgencia);
        }

        #endregion

        #region Put

        [HttpPut("{id}")]
        public ActionResult<ContaPF> AlterarContaPorId(int id, [FromBody] ContaPF conta)
        {
            return _Operacoes.AlterarContaPorId(id, conta);
        }

        [HttpPut("conta/{numeroConta}")]
        public ActionResult<ContaPF> AlterarContaPorConta(int numeroConta, [FromBody] ContaPF conta)
        {
            return _Operacoes.AlterarContaPorConta(numeroConta, conta);
        }

        #endregion
    }
}
