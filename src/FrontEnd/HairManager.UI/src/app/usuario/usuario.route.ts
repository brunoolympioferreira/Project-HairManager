import { AlterarSenhaComponent } from './alterar-senha/alterar-senha.component';
//Angular
import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

//Rotas
import { UsuarioAppComponent } from './usuario.app.component';
import { RegistrarComponent } from './registrar/registrar.component';
import { LoginComponent } from './login/login.component';


const usuarioRouterConfig: Routes = [
  {
    path: '', component: UsuarioAppComponent,
    children: [
      { path: 'registro', component: RegistrarComponent },
      { path: 'login', component: LoginComponent },
      { path: 'alterar-senha', component: AlterarSenhaComponent },
    ]
  }

]

@NgModule({
  imports: [
    RouterModule.forChild(usuarioRouterConfig)
  ],
  exports: []
})

export class UsuarioRoutingModule { }

