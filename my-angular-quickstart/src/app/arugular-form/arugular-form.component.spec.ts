import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { arugularFormComponent } from './arugular-form.component';

describe('arugularFormComponent', () => {
  let component: arugularFormComponent;
  let fixture: ComponentFixture<arugularFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ arugularFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(arugularFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
