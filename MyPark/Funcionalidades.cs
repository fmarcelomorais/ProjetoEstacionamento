using System.IO;
using MyPark.Models;

namespace MyPark
{
    public static class Funcionalidades
    {
        public static List<Carro> carros = new List<Carro>();
        public static Garage[] vagas = new Garage[10];
       // public static List<Garage> vagas = new List<Garage>(10);


        public static void Menu()
        {
            bool start = true;

            while(start)
            {
                //System.Console.Clear();
                System.Console.WriteLine("===============[MENU]===============");
                System.Console.WriteLine("[1] ESTACIONAMENTO | [2] FINANCEIRO | [0] - Encerrar\n");

                int opc = int.Parse(Console.ReadLine());

                switch(opc)
                {
                    case 1:
                        Console.Clear();
                        Funcionalidades.Estacionamento();
                        break;
                    case 2:
                        Console.Clear();
                        Funcionalidades.Financeiro();
                        break;
                    case 0:
                        start = false;
                        System.Console.WriteLine("Obrigado por usar o sistema.");
                        break;
                    default:
                        System.Console.WriteLine("Opcao invalida");
                        break;
                }
            }
        }
        public static void Estacionamento()
        {   
            System.Console.Clear();
            System.Console.WriteLine("==================[ ESTACIONAMENTO ]====================");
            System.Console.WriteLine("[1] Cadastrar Veiculo | [2] Listar Veiculos | [3] Pesquisar Veiculo | [4] Entrar na vaga | [5] Sair da vaga | [6] Vagas Disponiveis | [0] - Voltar\n");
            System.Console.Write("O QUE DESEJA FAZER? -> ");
            var opc = int.Parse(Console.ReadLine());

            switch(opc)
            {
                case 1:
                    Console.Clear();
                    Funcionalidades.Cadastrar();
                    break;
                case 2:
                    Console.Clear();
                    Funcionalidades.ListarVeiculos();
                    break;
                case 3:
                    Console.Clear();
                    Funcionalidades.PesquisarVeiculo();
                    break;
                case 4:
                    Console.Clear();
                    Funcionalidades.Entrar();
                    break;
                case 5:
                    Console.Clear();
                    Funcionalidades.Sair();
                    break;
                case 6:
                    //Console.Clear();
                    VagasDisponiveis();
                    break;
                case 0:
                    Console.Clear();
                    Menu();
                    break;
                default:
                    System.Console.WriteLine("Opcao invalida");
                    break;
            }

        }
        public static void Financeiro()
        {   
            System.Console.WriteLine("==================[ FINANCEIRO ]====================");
            System.Console.WriteLine("[1] Receber Pagamento | [2] Listar Pagamentos | [3] Voltar\n");
            System.Console.Write("O QUE DESEJA FAZER? -> ");
            var opc = int.Parse(Console.ReadLine());

            switch(opc)
            {
                case 1:
                    Console.Clear();
                    Funcionalidades.Receber();
                    break;
                case 2:
                    Console.Clear();
                    Funcionalidades.ListaDePagamentos();
                    break;
                case 3:
                    Console.Clear();
                    Menu();
                    break;
                default:
                    System.Console.WriteLine("Opcao invalida");
                    break;
            } 

        }
        public static void Cadastrar()
        {
            
            var estacionamento = new Estacionamento();
            System.Console.WriteLine("CADASTRO DE VEICULO");

            System.Console.Write("DESEJA CADASTRAR QUANTOS VEICULOS? ");
            var quantidade = int.Parse(Console.ReadLine());

            for(int i =0; i < quantidade; i++)
            {
                System.Console.WriteLine("DIGITE A MARCA DO VEICULO: ");
                var marca = Console.ReadLine();
                System.Console.WriteLine("DIGITE O MODELO DO VEICULO: ");
                var modelo = Console.ReadLine();
                System.Console.WriteLine("DIGITE A PLACA DO VEICULO: ");
                var placa = Console.ReadLine();
                System.Console.WriteLine("DIGITE O TIPO DO VEICULO (P ou G): ");
                var tipo = Console.ReadLine();

                var novoCarro = estacionamento.CadastrarVeiculo(marca, modelo, placa, tipo);               
                carros.Add(novoCarro);
                System.Console.WriteLine("Veiculo cadastrado com sucesso!");
            }

        }
        public static void ListarVeiculos()
        {
           var estacionamento = new Estacionamento();
           estacionamento.ListarVeiculos();
        }
        public static void PesquisarVeiculo()
        {
            System.Console.WriteLine($"======[ CONSULTA VEICULO ]==============\n");
            var es = new Estacionamento();

            System.Console.Write("DIGITE A PLACA DO VEICULO ");
            var placa = Console.ReadLine();
            es.PesquisarVeiculo(placa);
        }
        public static void Entrar()
        {
            var es = new Estacionamento();

            System.Console.WriteLine("DIGITE A PLACA DO VEICULO: ");
            var placa = Console.ReadLine();
            var carro = es.BuscaVeiculo(placa);
            System.Console.WriteLine("DIGITE O Nº DA VAGA: ");
            var vaga = int.Parse(Console.ReadLine());

            es.Entrar(carro, vaga);
        }
        public static void Sair()
        {
            var es = new Estacionamento();
            var fin = new Financeiro();

            System.Console.WriteLine("Digite a placa do veiculo: ");
            var placa = Console.ReadLine();
            fin.Extrato(placa);
            System.Console.WriteLine("DESEJA PAGAR AGORA? [S] sim | [N] nao");
            var pagar = Console.ReadLine();
            if(pagar.ToLower() == "s")
            {
                System.Console.WriteLine("DIGITE O VALOR DO PAGAMENTO: ");
                var pagamento = double.Parse(Console.ReadLine());
                es.Sair(placa);                
                fin.Receber(placa, pagamento);
                System.Console.WriteLine("VAGA DISPONIVEL."); 
            }
            else
            {
                System.Console.WriteLine("VEICULO NÃO SAIU.");
            }

        }    
        public static void VagasDisponiveis()
        {
            System.Console.WriteLine($"======[ VAGAS DISPONIVEIS ]==============\n");
            var es = new Estacionamento();
            es.ListarVagasDisponiveis();
        }
    
        public static void Receber()
        {
            var es = new Estacionamento();
            var fin = new Financeiro();
            
            System.Console.WriteLine("==========[ RECEBER VALORES ============\n");
            System.Console.WriteLine("DIGITE A PLACA DO VEICULO: ");
            var placa = Console.ReadLine();
            var carro = es.BuscaVeiculo(placa);
            for(int i = 0; i < Funcionalidades.vagas.Length; i++)
            {
                if (Funcionalidades.vagas[i] != null && Funcionalidades.vagas[i].Carro.Placa == carro.Placa)
                {
                    //es.Sair(placa);
                    Funcionalidades.vagas[i].HoraSaida = DateTime.Now;
                    System.Console.WriteLine("==============[ DADOS DO VEICULO ]================");
                    System.Console.WriteLine($"MARCA: {Funcionalidades.vagas[i].Carro.Marca}");
                    System.Console.WriteLine($"MODELO: {Funcionalidades.vagas[i].Carro.Modelo}");
                    System.Console.WriteLine($"PLACA: {Funcionalidades.vagas[i].Carro.Placa}");
                    System.Console.WriteLine("==============[ DADOS DA VAGA ]================");
                    System.Console.WriteLine($"Nº DA VAGA: {Funcionalidades.vagas[i].NumeroVaga}");
                    System.Console.WriteLine($"VALOR A PAGAR: {Funcionalidades.vagas[i].ValorAPagar}");
                    System.Console.WriteLine("==============[ PERIODO ]================");
                    System.Console.WriteLine($"ENTRADA: {Funcionalidades.vagas[i].HoraEntrada}");
                    System.Console.WriteLine($"SAIDA: {Funcionalidades.vagas[i].HoraSaida}");
                    
                }
            }
            System.Console.WriteLine("DIGITE O VALOR A SER PAGO:");
            var valor = double.Parse(Console.ReadLine());
            fin.Receber(placa, valor);
        }
        public static void ListaDePagamentos()
        {
            var fin = new Financeiro();
            fin.ListaDePagamentos();
        }
    }
}