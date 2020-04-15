import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GiverUserComponent } from './giver-user.component';

describe('GiverUserComponent', () => {
  let component: GiverUserComponent;
  let fixture: ComponentFixture<GiverUserComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GiverUserComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GiverUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
