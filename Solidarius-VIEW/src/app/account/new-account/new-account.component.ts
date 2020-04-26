import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Categoria } from '../../enums/categoria.enum';
import { UsuarioModel } from '../../models/usuario-model';
import { UserType } from '../../enums/userType.enum';
import { BeneficiarioModel } from '../../models/beneficiario-model';
import { UserService } from '../../user/user.service';
import { DoadorModel } from '../../models/doador-model';
import { Router } from '@angular/router';
import { SessionStorageService } from '../../session-storage.service';
import { map, catchError } from 'rxjs/operators';
import { HttpEventType, HttpErrorResponse } from '@angular/common/http';
import { of } from 'rxjs';

@Component({
  selector: 'app-new-account',
  templateUrl: './new-account.component.html',
  styleUrls: ['./new-account.component.sass']
})
export class NewAccountComponent implements OnInit {
    @ViewChild('fileUpload') fileUpload: ElementRef;
    private perfilImage: any;
    private imageOk = false;

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

    public fileUploadClick() {
            const fileUpload = this.fileUpload.nativeElement;
            fileUpload.onchange = (e: any) => {
                for (let index = 0; index < fileUpload.files.length; index++) {
                    const file = fileUpload.files[index];
                    this.perfilImage = { data: file, inProgress: false, progress: 0};
                }
              this.uploadFiles();  
            };
            fileUpload.click();
        }
    private uploadFiles() {
        this.fileUpload.nativeElement.value = '';
        this.uploadFile(this.perfilImage);
    }
    uploadFile(file) {
        const formData = new FormData();
        formData.append('file', file.data);
        file.inProgress = true;
        this.userService.sendImage(formData).subscribe(
            (e: any) => {
                this.usuario.fotoUsuario = e.body.path;
                this.imageOk = true;
            }
        );
        
        /*.pipe(
            map(event => {
                switch (event.type) {
                    case HttpEventType.UploadProgress:
                    file.progress = Math.round(event.loaded * 100 / event.total);
                    break;
                    case HttpEventType.Response:
                    return event;
                }
            }),
            catchError((error: HttpErrorResponse) => {
                file.inProgress = false;
                return of(`${file.data.name} upload failed.`);
            })).subscribe((event: any) => {
                if (typeof (event) === 'object') {
                    console.log(event.body);
                }
            });
            */
      }
}
