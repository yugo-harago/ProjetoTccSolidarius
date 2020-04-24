import { Component, OnInit } from '@angular/core';
import { SessionStorageService } from '../session-storage.service';

@Component({
  selector: 'app-landing-page',
  templateUrl: './landing-page.component.html',
  styleUrls: ['./landing-page.component.sass']
})
export class LandingPageComponent implements OnInit {

    constructor(
        private session: SessionStorageService
    ) { }

    ngOnInit() {
        this.session.removeUser();
    }

}
