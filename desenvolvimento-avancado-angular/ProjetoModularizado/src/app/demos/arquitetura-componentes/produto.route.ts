import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProdutoDashboardComponent } from './produto-dashboard/produto-dashboard.component';
import { EditarProdutoComponent } from './editar-produto/editar-produto.component';
import { ProdutoAppComponent } from './produto.app.component';
import { ProdutosResolve } from './services/produto.resolve';

const produtoRouterConfig: Routes = [
    {
        path: '', component: ProdutoAppComponent,
        children: [
            { path: '', redirectTo: 'todos' },
            {
                path: ':estado',
                component: ProdutoDashboardComponent,
                resolve: {
                    produtos: ProdutosResolve
                },
                data: {
                    teste: 'informacao'
                },
            },
            { path: 'editar/:id', component: EditarProdutoComponent },

        ]
    },
];

@NgModule({
    imports: [
        RouterModule.forChild(produtoRouterConfig)
    ],
    exports: [RouterModule]
})
export class ProdutoRoutingModule { }