import { NgModule } from '@angular/core';
//import { ModuleWithProviders } from '@angular/core'
import { Routes, RouterModule } from '@angular/router'
import { ProdutoListaComponent } from './produto-lista/produto-lista.component';
import { ProdutoEditaComponent } from './produto-edita/produto-edita.component';
import { EstoqueAuth } from './estoque-produto.guard';

const estoqueProdutoRoutes: Routes = [
    { path: 'produto', component: ProdutoListaComponent, canActivateChild: [EstoqueAuth]},
    { path: 'produto/:id/editar', component: ProdutoEditaComponent, canActivateChild: [EstoqueAuth]},
    { path: 'produto/novo', component: ProdutoEditaComponent, canActivateChild: [EstoqueAuth]},
];

@NgModule({
    imports: [RouterModule.forChild(estoqueProdutoRoutes)],
    exports: [RouterModule]
})
export class EstoqueProdutoRoutingModule {}
