import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DummyrouteComponent } from './dummyroute.component';

describe('DummyrouteComponent', () => {
  let component: DummyrouteComponent;
  let fixture: ComponentFixture<DummyrouteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DummyrouteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DummyrouteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
