import { ProdutoModel } from './Models/produto.model';
import { PedidoModel } from './Models/pedido.model';
import { HttpClient } from '@angular/common/http';
import { OnInit, ViewChild } from '@angular/core';
import { Component } from '@angular/core';
import { BsModalService, BsModalRef, ModalDirective } from 'ngx-bootstrap/modal';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{

  @ViewChild('lgModal') public lgModal: ModalDirective;
  bsModalRef: BsModalRef;
  listaPedidos: Array<PedidoModel>;
  pedido: PedidoModel;
  auxiliar: any;
  produto: ProdutoModel;
  produtos: Array<ProdutoModel>;
  valido : Boolean;
  count : number = 0;
  isCollapsed = true;
  indice : number = 0;

  constructor(private http: HttpClient,
              private modalService: BsModalService)
  { }

  ngOnInit() {
    this.listaPedidos = new Array<PedidoModel>();  
    this.produtos = new Array<ProdutoModel>();  
    this.pedido = new PedidoModel();
    this.produto = new ProdutoModel();
    this.valido = true;
    this.getPedido();
    this.adicionarProduto();
  }

  adicionarProduto(){
       this.produtos.push(new ProdutoModel());
    this.indice++;
  }

  salvarPedido(){
    this.pedido.produtos = this.produtos;
    this.auxiliar = this.pedido;
    this.listaPedidos.push(this.auxiliar);
    this.pedido = new PedidoModel();
    this.produtos = new Array<ProdutoModel>();
    this.produtos.push(new ProdutoModel());
    alert("Sucesso novo pedido Registrado!!!")
  }

  getPedido() {
    return new Promise<void>((resolve, reject) => {
      this.http.get('https://localhost:44339/Pedido')
        .subscribe(
          (data: any) => {    
            this.listaPedidos.push(data);   
            resolve();
          },
          error => reject(error)
        );
    });    
  }

  carregarPedidos() {
    return new Promise<void>((resolve, reject) => {
      this.http.get('https://localhost:44339/Pedido/ListaPedidos')
        .subscribe(
          (data: any) => {    
            this.listaPedidos = data;   
            console.log(this.listaPedidos);
            this.valido = false;
            alert("XML CARREGADO COM SUCESSO!!")
            resolve();
          },
          error => reject(error)
        );
    });    
  }

  geradorJson(){
    console.log(this.listaPedidos);
    return new Promise<void>((resolve, reject) => {
      this.http.post('https://localhost:44339/Pedido/GeraJson',this.listaPedidos)
        .subscribe(
          result => {             
            alert("JSON GERADO COM SUCESSO NA PASTAR ARQUIVO DO PROJETO!!")
            resolve();
          },
          error => reject(error)           
          
        );
    });  
  }

  contador(){
    if(this.listaPedidos.length == this.count + 1)
      this.count = 0;
    else
      this.count++;
  }


}
