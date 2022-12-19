import { RegistrarComponent } from './registrar/registrar.component';
//Angular
import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

//Rotas
import { UsuarioAppComponent } from './usuario.app.component';


const usuarioRouterConfig: Routes = [
  {
    path: '', component: UsuarioAppComponent,
    children: [
      { path: 'registro', component: RegistrarComponent },
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

