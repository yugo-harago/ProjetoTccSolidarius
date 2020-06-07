import { UsuarioModel } from './usuario-model';

export class BeneficiarioModel extends UsuarioModel {
    public interno: boolean;
    public ra: string;

    public set(usuario: UsuarioModel) {
        this.id = usuario.id;
        this.telefone = usuario.telefone;
        this.documento = usuario.documento;
        this.email = usuario.email;
        this.senha = usuario.senha;
        this.nome = usuario.nome;
        this.dataCriacao = usuario.dataCriacao;
        this.dataModificacao = usuario.dataModificacao;
        this.fotoUsuario = usuario.fotoUsuario;
    }
}