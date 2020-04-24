import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Categoria } from '../../enums/categoria.enum';
import { UsuarioModel } from '../../models/usuario-model';
import { UserType } from '../../enums/userType.enum';
import { BeneficiarioModel } from '../../models/beneficiario-model';
import { UserService } from '../../user/user.service';
import { DoadorModel } from '../../models/doador-model';
import { Router } from '@angular/router';
import { SessionStorageService } from '../../session-storage.service';

@Component({
  selector: 'app-new-account',
  templateUrl: './new-account.component.html',
  styleUrls: ['./new-account.component.sass']
})
export class NewAccountComponent implements OnInit {

    public usuario = new UsuarioModel();
    public beneficiario = new BeneficiarioModel();
    public userTypeEnum: typeof UserType = UserType;
    public userType: UserType;

    constructor(
        private userService: UserService,
        private router: Router,
        private sessionStorage: SessionStorageService
    ) { }

    ngOnInit() {
    }

    public onSubmit() {
        const sucess = () => {
            this.router.navigateByUrl('/login');
            this.sessionStorage.addNotification({message: 'Usuário criado, faça login.', onRouter: '/login' });
        };

        if (Number(this.userType) === UserType.beneficiario) {
            this.beneficiario.set(this.usuario);
            this.userService.newUser(this.beneficiario).subscribe(sucess);
        } else {
            const doador = new DoadorModel();
            doador.set(this.usuario);
            this.userService.newUser(doador).subscribe(sucess);
        }
    }
}
