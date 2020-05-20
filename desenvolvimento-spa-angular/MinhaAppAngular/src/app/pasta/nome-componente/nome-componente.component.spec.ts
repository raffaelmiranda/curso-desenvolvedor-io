import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NomeComponenteComponent } from './nome-componente.component';

describe('NomeComponenteComponent', () => {
  let component: NomeComponenteComponent;
  let fixture: ComponentFixture<NomeComponenteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NomeComponenteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NomeComponenteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
