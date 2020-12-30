import { createComponent } from "@angular/compiler/src/core";
import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { LocalStorageUtils } from "src/app/utils/localstorage";

@Component({
    selector: 'app-menu-login',
    templateUrl: './menu-login.component.html'
})
export class MenuLoginComponent{
    token: string = "";
    user: any;
    email: string = "";
    localStorageUtils = new LocalStorageUtils();

    constructor(private router: Router){}
    
    usuarioLogado(): boolean {
        this.token = this.localStorageUtils.obterTokenUsuario();
        this.user = this.localStorageUtils.obterUsuario();

        if (this.user)
            this.email = this.user.email;

        return this.token !== null;
    }
    
    logout() {
        this.localStorageUtils.limparDadosLocaisUsuario();
        this.router.navigate(['/home']);
    }
}