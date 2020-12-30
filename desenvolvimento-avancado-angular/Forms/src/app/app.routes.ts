import { Routes } from '@angular/router';
import { HomeComponent } from './navegacao/home/home.component';
import { SobreComponent } from './institucional/sobre/sobre.component';
<<<<<<< HEAD
import { CadastroComponent } from './demos/reactiveforms/cadastro/cadastro.component';
=======
import { CadastroComponent } from './demos/reactiveForms/cadastro/cadastro.component';
>>>>>>> 5fdc9bdd3bc54b968b51b5edfa02607c4c9b13de

export const rootRouterConfig: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full'},
    { path: 'home', component: HomeComponent},
<<<<<<< HEAD
    { path: 'cadastro', component: CadastroComponent},
    { path: 'sobre', component: SobreComponent }
=======
    { path: 'sobre', component: SobreComponent },
    { path: 'cadastro', component: CadastroComponent }
>>>>>>> 5fdc9bdd3bc54b968b51b5edfa02607c4c9b13de
];