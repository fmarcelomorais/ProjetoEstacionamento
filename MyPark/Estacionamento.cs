using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPark.Models
{
    public class Estacionamento
    {/* 
        public Carro[] vagas = new Carro[10];
        public List<Carro> carros = new List<Carro>(); */
        const double VALOR_CARRO_PEQUENO = 5.00;
        const double VALOR_CARRO_GRANDE = 8.00;

        public Carro CadastrarVeiculo(string marca, string modelo, string placa, string tipo)
        {
            var carro = new Carro()
            {
                Marca = marca,
                Modelo = modelo,
                Placa = placa,
                Tipo = tipo,
            };

            //carros.Add(carro);

           // System.Console.WriteLine($"Veiculo cadastrado com Sucesso!");

            return carro;
        }
        public void PesquisarVeiculo(string placa)
        {     

            var carroEncontrado = Funcionalidades.carros.FirstOrDefault(c => c.Placa.ToLower() == placa.ToLower()); 
            if(carroEncontrado != null ) 
            {
                System.Console.WriteLine($"MARCA: {carroEncontrado.Marca} - MODELO: {carroEncontrado.Modelo} - PLACA: {carroEncontrado.Placa}");  
            }
            else
            {
                System.Console.WriteLine($"Veiculo de placs {placa} nao foi encontrado.");
            }
    
        }
        public Carro BuscaVeiculo(string placa)
        {     

            var carroEncontrado = Funcionalidades.carros.FirstOrDefault(c => c.Placa.ToLower() == placa.ToLower()); 
            return carroEncontrado;
    
        }
        public void ListarVeiculos()
        {
            for(int i=0; i < Funcionalidades.carros.Count; i++)
            {
                System.Console.WriteLine($"{i+1} -> MARCA: {Funcionalidades.carros[i].Marca} - MODELO: {Funcionalidades.carros[i].Modelo} - PLACA: {Funcionalidades.carros[i].Placa}");
            }
        }
      public void Entrar(Carro carro, int vaga)
        {
            if(Funcionalidades.vagas[vaga-1] == null && vaga < 10)
            {
                var garage = new Garage
                {
                    HoraEntrada = DateTime.Now,
                    Carro = carro,
                    NumeroVaga = vaga,
                };
                Funcionalidades.vagas[vaga-1] = garage;
                System.Console.WriteLine($"{carro.Modelo} - {carro.Placa} - estacionado na vaga Nº {vaga}");
            }
            else
            {
                System.Console.WriteLine($"Ja existe um carro estacionado na vaga Nº {vaga}");
            }
        }
        public void Sair(string placa)
        {
            //var fin = new Financeiro();
            var carro = BuscaVeiculo(placa);

            for(int i = 0; i < Funcionalidades.vagas.Length; i++)
            {
                if (Funcionalidades.vagas[i] != null && Funcionalidades.vagas[i].Carro.Placa == carro.Placa)
                {
                    Funcionalidades.vagas[i].HoraSaida = DateTime.Now;
                    TimeSpan tempoDecorrido = Funcionalidades.vagas[i].HoraSaida - Funcionalidades.vagas[i].HoraEntrada; 
                    var tipoCarro = Funcionalidades.vagas[i].Carro.Tipo.ToLower() == "p" ? VALOR_CARRO_PEQUENO : VALOR_CARRO_GRANDE;
                    Funcionalidades.vagas[i].ValorAPagar = tempoDecorrido.Minutes * tipoCarro / 60 < 5.00 ? VALOR_CARRO_PEQUENO : tempoDecorrido.Minutes * tipoCarro / 60;
                }             
                
            }

        }
        public void ListarVagasDisponiveis()
        {
            for(var i = 0; i < Funcionalidades.vagas.Length; i++)
            {
                if(Funcionalidades.vagas[i] == null)
                    System.Console.WriteLine($"Nº -> {i+1} - Disponivel");
                else
                    System.Console.WriteLine("Ocupada");
            }
        }

    }
}