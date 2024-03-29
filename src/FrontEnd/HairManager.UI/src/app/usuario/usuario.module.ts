//Angular
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
//Utils
import { UsuarioRoutingModule } from './usuario.route';
import { NarikCustomValidatorsModule } from '@narik/custom-validators';

//Components
import { UsuarioAppComponent } from './usuario.app.component';
import { RegistrarComponent } from './registrar/registrar.component';
import { UsuarioService } from './services/usuario.service';
import { LoginComponent } from './login/login.component';
import { RecuperarPerfilComponent } from './recuperar-perfil/recuperar-perfil.component';
import { AlterarSenhaComponent } from './alterar-senha/alterar-senha.component';



@NgModule({
  declarations: [
    UsuarioAppComponent,
    RegistrarComponent,
    LoginComponent,
    RecuperarPerfilComponent,
    AlterarSenhaComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    UsuarioRoutingModule,
    NarikCustomValidatorsModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
  ],
  exports: [
    LoginComponent,
    RecuperarPerfilComponent
  ],
  providers: [
    UsuarioService
  ]
})
export class UsuarioModule { }
