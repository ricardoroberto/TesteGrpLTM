import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProdutoListaComponent } from './produto-lista/produto-lista.component';
import { ProdutoEditaComponent } from './produto-edita/produto-edita.component';
import { EstoqueProdutoRoutingModule } from './estoque-produto.routing.module';
import { EstoqueAuth } from './estoque-produto.guard';


@NgModule({
  imports: [
    CommonModule,
    EstoqueProdutoRoutingModule
  ],
  exports: [EstoqueProdutoRoutingModule],
  providers: [EstoqueAuth],
  declarations: [ProdutoListaComponent, ProdutoEditaComponent]
})
export class EstoqueProdutoModule { }
