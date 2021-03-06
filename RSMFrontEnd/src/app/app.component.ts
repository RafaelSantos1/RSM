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
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.listaPedidos = new Array<PedidoModel>();
    this.valido = false;
    this.getPedido();
  }

  getPedido() {
    return new Promise<void>((resolve, reject) => {
      this.http.get('https://localhost:44339/Pedido')
        .subscribe(
          (data: any) => {    
            this.listaPedidos.push(data);   
            console.log(this.listaPedidos);
            resolve();
          },
          error => reject(error)
        );
    });    
  }

  carregarPedidos() {
    return new Promise<void>((resolve, reject) => {
      this.http.get('https://localhost:44339/ListaPedidos')
        .subscribe(
          (data: any) => {    
            this.listaPedidos = data;   
            console.log(this.listaPedidos);
            this.valido = true;
            resolve();
          },
          error => reject(error)
        );
    });    
  }

}
