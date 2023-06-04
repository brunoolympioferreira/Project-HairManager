import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LocalStorageUtils } from 'src/app/utils/localStorage';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent {

  token: string = "";
  nome: string = "";
  localStorageUtils = new LocalStorageUtils();

  constructor(private router: Router) { }

  usuarioLogado(): boolean {
    this.token = this.localStorageUtils.obterTokenUsuario();
    this.nome = this.localStorageUtils.obterNomeUsuario();

    return this.token !== null;
  }

}
