import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Dummycomponent1Component } from './dummycomponent1.component';

describe('Dummycomponent1Component', () => {
  let component: Dummycomponent1Component;
  let fixture: ComponentFixture<Dummycomponent1Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Dummycomponent1Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(Dummycomponent1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
