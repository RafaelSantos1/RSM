using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSMBackEnd.Models
{
    public class Pedido
    {
       public string NomeLoja { get; set; }
       public string CodigoPedido { get; set; }
       public string Data { get; set; }
       public decimal Total { get; set; }    
       public List<Produto> Produtos { get; set; }     
    }
}
