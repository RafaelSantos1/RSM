using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSMBackEnd.Models
{
    public class Produto
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}
