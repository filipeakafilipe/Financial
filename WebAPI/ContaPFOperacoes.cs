using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Financial.WebAPI
{
    public class ContaPFOperacoes
    {
        private static readonly string[] TipoConta = new[]
        {
            "Poupança", "Conta Corrente", "Conta Salário"
        };

        private List<ContaPF> _ContasPF { get; set; }

        public ContaPFOperacoes()
        {
            _ContasPF = GerarLista();
        }

        #region Get

        public List<ContaPF> GetAll()
        {
            return _ContasPF;
        }

        public ContaPF GetById(int id)
        {
            return _ContasPF.FirstOrDefault(c => c.Id == id);
        }

        public ContaPF GetByConta(int conta)
        {
            return _ContasPF.FirstOrDefault(c => c.Conta == conta);
        }

        public List<ContaPF> GetByAgencia(int agencia)
        {
            return _ContasPF.Where(c => c.Agencia == agencia).ToList();
        }

        #endregion

        #region Post

        public ContaPF CriarConta(ContaPF conta)
        {
            conta.Id = GetProximoId();

            _ContasPF.Add(conta);

            return conta;
        }

        public List<ContaPF> CriarContas(List<ContaPF> contas)
        {
            contas.ForEach(c =>
            {
                c.Id = GetProximoId();

                _ContasPF.Add(c);
            });

            return _ContasPF;
        }

        #endregion

        #region Delete

        public void DeletarTodos()
        {
            _ContasPF.RemoveAll(c => c != null);
        }

        public void DeletarContaPorId(int id)
        {
            var conta = GetById(id);

            if (conta != null)
            {
                _ContasPF.Remove(conta);
            }
        }

        public void DeletarContaPorConta(int numeroConta)
        {
            var conta = GetByConta(numeroConta);

            if (conta != null)
            {
                _ContasPF.Remove(conta);
            }
        }

        public void DeletarContasPorAgencia(int agencia)
        {
            var contas = GetByAgencia(agencia);

            if (contas != null)
            {
                contas.ForEach(c => _ContasPF.Remove(c));
            }
        }

        #endregion

        #region Put

        public ContaPF AlterarContaPorId(int id, ContaPF novaConta)
        {
            var conta = _ContasPF.FirstOrDefault(c => c.Id == id);

            if(conta != null)
            {
                conta.Agencia = novaConta.Agencia;
                conta.Conta = novaConta.Conta;
                conta.NomeCompleto = novaConta.NomeCompleto;
                conta.TipoConta = novaConta.TipoConta;

                return conta;
            }

            return null;
        }

        public ContaPF AlterarContaPorConta(int numeroConta, ContaPF novaConta)
        {
            var conta = _ContasPF.FirstOrDefault(c => c.Id == numeroConta);

            if (conta != null)
            {
                conta.Agencia = novaConta.Agencia;
                conta.Conta = novaConta.Conta;
                conta.NomeCompleto = novaConta.NomeCompleto;
                conta.TipoConta = novaConta.TipoConta;

                return conta;
            }

            return null;
        }

        #endregion

        private int GetProximoId()
        {
            return (int)_ContasPF.Last().Id + 1;
        }

        private List<ContaPF> GerarLista()
        {
            var contasPF = new List<ContaPF>();

            contasPF.Add(new ContaPF
            {
                Id = 1,
                Agencia = 1584,
                Conta = 156145,
                NomeCompleto = "Raimundo Felipe Elias Novaes",
                TipoConta = TipoConta[0]
            });

            contasPF.Add(new ContaPF
            {
                Id = 2,
                Agencia = 3456,
                Conta = 745677,
                NomeCompleto = "Sophia Stella Ribeiro",
                TipoConta = TipoConta[2]
            });

            contasPF.Add(new ContaPF
            {
                Id = 3,
                Agencia = 8654,
                Conta = 346327,
                NomeCompleto = "Daniel Murilo Freitas",
                TipoConta = TipoConta[1]
            });

            contasPF.Add(new ContaPF
            {
                Id = 4,
                Agencia = 4568,
                Conta = 347268,
                NomeCompleto = "Sophie Analu Monteiro",
                TipoConta = TipoConta[2]
            });

            contasPF.Add(new ContaPF
            {
                Id = 5,
                Agencia = 1584,
                Conta = 364573,
                NomeCompleto = "Sônia Sophie Costa",
                TipoConta = TipoConta[0]
            });

            contasPF.Add(new ContaPF
            {
                Id = 6,
                Agencia = 1664,
                Conta = 457226,
                NomeCompleto = "Marlene Fabiana das Neves",
                TipoConta = TipoConta[1]
            });

            contasPF.Add(new ContaPF
            {
                Id = 7,
                Agencia = 7457,
                Conta = 589253,
                NomeCompleto = "Marcos Vinicius Raul Joaquim Farias",
                TipoConta = TipoConta[0]
            });

            contasPF.Add(new ContaPF
            {
                Id = 8,
                Agencia = 5374,
                Conta = 567896,
                NomeCompleto = "Joana Isabela Sophia Freitas",
                TipoConta = TipoConta[2]
            });

            contasPF.Add(new ContaPF
            {
                Id = 9,
                Agencia = 5374,
                Conta = 368484,
                NomeCompleto = "Julio César Márcio Jesus",
                TipoConta = TipoConta[1]
            });

            contasPF.Add(new ContaPF
            {
                Id = 10,
                Agencia = 5374,
                Conta = 645823,
                NomeCompleto = "Raimunda Gabrielly Corte Real",
                TipoConta = TipoConta[2]
            });

            return contasPF;
        }
    }
}
