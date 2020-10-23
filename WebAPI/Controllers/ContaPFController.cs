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
        public ActionResult<IEnumerable<ContaPF>> GetAll()
        {
            try
            {
                return _Operacoes.GetAll();
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Retorna conta da pessoa física procurada
        /// </summary>
        /// <param name="id">Id da conta procurada</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<ContaPF> GetById(int id)
        {
            try
            {
                return _Operacoes.GetById(id);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Retorna conta da pessoa física procurada
        /// </summary>
        /// <param name="idConta">Conta procurada</param>
        /// <returns></returns>
        [HttpGet("conta/{idConta}")]
        public ActionResult<ContaPF> GetByConta(int idConta)
        {
            try
            {
                return _Operacoes.GetByConta(idConta);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Retorna contas de pessoas físicas da agência procurada
        /// </summary>
        /// <param name="idAgencia">Conta procurada</param>
        /// <returns></returns>
        [HttpGet("agencia/{idAgencia}")]
        public ActionResult<List<ContaPF>> GetByAgencia(int idAgencia)
        {
            try
            {
                return _Operacoes.GetByAgencia(idAgencia);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Retorna quantidade de contas
        /// </summary>
        /// <returns></returns>
        [HttpGet("quantidade")]
        public ActionResult<int> GetQuantidadeDeContas()
        {
            try
            {
                return _Operacoes.GetQuantidadeDeContas();
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Retorna última conta
        /// </summary>
        /// <returns></returns>
        [HttpGet("ultima")]
        public ActionResult<ContaPF> GetUltimaConta()
        {
            try
            {
                return _Operacoes.GetUltimaConta();
            }
            catch
            {
                return BadRequest();
            }
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
            try
            {
                return _Operacoes.CriarConta(conta);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Cria várias contas ao mesmo tempo
        /// </summary>
        /// <param name="contas"></param>
        /// <returns></returns>
        [HttpPost("varias")]
        public ActionResult<List<ContaPF>> CriarContas([FromBody] List<ContaPF> contas)
        {
            try
            {
                return _Operacoes.CriarContas(contas);
            }
            catch
            {
                return BadRequest();
            }
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
            try
            {
                _Operacoes.DeletarContaPorId(id);
            }
            catch
            {
                BadRequest();
            }
        }

        /// <summary>
        /// Deleta todas contas
        /// </summary>
        [HttpDelete("todos")]
        public void DeletarTodos()
        {
            try
            {
                _Operacoes.DeletarTodos();
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Deleta conta pelo número da conta
        /// </summary>
        /// <param name="numeroConta"></param>
        [HttpDelete("conta/{numeroConta}")]
        public void DeletarContaPorConta(int numeroConta)
        {
            try
            {
                _Operacoes.DeletarContaPorConta(numeroConta);
            }
            catch
            {
                BadRequest();
            }
        }

        /// <summary>
        /// Deleta todas contas de uma agência
        /// </summary>
        /// <param name="numeroAgencia"></param>
        [HttpDelete("agencia/{numeroAgencia}")]
        public void DeletarContasPorAgencia(int numeroAgencia)
        {
            try
            {
                _Operacoes.DeletarContasPorAgencia(numeroAgencia);
            }
            catch
            {
                BadRequest();
            }
        }

        #endregion

        #region Put

        /// <summary>
        /// Atualiza as informações de uma conta
        /// </summary>
        /// <param name="id">Id da conta</param>
        /// <param name="conta">Conta com novas informações</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult<ContaPF> AlterarContaPorId(int id, [FromBody] ContaPF conta)
        {
            return _Operacoes.AlterarContaPorId(id, conta);
        }

        /// <summary>
        /// Atualiza as informações de uma conta
        /// </summary>
        /// <param name="numeroConta">Número da conta</param>
        /// <param name="conta">Conta com novas informações</param>
        /// <returns></returns>
        [HttpPut("conta/{numeroConta}")]
        public ActionResult<ContaPF> AlterarContaPorConta(int numeroConta, [FromBody] ContaPF conta)
        {
            return _Operacoes.AlterarContaPorConta(numeroConta, conta);
        }

        #endregion

        #region Patch

        /// <summary>
        /// Atualiza as informações de uma conta
        /// </summary>
        /// <param name="id">Id da conta</param>
        /// <param name="nome">Novo nome completo</param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public ActionResult<ContaPF> AlterarNomePorId(int id, string nome)
        {
            try
            {
                return _Operacoes.AlterarNomePorId(id, nome);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Atualiza as informações de uma conta
        /// </summary>
        /// <param name="numeroConta">Número da conta</param>
        /// <param name="nome">Novo nome completo</param>
        /// <returns></returns>
        [HttpPatch("conta/{numeroConta}")]
        public ActionResult<ContaPF> AlterarNomePorConta(int numeroConta, string nome)
        {
            try
            {
                return _Operacoes.AlterarNomePorConta(numeroConta, nome);
            }
            catch
            {
                return BadRequest();
            }
        }

        #endregion
    }
}
