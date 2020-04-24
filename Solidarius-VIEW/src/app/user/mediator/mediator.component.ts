import { Component, OnInit, Input } from '@angular/core';
import { MediadorModel } from '../../models/mediador-model';

@Component({
  selector: 'app-mediator',
  templateUrl: './mediator.component.html',
  styleUrls: ['./mediator.component.sass']
})
export class MediatorComponent implements OnInit {

    @Input() mediador: MediadorModel;
    constructor() { }

    ngOnInit() {
    }

}
