import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProdutoEditaComponent } from './produto-edita.component';

describe('ProdutoEditaComponent', () => {
  let component: ProdutoEditaComponent;
  let fixture: ComponentFixture<ProdutoEditaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProdutoEditaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProdutoEditaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
