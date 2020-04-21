import { Categoria } from '../enums/categoria.enum';

export class ItemModel {
    public id: number;
    public foto: string;
    public titulo: string;
    public dataModificacao: Date;
    public dataCriacao: Date;
    public descricao: string;
    public categoria: Categoria;
}