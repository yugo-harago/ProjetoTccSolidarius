import { Component, OnInit, Input } from '@angular/core';
import { BeneficiarioModel } from '../../models/beneficiario-model';
import { PedidoModel } from '../../models/pedido-model';
import { ApiService } from '../../api.service';
import { PedidoService } from '../../services/pedido.service';
import { Estado } from '../../enums/estado.enum';
import { Categoria } from '../../enums/categoria.enum';
import { ItemModel } from '../../models/item-model';
import { NotificationService } from '../../notification.service';
import { SessionStorageService } from '../../session-storage.service';

@Component({
  selector: 'app-student-user',
  templateUrl: './student-user.component.html',
  styleUrls: ['./student-user.component.sass']
})
export class StudentUserComponent implements OnInit {

    @Input() beneficiario: BeneficiarioModel;
    public estado: typeof Estado = Estado;
    public categoriaEnum: typeof Categoria = Categoria;
    public pedidos: Array<PedidoModel>;
    public recebidos = 0;

    public newPedido: PedidoModel;

    constructor(
        private pedidoService: PedidoService,
        private notificatication: NotificationService
    ) { }

    ngOnInit() {
        this.getPedidos();
        this.setNewPedido();
    }
    public setNewPedido() {
        this.newPedido = new PedidoModel();
        this.newPedido.item = [new ItemModel()];
    }
    public getPedidos() {
        this.pedidoService.getByUser().subscribe(
            (pedidos: Array<PedidoModel>) => {
                this.pedidos = pedidos;
                this.recebidos = pedidos.filter(x => x.estado === Estado.concluido).length;
            }
        );
    }

    public novoItem() {
        this.newPedido.item.push(new ItemModel());
    }
    public novoPedido() {
        this.pedidoService.addPedido(this.newPedido).subscribe(
            () => {
                this.setNewPedido();
                this.notificatication.popNotification('Seu pedido foi postado com sucesso!');
                this.getPedidos();
            }
        );
    }
    public changeCategoria(categoriaNumber: string, item: ItemModel){
        item.categoria = Number(categoriaNumber);
    }
}
