import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Produto } from '../models/produto';
import { ProdutoService } from './produto.service';

@Injectable()
export class ProdutosResolve implements Resolve<Produto[]> {
    
    constructor(private produtoService: ProdutoService){}

    resolve(route: ActivatedRouteSnapshot) {
        return this.produtoService.obterTodos(route.params.estado);
    }

}