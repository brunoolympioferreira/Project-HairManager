import { UsuarioService } from './../services/usuario.service';
import { Usuario } from './../models/usuario';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-recuperar-perfil',
  templateUrl: './recuperar-perfil.component.html',
  styleUrls: ['./recuperar-perfil.component.scss']
})
export class RecuperarPerfilComponent implements OnInit {

  public usuario: Usuario;
  errorMessage: string;

  constructor(private usuarioService: UsuarioService) { }

  ngOnInit(): void {
    this.usuarioService.ObterUsuario()
      .subscribe(
        usuario => this.usuario = usuario,
        error => this.errorMessage);
  }
}
