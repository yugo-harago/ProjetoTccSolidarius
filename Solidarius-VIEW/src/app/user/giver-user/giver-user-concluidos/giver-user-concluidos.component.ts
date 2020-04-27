import { Component, OnInit } from '@angular/core';
import { Categoria } from '../../../enums/categoria.enum';
import { Estado } from '../../../enums/estado.enum';
import { PedidoService } from '../../../services/pedido.service';
import { PedidoModel } from '../../../models/pedido-model';

@Component({
  selector: 'app-giver-user-concluidos',
  templateUrl: './giver-user-concluidos.component.html',
  styleUrls: ['./giver-user-concluidos.component.sass']
})
export class GiverUserConcluidosComponent implements OnInit {

    public categoriaEnum: typeof Categoria = Categoria;
    public estado: typeof Estado = Estado;
    public pedidos: Array<PedidoModel>;
    constructor(
        private pedidoService: PedidoService
    ) { }

    ngOnInit() {
        this.getPedidos();
    }

    public getPedidos() {
        this.pedidoService.getByUser(true).subscribe(
            (pedidos: Array<PedidoModel>) => {
                this.pedidos = pedidos;
            }
        );
    }
}
