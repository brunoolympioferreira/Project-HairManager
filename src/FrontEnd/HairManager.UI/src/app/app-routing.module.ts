import { HomeComponent } from './navegacao/home/home.component';
//Angular
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

//Rotas

//Utils

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
