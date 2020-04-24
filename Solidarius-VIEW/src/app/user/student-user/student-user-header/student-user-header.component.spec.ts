import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentUserHeaderComponent } from './student-user-header.component';

describe('StudentUserHeaderComponent', () => {
  let component: StudentUserHeaderComponent;
  let fixture: ComponentFixture<StudentUserHeaderComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StudentUserHeaderComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StudentUserHeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
