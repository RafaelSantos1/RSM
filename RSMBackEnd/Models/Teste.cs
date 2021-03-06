using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSMBackEnd.Models
{
    public class Teste
    {

        // OBSERVAÇÃO: o código gerado pode exigir pelo menos .NET Framework 4.5 ou .NET Core/Standard 2.0.
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class PedidosVendas
        {

            private PedidosVendasPedido[] pedidoField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("Pedido")]
            public PedidosVendasPedido[] Pedido
            {
                get
                {
                    return this.pedidoField;
                }
                set
                {
                    this.pedidoField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class PedidosVendasPedido
        {

            private string clienteField;

            private uint pedidoField;

            private string dataField;

            private string totalField;

            private PedidosVendasPedidoProduto[] produtosField;

            /// <remarks/>
            public string Cliente
            {
                get
                {
                    return this.clienteField;
                }
                set
                {
                    this.clienteField = value;
                }
            }

            /// <remarks/>
            public uint Pedido
            {
                get
                {
                    return this.pedidoField;
                }
                set
                {
                    this.pedidoField = value;
                }
            }

            /// <remarks/>
            public string Data
            {
                get
                {
                    return this.dataField;
                }
                set
                {
                    this.dataField = value;
                }
            }

            /// <remarks/>
            public string Total
            {
                get
                {
                    return this.totalField;
                }
                set
                {
                    this.totalField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayItemAttribute("Produto", IsNullable = false)]
            public PedidosVendasPedidoProduto[] Produtos
            {
                get
                {
                    return this.produtosField;
                }
                set
                {
                    this.produtosField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class PedidosVendasPedidoProduto
        {

            private string codigoField;

            private string nomeField;

            private ushort quantidadeField;

            private string valorField;

            /// <remarks/>
            public string Codigo
            {
                get
                {
                    return this.codigoField;
                }
                set
                {
                    this.codigoField = value;
                }
            }

            /// <remarks/>
            public string Nome
            {
                get
                {
                    return this.nomeField;
                }
                set
                {
                    this.nomeField = value;
                }
            }

            /// <remarks/>
            public ushort Quantidade
            {
                get
                {
                    return this.quantidadeField;
                }
                set
                {
                    this.quantidadeField = value;
                }
            }

            /// <remarks/>
            public string Valor
            {
                get
                {
                    return this.valorField;
                }
                set
                {
                    this.valorField = value;
                }
            }
        }


    }
}
