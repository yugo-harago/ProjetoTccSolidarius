import { UsuarioModel } from './usuario-model';

export class BeneficiarioModel extends UsuarioModel{
    public interno: boolean;
    public ra: string;

}