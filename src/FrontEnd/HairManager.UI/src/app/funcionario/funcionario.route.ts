import { FuncionarioAppComponent } from './funcionario.app.component';
import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AdicionarFuncionarioComponent } from './adicionar-funcionario/adicionar-funcionario.component';
import { ListarFuncionariosComponent } from './listar-funcionarios/listar-funcionarios.component';
import { DetalhesFuncionarioComponent } from './detalhes-funcionario/detalhes-funcionario.component';
import { FuncionarioResolve } from './services/funcionario.resolve';

const funcionarioRouterConfig: Routes = [
  {
    path: '', component: FuncionarioAppComponent,
    children: [
      { path: 'adicionar', component: AdicionarFuncionarioComponent },
      { path: 'dash-funcionarios', component: ListarFuncionariosComponent },
      {
        path: 'detalhes/:id', component: DetalhesFuncionarioComponent,
        resolve: {
          funcionario: FuncionarioResolve
        }
      }
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
