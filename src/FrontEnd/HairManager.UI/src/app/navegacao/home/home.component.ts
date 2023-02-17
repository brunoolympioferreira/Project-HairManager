import { Component } from '@angular/core';
import { LocalStorageUtils } from 'src/app/utils/localStorage';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {

  token: string = "";
  nome: string = "";
  localStorageUtils = new LocalStorageUtils();

  usuarioLogado(): boolean {
    this.token = this.localStorageUtils.obterTokenUsuario();
    this.nome = this.localStorageUtils.obterNomeUsuario();

    return this.token !== null;
  }
}
