import { UsuarioModel } from './usuario-model';
import { PedidoModel } from './pedido-model';

export class NotificacaoModel {
    public id: number;
    public para: UsuarioModel;
    public por: UsuarioModel;
    public descricao: string;
    public visto: boolean;
    public confirmado: boolean;
    public pedido: PedidoModel;
}