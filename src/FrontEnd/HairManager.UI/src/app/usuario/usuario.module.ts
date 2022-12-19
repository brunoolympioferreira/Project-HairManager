import { UsuarioRoutingModule } from './usuario.route';
import { UsuarioAppComponent } from './usuario.app.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RegistrarComponent } from './registrar/registrar.component';
import { Router, RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    UsuarioAppComponent,
    RegistrarComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    UsuarioRoutingModule,
  ],
  providers: []
})
export class UsuarioModule { }
