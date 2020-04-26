import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { NotificationService } from './notification.service';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

    constructor(
        private httpClient: HttpClient,
        private notification: NotificationService
    ) {}
    private serverUrl = 'http://localhost:53905/';
    public get<T>(url: string, options?: any): Observable<any> {
        return this.httpClient.get(this.serverUrl + url, options)
                .pipe(tap(() => {}, this.errorLog));
    }
    public post<T>(url: string, body: any, options?: any): Observable<any> {
        if (!options) {
            options = {observe : 'response'};
        }
        return this.httpClient.post(this.serverUrl + url, body, options)
                .pipe(tap(() => {}, this.errorLog));
    }
    public put<T>(url: string, body: any): Observable<any> {
        return this.httpClient.put(this.serverUrl + url, body)
                .pipe(tap(() => {}, this.errorLog));
    }
    public delete<T>(url: string): Observable<any> {
        return this.httpClient.delete(this.serverUrl + url)
                .pipe(tap(() => {}, this.errorLog));
    }

    private errorLog = (e: any) => {
        console.log(e);
        this.notification.popNotification(e.message);
    }
    
    private toHttp(obj: any) {
        let params = new HttpParams();
        Object.keys(obj).forEach((item) => {
            params = params.set(item, obj[item]);
        });
        return params;
    }
}
