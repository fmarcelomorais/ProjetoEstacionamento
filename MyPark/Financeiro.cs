using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyPark.Models;

namespace MyPark
{
    public class Financeiro
    {
        List<Garage> pagamentos = new List<Garage>();
        public double Valor { get; set; }

        public bool Receber(string placa, double valor)
        {  
            
            var es = new Estacionamento();
            var carro = es.BuscaVeiculo(placa);
            var pago = false;
            var pg = new Pagamentos();
            
             for(int i = 0; i < Funcionalidades.vagas.Length; i++)
            {
                if (Funcionalidades.vagas[i] != null && Funcionalidades.vagas[i].Carro.Placa == carro.Placa)
                {
                    var pagou = RealizaPagamento(Funcionalidades.vagas[i].ValorAPagar, valor);
                    Funcionalidades.vagas[i].StatusPagamento = pagou;
                    Funcionalidades.vagas[i] = null;
                    pagamentos.Add(Funcionalidades.vagas[i]);
                    pg.ValorTotal += valor;
                    pg.Garagem.Add(Funcionalidades.vagas[i]);
                    pago = pagou;
                    
                }
            } 
            return pago;
        }
        private bool RealizaPagamento(double aReceber, double recebido)
        {
            
            bool pago = false;

            if(recebido <= 0)
            {
                System.Console.WriteLine("Favor informar um valor maior que zero.");
                return pago;
            }
            else
            {
                System.Console.WriteLine("RECEBENDO VALORES ....");
                System.Console.WriteLine($"VALOR A PAGAR.............. R$ {aReceber.ToString("C")}");
                System.Console.WriteLine($"VALOR RECEBIDO............. R$ {recebido.ToString("C")}");
                var troco = recebido - aReceber;
                System.Console.WriteLine($"TROCO ..................... R$ {troco.ToString("C")}");
                //System.Console.WriteLine($"TOTAL ..................... R$ {recebido}");
                pago = true;
            }
            return pago;
            
        }
        public void Extrato(string placa)
        {
            var es = new Estacionamento();
            System.Console.WriteLine("==========[ EXTRATO ============\n");
            var carro = es.BuscaVeiculo(placa);
            for(int i = 0; i < Funcionalidades.vagas.Length; i++)
            {
                if (Funcionalidades.vagas[i] != null && Funcionalidades.vagas[i].Carro.Placa == carro.Placa)
                {
                    es.Sair(placa);
                    System.Console.WriteLine("\n==============[ DADOS DO VEICULO ]================\n");
                    System.Console.WriteLine($"MARCA: {Funcionalidades.vagas[i].Carro.Marca}");
                    System.Console.WriteLine($"MODELO: {Funcionalidades.vagas[i].Carro.Modelo}");
                    System.Console.WriteLine($"PLACA: {Funcionalidades.vagas[i].Carro.Placa}");
                    System.Console.WriteLine("==============[ DADOS DA VAGA ]================");
                    System.Console.WriteLine($"Nº DA VAGA: {Funcionalidades.vagas[i].NumeroVaga}");
                    System.Console.WriteLine($"VALOR A PAGAR: {Funcionalidades.vagas[i].ValorAPagar.ToString("C")}");
                    System.Console.WriteLine("==============[ PERIODO ]================");
                    System.Console.WriteLine($"ENTRADA: {Funcionalidades.vagas[i].HoraEntrada}");
                    System.Console.WriteLine($"SAIDA: {Funcionalidades.vagas[i].HoraSaida}");
                    System.Console.WriteLine("\n==================================================\n");
                    
                }
            }                     
        }
        public void ListaDePagamentos()
        {
            var pg = new Pagamentos();
            System.Console.WriteLine("========= [ PAGAMENTOS ] ============");
            foreach(var pagamento in pg.Garagem)
            {
                    System.Console.WriteLine("\n==============[ DADOS DO VEICULO ]================\n");
                    System.Console.WriteLine($"MARCA: {pagamento.Carro.Marca}");
                    System.Console.WriteLine($"MODELO: {pagamento.Carro.Modelo}");
                    System.Console.WriteLine($"PLACA: {pagamento.Carro.Placa}");
                    System.Console.WriteLine("==============[ DADOS DA VAGA ]================");
                    System.Console.WriteLine($"Nº DA VAGA: {pagamento.NumeroVaga}");
                    System.Console.WriteLine($"VALOR A PAGAR: {pagamento.ValorAPagar.ToString("C")}");
                    System.Console.WriteLine("==============[ PERIODO ]================");
                    System.Console.WriteLine($"ENTRADA: {pagamento.HoraEntrada}");
                    System.Console.WriteLine($"SAIDA: {pagamento.HoraSaida}");
                    System.Console.WriteLine("==============[ TOTAL ]================");
                    System.Console.WriteLine($"TOTAL: {pg.ValorTotal.ToString("C")}");
                    System.Console.WriteLine("\n==================================================\n");
            }
        }
    }
}