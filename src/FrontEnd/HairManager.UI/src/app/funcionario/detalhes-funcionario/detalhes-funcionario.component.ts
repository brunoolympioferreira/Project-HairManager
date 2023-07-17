import { ActivatedRoute } from '@angular/router';
import { Funcionario } from './../models/funcionario';
import { Component } from '@angular/core';

@Component({
  selector: 'app-detalhes-funcionario',
  templateUrl: './detalhes-funcionario.component.html'
})
export class DetalhesFuncionarioComponent {
  funcionario: Funcionario

  constructor(private route: ActivatedRoute) {
    this.funcionario = this.route.snapshot.data['funcionario'];
  }

}
