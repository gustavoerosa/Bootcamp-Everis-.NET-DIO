using System;

namespace Bank.NET
{
    public class Conta
    {
        private TipoConta TipoConta {get; set;}
        private double Saldo {get; set;}
        private double Credito {get; set;}
        private string Nome {get; set;}

       public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
       {
           this.TipoConta = tipoConta;
           this.Saldo = saldo;
           this.Credito = credito;
           this.Nome = nome;
       } 

       public bool Sacar(double valorSaque)
       {
           if (this.Saldo - valorSaque < (this.Credito *-1))
           {
                Console.WriteLine("Saldo Insuficiente!");
                return false;
           }

           this.Saldo -= valorSaque;

           Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);

           return true;
       }

       public void Depositar(double valorDeposito)
       {
           this.Saldo += valorDeposito;

           Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
       }

       public void Transferir(double valorTransferencia, Conta contaDestino)
       {
           if (this.Sacar(valorTransferencia))
           {
               contaDestino.Depositar(valorTransferencia);
           }
       }

       public void AumentarCredito(double aumentaCredito)
       {
           if (this.Saldo > this.Credito && aumentaCredito < this.Saldo)
            {
                this.Credito += aumentaCredito;

                Console.WriteLine("Credito atual é {0} ", this.Credito);
            }
            else
            {
                Console.WriteLine("Infelizmente não podemos liberar mais credito no momento. ");
            }

       }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Credito " + this.Credito;
            return retorno;
        }
    }
}