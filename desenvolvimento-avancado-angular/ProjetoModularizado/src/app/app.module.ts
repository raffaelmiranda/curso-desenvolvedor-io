import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Provider } from '@angular/core';
import { RouterModule } from '@angular/router';
import { APP_BASE_HREF } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NgBrazil } from 'ng-brazil'
import { TextMask } from 'ng-brazil';
import { CustomFormsModule } from 'ng2-validation'

import { registerLocaleData } from '@angular/common';
import localePt from '@angular/common/locales/pt';
registerLocaleData(localePt);

import { AppComponent } from './app.component';
import { SobreComponent } from './institucional/sobre/sobre.component';
import { CadastroComponent } from './demos/reactiveForms/cadastro/cadastro.component';
import { NavegacaoModule } from './navegacao/navegacao.module';

import { AppRoutingModule } from './app.routes';
import { AdminDashboardComponent } from './admin/admin-dashboard/admin-dashboard.component';
import { AuthGuard } from './services/app.guard';
import { CadastroGuard } from './services/cadastro.guard';
import { FilmesComponent } from './demos/pipes/filmes/filmes.component';
import { FileSizePipe } from './demos/pipes/filmes/filesize.pipe';
import { ImageFormaterPipe } from './demos/pipes/image.pipe';
import { BarModule } from './demos/bar-di-zones/bar.module';
import { BarServices } from './demos/bar-di-zones/bar.service';
import { HttpClientModule } from '@angular/common/http';

export const BAR_PROVIDERS: Provider[] = [
  BarServices
];
@NgModule({
  declarations: [
    AppComponent,
    SobreComponent,
    CadastroComponent,
    FilmesComponent,
    FileSizePipe,
    ImageFormaterPipe
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    NavegacaoModule,
    HttpClientModule,
    TextMask.TextMaskModule,
    NgBrazil,
    CustomFormsModule,
    AppRoutingModule,
    BarModule.forRoot({
      unidadeId: 1000,
      unidadeToken: 'eca938c99a0e9ff91029dc'
    })
  ],
  providers: [
    AuthGuard,
    CadastroGuard
    //BAR_PROVIDERS
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
