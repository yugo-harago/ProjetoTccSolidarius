import { Component, OnInit } from '@angular/core';
import { UserService } from './user.service';
import { UserType } from '../enums/userType.enum';
import { DoadorModel } from '../models/doador-model';
import { BeneficiarioModel } from '../models/beneficiario-model';
import { MediadorModel } from '../models/mediador-model';
import { Router } from '@angular/router';
import { SessionStorageService } from '../session-storage.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.sass']
})
export class UserComponent implements OnInit {

    public userTypeEnum: typeof UserType = UserType;
    public userType: UserType;
    public doador: DoadorModel;
    public beneficiario: BeneficiarioModel;
    public mediador: MediadorModel;

    constructor(
        private router: Router,
        private userService: UserService,
        private sessionStorage: SessionStorageService
    ) { }

    ngOnInit() {
        this.userService.userPage().subscribe(
            (e: any) => {
                if (e.status === 204) {
                    this.router.navigateByUrl('/login');
                    return;
                }
                this.userType = e.body.userType;
                if (this.userType === UserType.beneficiario) {
                    this.beneficiario = e.body.obj;
                }
                if (this.userType === UserType.doador) {
                    this.doador = e.obj;
                }
                if (this.userType === UserType.mediador) {
                    this.mediador = e.obj;
                }
            }
        )
    }

}
