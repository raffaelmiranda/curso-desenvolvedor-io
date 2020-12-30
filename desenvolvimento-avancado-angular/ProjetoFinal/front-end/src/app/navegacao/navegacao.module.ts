import { NgModule } from "@angular/core";
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { MenuComponent } from './menu/menu.component';
import { HomeComponent } from './home/home.component';
import { FooterComponent } from './footer/footer.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MenuLoginComponent } from "./menu-login/menu-login.componen";

@NgModule({
    declarations: [
        MenuComponent,
        MenuLoginComponent,
        HomeComponent,
        FooterComponent,
        NotFoundComponent
    ],
    imports: [
        CommonModule,
        RouterModule,
        NgbModule
    ],
    exports: [
        MenuComponent,
        MenuLoginComponent,
        HomeComponent,
        FooterComponent,
        NotFoundComponent
    ]
})
export class NavegacaoModule { }