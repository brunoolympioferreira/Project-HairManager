import { FuncionarioService } from './../services/funcionario.service';
import { Component, OnInit } from '@angular/core';
import { Funcionario } from '../models/funcionario';

@Component({
  selector: 'app-listar-funcionarios',
  templateUrl: './listar-funcionarios.component.html'
})
export class ListarFuncionariosComponent implements OnInit {

  public funcionarios: Funcionario[];
  errorMessage: string;

  constructor(private funcionarioService: FuncionarioService) { }

  ngOnInit(): void {
    this.funcionarioService.obterTodos()
      .subscribe(
        funcionarios => this.funcionarios = funcionarios,
        error => this.errorMessage);
  }

}
