import { Component, OnInit, Input } from '@angular/core';
import { DoadorModel } from '../../models/doador-model';
import { PedidoModel } from '../../models/pedido-model';
import { PedidoService } from '../../services/pedido.service';
import { Estado } from '../../enums/estado.enum';
import { Categoria } from '../../enums/categoria.enum';
import { NotificationService } from '../../notification.service';

@Component({
  selector: 'app-giver-user',
  templateUrl: './giver-user.component.html',
  styleUrls: ['./giver-user.component.sass']
})
export class GiverUserComponent implements OnInit {

    @Input() doador: DoadorModel;
    public word = '';
    public estado: typeof Estado = Estado;
    public categoria: typeof Categoria = Categoria;
    public pedidos: Array<PedidoModel>;

    constructor(
        private pedidoService: PedidoService,
        private notificationService: NotificationService
    ) { }

    ngOnInit() {
        this.pesquisar();
    }

    public pesquisar() {
        this.pedidoService.search(this.word).subscribe(
            (pedidos: Array<PedidoModel>) => {
                this.pedidos = pedidos;
            }
        );
    }

    public doar(pedidoId: number) {
        this.pedidoService.donate(pedidoId).subscribe(
            () => {
                this.notificationService.popNotification('Sua doação foi enviado para a avaliação.');
                this.pesquisar();
            }
        );
    }

}
