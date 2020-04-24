import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-giver-user-header',
  templateUrl: './giver-user-header.component.html',
  styleUrls: ['./giver-user-header.component.sass']
})
export class GiverUserHeaderComponent implements OnInit {

    constructor(
        public router: Router
    ) { }

    ngOnInit() {
    }

}
