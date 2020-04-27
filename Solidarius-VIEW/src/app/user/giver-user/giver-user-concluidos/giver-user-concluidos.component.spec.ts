import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GiverUserConcluidosComponent } from './giver-user-concluidos.component';

describe('GiverUserConcluidosComponent', () => {
  let component: GiverUserConcluidosComponent;
  let fixture: ComponentFixture<GiverUserConcluidosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GiverUserConcluidosComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GiverUserConcluidosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
