import { Injectable } from '@angular/core';
import { ApiService } from '../api.service';
import { SessionStorageService } from '../session-storage.service';
import { PedidoModel } from '../models/pedido-model';
import { Observable } from 'rxjs';
import { HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PedidoService {

    constructor(
        private api: ApiService,
        private sessionService: SessionStorageService
    ) { }

    private url = 'pedidos';
    public search(word: string): Observable<Array<PedidoModel>> {
        return this.api.get(this.url + `?filter=${word}`);
    }
    public get(id: number): Observable<PedidoModel> {
        return this.api.get(this.url + `/${id}`);
    }
    public donate(pedidoId: number) {
        return this.api.put(this.url + '/donate/' + this.sessionService.getUser().userId + '/' + pedidoId, null);
    }
    public getByUser(onlyrecieved = false): Observable<Array<PedidoModel>> {
        const user = this.sessionService.getUser();
        if (!onlyrecieved) {
            return this.api.get(this.url + '/user/' + user.userType + '/' + user.userId);
        }else {
            return this.api.get(this.url + '/user/' + user.userType + '/' + user.userId + '/concluidos');
        }
    }
    public add(newPedido: PedidoModel) {
        const feitoPor = this.sessionService.getUser().userId;
        return this.api.post(this.url + '/' + feitoPor, newPedido);
    }
    public remove(pedidoId: number) {
        return this.api.delete(this.url + '/' + pedidoId);
    }
    public confirm(pedidoId: number): Observable<any> {
        return this.api.put(this.url + '/confirm/' + pedidoId, null);
    }
    public sendThanks(pedidoId: number, thanks: string) {
        let params = new HttpParams();
        params = params.set('thanks', thanks);
        return this.api.post(this.url + '/' + pedidoId + '/thanks', params);
    }

}
