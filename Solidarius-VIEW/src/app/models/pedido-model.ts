import { ItemModel } from './item-model';
import { Estado } from '../enums/estado.enum';
import { BeneficiarioModel } from './beneficiario-model';
import { DoadorModel } from './doador-model';

export class PedidoModel {
    public id: number;
    public quantidade: number;
    public estado: Estado;
    public descricao: string;
    public titulo: string;
    public dataCriacao: Date;
    public comentario: string;
    public dataModificacao: Date;
    public item: Array<ItemModel>;
    public feitoPor: BeneficiarioModel;
    public aceitoPor: DoadorModel;
}