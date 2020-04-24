import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { UserService } from '../../user/user.service';
import { SessionStorageService } from '../../session-storage.service';
import { NotificationService } from '../../notification.service';

class User {
    email: string;
    pass: string;
}

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

    public user: User = new User();

    constructor(
        private userService: UserService,
        private router: Router,
        private sessionStorage: SessionStorageService,
        private notificationService: NotificationService
    ) { }

    ngOnInit() {
        this.sessionStorage.popStoredNotification('/login');
    }

    public login() {
        this.userService.login(this.user.email, this.user.pass).subscribe(
            (e: any) => {
                if (e.status === 204) {
                    this.notificationService.popNotification('Usuário não encontrado');
                }
                if (e.status === 200) {
                    this.sessionStorage.addUser(e.body);
                    this.router.navigateByUrl('/user');
                }
            }
        );
    }

}
