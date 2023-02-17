import { NotFoundComponent } from './navegacao/not-found/not-found.component';
//Angular
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

//Rotas
import { HomeComponent } from './navegacao/home/home.component';

//Utils

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },

  {
    path: 'usuario',
    loadChildren: () => import('./usuario/usuario.module')
      .then(m => m.UsuarioModule)
  },


  { path: 'nao-encontrado', component: NotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
