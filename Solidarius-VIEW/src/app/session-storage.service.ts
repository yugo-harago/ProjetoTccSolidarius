import { Injectable } from '@angular/core';
import { NotificationService } from './notification.service';

const SESSION_STORAGE_KEY = 'kovacks_producoes';
const SESSION_STORAGE_KEY_User = 'kovacks_producoes_user';
const SESSION_MESSAGE_KEY = 'message_'
// Aplicar algum tipo de segurança
interface ISessionItem {
    id: number;
    item: any;
}
interface UserCredential {
    userId: number;
    userType: number;
}
interface IMessageNotification {
    onRouter: string;
    message: string;
}

@Injectable({
  providedIn: 'root'
})
export class SessionStorageService {

  constructor(
      private notificationService: NotificationService
  ) { }

  // Get All Items
  fetch(): ISessionItem[] {
      return JSON.parse(localStorage.getItem(SESSION_STORAGE_KEY)) || [];
  }

  // Delete all
  clear(): void {
      localStorage.removeItem(SESSION_STORAGE_KEY);
  }

  // Save
  add(item: ISessionItem): void {
      const items = this.fetch().concat(item);
      localStorage.setItem(SESSION_STORAGE_KEY, JSON.stringify(items));
  }
  addNotification(message: IMessageNotification) {
      localStorage.setItem(SESSION_MESSAGE_KEY + message.onRouter, message.message);
  }
  popStoredNotification(router: string) {
      const message = localStorage.getItem(SESSION_MESSAGE_KEY + router);
      if (message){
        this.notificationService.popNotification(message);
        localStorage.removeItem(SESSION_MESSAGE_KEY + router);
      }
  }
  addUser(user: UserCredential): void {
    localStorage.setItem(SESSION_STORAGE_KEY_User, JSON.stringify(user));
  }
  getUser(): UserCredential {
    return JSON.parse(localStorage.getItem(SESSION_STORAGE_KEY_User));
  }
  removeUser(): void {
    localStorage.removeItem(SESSION_STORAGE_KEY_User);
  }

  // Delete
  delete(item: ISessionItem): void {
      const items = this.fetch();
      const filteredItems = items.filter((_item) => {
          return _item.id !== item.id;
      });

      localStorage.setItem(SESSION_STORAGE_KEY, JSON.stringify(filteredItems));
  }
}
