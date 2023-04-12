import { FuncionarioAppComponent } from './funcionario.app.component';
import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AdicionarFuncionarioComponent } from './adicionar-funcionario/adicionar-funcionario.component';

const funcionarioRouterConfig: Routes = [
  {
    path: '', component: FuncionarioAppComponent,
    children: [
      { path: 'adicionar', component: AdicionarFuncionarioComponent }
    ]
  }
]

@NgModule({
  imports: [
    RouterModule.forChild(funcionarioRouterConfig)
  ],
  exports: []
})

export class FuncionarioRountingModule { }
