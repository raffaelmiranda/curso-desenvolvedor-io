import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProdutoDashboardComponent } from './produto-dashboard/produto-dashboard.component';
import { EditarProdutoComponent } from './editar-produto/editar-produto.component';
import { ProdutoAppComponent } from './produto.app.component';

const produtoRouterConfig: Routes = [
    {
        path: '', component: ProdutoAppComponent,
        children: [
            { path: '', component: ProdutoDashboardComponent },
            { path: 'editar/:id', component: EditarProdutoComponent },
            // { -- Não funciona
            //     path: 'editar/:id',
            //     loadChildren: () => import('./editar-produto/editar-produto.component')

            // }
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