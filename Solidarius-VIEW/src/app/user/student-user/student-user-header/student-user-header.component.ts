import { Component, OnInit } from '@angular/core';
import { SessionStorageService } from '../../../session-storage.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-student-user-header',
  templateUrl: './student-user-header.component.html',
  styleUrls: ['./student-user-header.component.sass']
})
export class StudentUserHeaderComponent implements OnInit {

    constructor(
        private sessionStorage: SessionStorageService,
        public router: Router
    ) { }

    ngOnInit() {
        this.sessionStorage.popStoredNotification('/user');
    }

}
