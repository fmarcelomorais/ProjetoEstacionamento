using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPark.Models
{
    public class Garage
    {
        public DateTime HoraEntrada {get; set;}
        public DateTime HoraSaida {get; set;}
        public int NumeroVaga {get; set;}
        public Carro Carro {get; set;}
        public double ValorAPagar {get; set;}
        public bool StatusPagamento { get; set; }
        
        
    }
}