import { NgModule } from "@angular/core";
import { FuncionarioAppComponent } from "./funcionario.app.component";
import { CommonModule } from "@angular/common";
import { RouterModule } from "@angular/router";
import { FuncionarioRountingModule } from "./funcionario.route";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { AdicionarFuncionarioComponent } from "./adicionar-funcionario/adicionar-funcionario.component";

@NgModule({
  declarations: [
    FuncionarioAppComponent,
    AdicionarFuncionarioComponent,
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

  ]
})
export class FuncionarioModule { }
