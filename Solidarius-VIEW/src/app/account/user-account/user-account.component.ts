import { Component, OnInit } from '@angular/core';
import { UserType } from '../../enums/userType.enum';
import { DoadorModel } from '../../models/doador-model';
import { BeneficiarioModel } from '../../models/beneficiario-model';
import { UserService } from '../../user/user.service';
import { UsuarioModel } from '../../models/usuario-model';
import { SessionStorageService } from '../../session-storage.service';

@Component({
  selector: 'app-user-account',
  templateUrl: './user-account.component.html',
  styleUrls: ['./user-account.component.sass']
})
export class UserAccountComponent implements OnInit {

    public userTypeEnum: typeof UserType = UserType;

    public userType: UserType;

    public beneficiario: BeneficiarioModel;
    public doador: DoadorModel;
    public usuario: UsuarioModel;
    
    constructor(
        private userService: UserService,
        private sessionStorage: SessionStorageService,
    ) { }

    ngOnInit() {
        this.userService.getUser().subscribe(
            (user: BeneficiarioModel | DoadorModel) => {
                this.userType = this.sessionStorage.getUser().userType;
                this.usuario = user;
                //this.usuario.fotoUsuario = 'user-photo2.jpg';
                if (this.userType == UserType.beneficiario) {
                    this.beneficiario = user as BeneficiarioModel;
                } else if (this.userType == UserType.doador) {
                    this.doador = user as DoadorModel;
                }
            }
        );
    }

}
