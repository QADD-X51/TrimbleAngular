import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Dummycomponent2Component } from './dummycomponent2.component';

describe('Dummycomponent2Component', () => {
  let component: Dummycomponent2Component;
  let fixture: ComponentFixture<Dummycomponent2Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ Dummycomponent2Component ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(Dummycomponent2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
