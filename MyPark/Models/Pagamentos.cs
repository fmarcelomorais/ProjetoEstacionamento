using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyPark.Models
{
    public class Pagamentos
    {
        public double ValorTotal { get; set; }
        public List<Garage> Garagem = new List<Garage>();       
        
    }
}