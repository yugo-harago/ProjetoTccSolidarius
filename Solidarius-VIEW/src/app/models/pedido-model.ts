import { ItemModel } from './item-model';

export class Pedido {
    public id: number;
    public quantidade: number;
    public estado: string;
    public dataCriacao: Date;
    public comentario: string;
    public dataModificacao: Date;
    public item: Array<ItemModel>;
}