import { Component, OnInit } from '@angular/core';
import { SessionStorageService } from '../../session-storage.service';
import { UserType } from '../../enums/userType.enum';

@Component({
  selector: 'app-concluidos',
  templateUrl: './concluidos.component.html',
  styleUrls: ['./concluidos.component.sass']
})
export class ConcluidosComponent implements OnInit {

    public userTypeEnum: typeof UserType = UserType;

    constructor(
        public sessionStorage: SessionStorageService
    ) { }

    ngOnInit() {
    }

}
