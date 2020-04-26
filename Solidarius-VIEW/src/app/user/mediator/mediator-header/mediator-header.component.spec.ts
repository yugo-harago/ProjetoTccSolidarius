import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MediatorHeaderComponent } from './mediator-header.component';

describe('MediatorHeaderComponent', () => {
  let component: MediatorHeaderComponent;
  let fixture: ComponentFixture<MediatorHeaderComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MediatorHeaderComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MediatorHeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
