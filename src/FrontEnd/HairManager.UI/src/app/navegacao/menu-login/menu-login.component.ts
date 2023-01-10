//Angular
import { Component } from '@angular/core';
import { Router } from '@angular/router';

//Utils
import { LocalStorageUtils } from 'src/app/utils/localStorage';

@Component({
  selector: 'app-menu-login',
  templateUrl: './menu-login.component.html'
})
export class MenuLoginComponent {

  token: string = "";
  nome: string = "";
  localStorageUtils = new LocalStorageUtils();

  constructor(private router: Router) { }

  usuarioLogado(): boolean {
    this.token = this.localStorageUtils.obterTokenUsuario();
    this.nome = this.localStorageUtils.obterNomeUsuario();

    return this.token !== null;
  }


  logout() {
    this.localStorageUtils.limparDadosLocaisUsuario();
    this.router.navigate(['/home']);
  }
}
