import { Component, OnInit, Input } from '@angular/core';
import { MediadorModel } from '../../models/mediador-model';
import { PedidoService } from '../../services/pedido.service';
import { PedidoModel } from '../../models/pedido-model';
import { Estado } from '../../enums/estado.enum';
import { Categoria } from '../../enums/categoria.enum';

@Component({
  selector: 'app-mediator',
  templateUrl: './mediator.component.html',
  styleUrls: ['./mediator.component.sass']
})
export class MediatorComponent implements OnInit {

    @Input() mediador: MediadorModel;

    public pedidos: Array<PedidoModel>;
    public estado: typeof Estado = Estado;
    public categoria: typeof Categoria = Categoria;

    constructor(
        private pedidoService: PedidoService
    ) { }

    ngOnInit() {
        this.getPedidos();
    }

    public getPedidos() {
        this.pedidoService.getByUser().subscribe(
            (pedidos: Array<PedidoModel>) => {
                this.pedidos = pedidos;
            }
        );
    }

    public confirmarEntregue(pedidoId: number) {
        this.pedidoService.confirm(pedidoId).subscribe(
            () => {
                this.getPedidos();
            }
        );
    }

}
