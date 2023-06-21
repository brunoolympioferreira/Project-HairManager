import { FuncionarioAppComponent } from './funcionario.app.component';
import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AdicionarFuncionarioComponent } from './adicionar-funcionario/adicionar-funcionario.component';
import { ListarFuncionariosComponent } from './listar-funcionarios/listar-funcionarios.component';

const funcionarioRouterConfig: Routes = [
  {
    path: '', component: FuncionarioAppComponent,
    children: [
      { path: 'adicionar', component: AdicionarFuncionarioComponent },
      { path: 'dash-funcionarios', component: ListarFuncionariosComponent }
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
