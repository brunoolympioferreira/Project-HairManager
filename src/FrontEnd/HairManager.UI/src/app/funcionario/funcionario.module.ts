import { NgModule } from "@angular/core";
import { FuncionarioAppComponent } from "./funcionario.app.component";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";
import { FuncionarioRountingModule } from "./funcionario.route";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { AdicionarFuncionarioComponent } from "./adicionar-funcionario/adicionar-funcionario.component";
import { FuncionarioService } from "./services/funcionario.service";
import { ListarFuncionariosComponent } from './listar-funcionarios/listar-funcionarios.component';
import { DetalhesFuncionarioComponent } from './detalhes-funcionario/detalhes-funcionario.component';
import { FuncionarioResolve } from "./services/funcionario.resolve";

@NgModule({
  declarations: [
    FuncionarioAppComponent,
    AdicionarFuncionarioComponent,
    ListarFuncionariosComponent,
    DetalhesFuncionarioComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    FuncionarioRountingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  exports: [

  ],
  providers: [
    FuncionarioService,
    FuncionarioResolve
  ]
})
export class FuncionarioModule { }
