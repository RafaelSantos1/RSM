using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RSMBackEnd.Models;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Newtonsoft.Json;

namespace RSMBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : Controller
    {
        private readonly ILogger<PedidoController> _logger;

        public PedidoController(ILogger<PedidoController> logger)
        {
            _logger = logger;
        }

        [HttpGet("ListaPedidos")]
        public IActionResult GetTodosPedidos()
        {
            try
            {

                //REALIZANDO LEITURA DO ARQUIVO XML E O TRANSFOMANDO EM UM OBJETO
                string arquivo = "C:\\Users\\T-Gamer\\Desktop\\Nova pasta\\RSMBackEnd\\Arquivo\\pedidos.xml";              

                var resultado = new List<Pedido>();
                XmlDocument xml = new XmlDocument();
                xml.Load(arquivo);
                XmlNodeList xnmListaPedidos = xml.SelectNodes("/PedidosVendas/Pedido");
                foreach (XmlNode xmlPedido in xnmListaPedidos)
                {
                    Pedido pedido = new Pedido();
                    pedido.NomeLoja = xmlPedido["Cliente"].InnerText;
                    pedido.CodigoPedido = xmlPedido["Pedido"].InnerText;
                    pedido.Data =DateTime.Parse(xmlPedido["Data"].InnerText);
                    pedido.Total =decimal.Parse(xmlPedido["Total"].InnerText);
                    pedido.Produtos = new List<Produto>();
                    foreach(XmlNode xmlProduto in xmlPedido.LastChild)
                    {
                        Produto produto = new Produto();
                        produto.Codigo = xmlProduto["Codigo"].InnerText;
                        produto.Nome = xmlProduto["Nome"].InnerText;
                        produto.Quantidade =int.Parse(xmlProduto["Quantidade"].InnerText);
                        produto.Valor =decimal.Parse(xmlProduto["Valor"].InnerText);

                        pedido.Produtos.Add(produto);
                    }                   
                    resultado.Add(pedido);
                }

                //CRIANDO ARQUIVO JSON
                string json = JsonConvert.SerializeObject(resultado);              
                System.IO.File.WriteAllText(@"C:\\Users\\T-Gamer\\Desktop\\Nova pasta\\RSMBackEnd\\Arquivo\\pedidos.json", json);

                return Ok(resultado);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Arquivo não encontrado");
            }
        }

        [HttpGet("Pedido")]
        public IActionResult GetPedido()
        {
            try
            {
                //REALIZANDO LEITURA DO ARQUIVO XML E O TRANSFOMANDO EM UM OBJETO
                string arquivo = "C:\\Users\\T-Gamer\\Desktop\\Nova pasta\\RSMBackEnd\\Arquivo\\pedidos.xml";
               
                XmlDocument xml = new XmlDocument();
                xml.Load(arquivo);

                XmlNodeList xnmListaPedidos = xml.SelectNodes("/PedidosVendas/Pedido");
                var xmlPedido = xnmListaPedidos[0];

                Pedido pedido = new Pedido();

                pedido.NomeLoja = xmlPedido["Cliente"].InnerText;
                pedido.CodigoPedido = xmlPedido["Pedido"].InnerText;
                pedido.Data = DateTime.Parse(xmlPedido["Data"].InnerText);
                pedido.Total = decimal.Parse(xmlPedido["Total"].InnerText);
                pedido.Produtos = new List<Produto>();
                foreach (XmlNode xmlProduto in xmlPedido.LastChild)
                {
                    Produto produto = new Produto();
                    produto.Codigo = xmlProduto["Codigo"].InnerText;
                    produto.Nome = xmlProduto["Nome"].InnerText;
                    produto.Quantidade = int.Parse(xmlProduto["Quantidade"].InnerText);
                    produto.Valor = decimal.Parse(xmlProduto["Valor"].InnerText);

                    pedido.Produtos.Add(produto);
                }

                return Ok(pedido);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Arquivo não encontrado");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Pedido pedido)
        {
            try
            {

                //REALIZANDO LEITURA DO ARQUIVO XML E O TRANSFOMANDO EM UM OBJETO
                List<Pedido> ListaPedido = new List<Pedido>();
                string json = "";
                using (StreamReader r = new StreamReader("C:\\Users\\T-Gamer\\Desktop\\Nova pasta\\RSMBackEnd\\Arquivo\\pedidos.json"))
                {
                    json = r.ReadToEnd();
                    ListaPedido = JsonConvert.DeserializeObject<List<Pedido>>(json);
                }



                ListaPedido.Add(pedido);
                //CRIANDO ARQUIVO JSON
                 json = JsonConvert.SerializeObject(ListaPedido);
                System.IO.File.WriteAllText(@"C:\\Users\\T-Gamer\\Desktop\\Nova pasta\\RSMBackEnd\\Arquivo\\pedidos.json", json);

                return Ok(ListaPedido);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Arquivo não encontrado");
            }
        }




    }
}
