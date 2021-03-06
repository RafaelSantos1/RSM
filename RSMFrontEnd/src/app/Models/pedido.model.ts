import { ProdutoModel } from "./produto.model";
export class PedidoModel{
    nomeLoja: string;
    codigoPedido: string;
    data: string;
    total: number;
    produtos: Array<ProdutoModel>;
}