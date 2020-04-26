import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-mediator-header',
  templateUrl: './mediator-header.component.html',
  styleUrls: ['./mediator-header.component.sass']
})
export class MediatorHeaderComponent implements OnInit {

    constructor(
        public router: Router
    ) { }

    ngOnInit() {
    }

}
