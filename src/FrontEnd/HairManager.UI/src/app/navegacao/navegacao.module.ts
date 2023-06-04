//Angular Imports
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { UsuarioModule } from './../usuario/usuario.module';

//Utils

//Componentes
import { MenuComponent } from './menu/menu.component';
import { FooterComponent } from './footer/footer.component';
import { HomeComponent } from './home/home.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { MenuLoginComponent } from './menu-login/menu-login.component';



@NgModule({
  declarations: [
    MenuComponent,
    FooterComponent,
    HomeComponent,
    NotFoundComponent,
    MenuLoginComponent,
    MenuComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    UsuarioModule
  ],
  exports: [
    MenuComponent,
    FooterComponent,
    HomeComponent
  ]
})
export class NavegacaoModule { }
