import { Injectable } from '@angular/core';
import { Toast, ToastModel } from '@syncfusion/ej2-notifications'; 

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

    private toastInstance: Toast;
    constructor() {}

    public popNotification(message: string) {
        let element = document.createElement("div");
        let model = {
            title: 'Notificação',
            content: message,
            showProgressBar: true,
            timeOut: 5000,
            position: { X: "Right", Y: "Top" }
          }
        this.toastInstance = new Toast(model, element);
        this.toastInstance.show();

    }
}
