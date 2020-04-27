import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentUserRecebidosComponent } from './student-user-recebidos.component';

describe('StudentUserRecebidosComponent', () => {
  let component: StudentUserRecebidosComponent;
  let fixture: ComponentFixture<StudentUserRecebidosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StudentUserRecebidosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StudentUserRecebidosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
