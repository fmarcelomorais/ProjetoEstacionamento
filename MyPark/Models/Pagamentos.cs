using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyPark.Models
{
    public class Pagamentos
    {
        public double ValorTotal { get; set; }
        public List<Garage> Garagem = new List<Garage>();       
        
        public void GravarPagamento(Garage garagem, double valor)
        {
            ValorTotal += valor;
            Garagem.Add(garagem);
            
        }
    }
}