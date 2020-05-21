import { ProdutoService } from './../produtos.services';
import { Produto } from './../produto';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-lista-produto',
  templateUrl: './lista-produto.component.html'
})
export class ListaProdutoComponent implements OnInit {

  constructor(private ProdutoService: ProdutoService) { }

  public produtos: Produto[];

  ngOnInit(): void {
    this.ProdutoService.obterProdutos()
    .subscribe(
      produtos => {
        this.produtos = produtos;
        console.log(produtos);
      },
      error => console.log(error)
    );
   }

}
