import { PedidoModel } from './Models/pedido.model';
import { HttpClient } from '@angular/common/http';
import { OnInit } from '@angular/core';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{

  listaPedidos: Array<PedidoModel>;
  valido : Boolean;
  count : number = 0;
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.listaPedidos = new Array<PedidoModel>();
    this.valido = true;
    this.getPedido();
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
    console.log(this.count);
    if(this.listaPedidos.length == this.count + 1)
      this.count = 0;
    else
      this.count++;
  }

}
