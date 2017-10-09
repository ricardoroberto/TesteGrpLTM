import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProdutoComponent } from './produto/produto.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [ProdutoComponent],
  exports: [ProdutoComponent]
})
export class ProdutoModule { }
