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



@NgModule({
  declarations: [
    UsuarioAppComponent,
    RegistrarComponent
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
  providers: []
})
export class UsuarioModule { }
