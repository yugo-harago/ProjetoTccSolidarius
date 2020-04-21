import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiService } from '../api.service';
import { UsuarioModel } from '../models/usuario-model';
import { SessionStorageService } from '../session-storage.service';

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
        return this.apiService.get(this.url + `/user-page?userId=${user.userId.toString()}&userTypeInt=${user.userType.toString()}`);
    }
}
