import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { ApiService } from '../api.service';
import { UsuarioModel } from '../models/usuario-model';
import { SessionStorageService } from '../session-storage.service';
import { DoadorModel } from '../models/doador-model';
import { BeneficiarioModel } from '../models/beneficiario-model';
import { UserType } from '../enums/userType.enum';
import { MediadorModel } from '../models/mediador-model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

    constructor(
        private apiService: ApiService,
        private sessionStorage: SessionStorageService
    ) { }

    private url = 'user';
    public login(email: string, pass: string): Observable<any> {
        return this.apiService.post(this.url + `/login`, { email, pass });
    }
    public userPage(): Observable<any> {
        const user = this.sessionStorage.getUser();
        if (user) {
            return this.apiService.get(
                this.url + `/user-page?userId=${user.userId.toString()}&userTypeInt=${user.userType.toString()}`,
                {observe : 'response'});
        } else {
            return of({status: 204});
        }
    }

    public newUser(user: BeneficiarioModel | DoadorModel) {
        if (user.constructor.name === 'BeneficiarioModel') {
            return this.apiService.post('beneficiarios', user);
        } else if (user.constructor.name === 'DoadorModel') {
            return this.apiService.post('doadores', user);
        }
    }

    public getUser(): Observable<BeneficiarioModel | DoadorModel | MediadorModel> {
        const user = this.sessionStorage.getUser();
        if (user.userType == UserType.beneficiario) {
            return this.apiService.get('beneficiarios/' + user.userId);
        } else if (user.userType == UserType.doador) {
            return this.apiService.get('doadores/' + user.userId);
        } else if (user.userType == UserType.mediador) {
            return this.apiService.get('mediadores/' + user.userId);
        }
    }

    public sendImage(formData: any): Observable<any> {
        return this.apiService.post(this.url + '/images', formData);
        
        // , {
        //     reportProgress: true,
        //     observe: 'events'
        //   });
    }
}
