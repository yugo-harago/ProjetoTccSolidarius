import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GiverUserHeaderComponent } from './giver-user-header.component';

describe('GiverUserHeaderComponent', () => {
  let component: GiverUserHeaderComponent;
  let fixture: ComponentFixture<GiverUserHeaderComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GiverUserHeaderComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GiverUserHeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
