import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { registerLocaleData } from '@angular/common';
import localePt from '@angular/common/locales/pt';
registerLocaleData(localePt);

import { ProdutoDashboardComponent } from './produto-dashboard/produto-dashboard.component';
import { ProdutoDetalheComponent } from './componentes/produto-card-detalhe.component';
import { ProdutoCountComponent } from './componentes/produto.count.component';

import { ProdutoRoutingModule } from './produto.route';
import { EditarProdutoComponent } from './editar-produto/editar-produto.component';
import { ProdutoAppComponent } from './produto.app.component';


@NgModule({
    declarations: [
        ProdutoAppComponent,
        ProdutoDashboardComponent,
        ProdutoCountComponent,
        ProdutoDetalheComponent,
        EditarProdutoComponent
    ],
    imports: [
        CommonModule,
        ProdutoRoutingModule
    ],
    exports: []
})
export class ProdutoModule { }