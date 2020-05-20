import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NomeComponenteComponent } from './pasta/nome-componente/nome-componente.component';
import { ListaProdutoComponent } from './lista-produto/lista-produto.component';

@NgModule({
  declarations: [
    AppComponent,
    NomeComponenteComponent,
    ListaProdutoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
