using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyPark.Models;
using Newtonsoft.Json;

namespace MyPark
{
    public class Financeiro
    {
        Pagamentos Pag = new Pagamentos();
        
        public bool Receber(string placa, double valor)
        {  
            
            var es = new Estacionamento();
            var carro = es.BuscaVeiculo(placa);
            var pago = false;
            
             for(int i = 0; i < Funcionalidades.vagas.Length; i++)
            {
                if (Funcionalidades.vagas[i] != null && Funcionalidades.vagas[i].Carro.Placa == carro.Placa)
                {
                    var pagou = RealizaPagamento(Funcionalidades.vagas[i].ValorAPagar, valor);
                    Funcionalidades.vagas[i].StatusPagamento = pagou;
                    //Funcionalidades.vagas[i].ValorAPagar = valor;
                    Pag.GravarPagamento(Funcionalidades.vagas[i], valor);
                    Funcionalidades.listaDePagamentos.Add(Pag);
                    string pagamentosJson = JsonConvert.SerializeObject(Funcionalidades.listaDePagamentos, Formatting.Indented);
                    File.WriteAllText("Arquivos/pagamentos.json", pagamentosJson);
                    Funcionalidades.vagas[i] = null;
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
                recebido = aReceber;
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
            var dadosGaragemSerializado = File.ReadAllText("Arquivos/pagamentos.json");
            List<Pagamentos> deserializedGaragem = JsonConvert.DeserializeObject<List<Pagamentos>>(dadosGaragemSerializado);
            System.Console.WriteLine("========= [ PAGAMENTOS ] ============");
            
            //for(int i = 0; i < deserializedGaragem.Count; i++)
            foreach(var lista in deserializedGaragem)
            {
                    int indice = 0;
                    System.Console.WriteLine("\n==============[ DADOS DO VEICULO ]================\n");                    
                    System.Console.WriteLine($"MARCA: {lista.Garagem[indice].Carro.Marca}");
                    System.Console.WriteLine($"MODELO: {lista.Garagem[indice].Carro.Modelo}");
                    System.Console.WriteLine($"MODELO: {lista.Garagem[indice].Carro.Modelo}");
                    System.Console.WriteLine($"PLACA: {lista.Garagem[indice].Carro.Placa}");
                    System.Console.WriteLine("==============[ DADOS DA VAGA ]================");
                    System.Console.WriteLine($"Nº DA VAGA: {lista.Garagem[indice].NumeroVaga}");
                    System.Console.WriteLine($"VALOR A PAGAR: {lista.Garagem[indice].ValorAPagar.ToString("C")}");
                    System.Console.WriteLine("==============[ PERIODO ]================");
                    System.Console.WriteLine($"ENTRADA: {lista.Garagem[indice].HoraEntrada}");
                    System.Console.WriteLine($"SAIDA: {lista.Garagem[indice].HoraSaida}");
                    System.Console.WriteLine("==============[ TOTAL ]================");
                    System.Console.WriteLine($"TOTAL : {lista.ValorTotal.ToString("C")}");
                    System.Console.WriteLine("\n==================================================\n");
                    indice++;
            }
        }
    }
}