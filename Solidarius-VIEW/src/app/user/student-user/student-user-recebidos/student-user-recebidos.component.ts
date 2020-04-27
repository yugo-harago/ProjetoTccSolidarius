import { Component, OnInit } from '@angular/core';
import { Estado } from '../../../enums/estado.enum';
import { Categoria } from '../../../enums/categoria.enum';
import { ApiService } from '../../../api.service';
import { UserService } from '../../user.service';
import { PedidoService } from '../../../services/pedido.service';
import { PedidoModel } from '../../../models/pedido-model';

@Component({
  selector: 'app-student-user-recebidos',
  templateUrl: './student-user-recebidos.component.html',
  styleUrls: ['./student-user-recebidos.component.sass']
})
export class StudentUserRecebidosComponent implements OnInit {

    public estado: typeof Estado = Estado;
    public categoriaEnum: typeof Categoria = Categoria;
    public pedidos: Array<PedidoModel>;
    public selectedThanks = 0;
    constructor(
        public pedidoService: PedidoService
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

    public sendThanks(pedido: PedidoModel) {
        this.pedidoService.sendThanks(pedido.id, pedido.agradecimento).subscribe(
            () => {
                this.getPedidos();
                this.selectedThanks = 0;
            }
        );
    }

}
