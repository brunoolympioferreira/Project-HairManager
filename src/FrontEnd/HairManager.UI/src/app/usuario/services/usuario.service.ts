//Angular
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, map, Observable } from "rxjs";
//Utils
import { BaseService } from "src/app/services/base.service";
import { Usuario } from './../models/usuario';

@Injectable()
export class UsuarioService extends BaseService {
  constructor(private http: HttpClient) { super() }

  registrarUsuario(usuario: Usuario): Observable<Usuario> {
    let response = this.http
      .post(this.UrlServiceV1 + 'usuario', usuario, this.ObterHeaderJson())
      .pipe(
        map(this.extractData),
        catchError(this.serviceError));

    return response;
  }

  login(usuario: Usuario): Observable<Usuario> {
    let response = this.http
      .post(this.UrlServiceV1 + 'login', usuario, this.ObterHeaderJson())
      .pipe(
        map(this.extractData),
        catchError(this.serviceError));

    return response;
  }

  ObterUsuario(): Observable<Usuario> {
    return this.http
      .get<Usuario>(this.UrlServiceV1 + "usuario", this.ObterAuthHeaderJson())
      .pipe(catchError(super.serviceError));
  }

  alterarSenha(usuario: Usuario): Observable<Usuario> {
    return this.http
      .put(this.UrlServiceV1 + "usuario/alterar-senha", usuario, super.ObterAuthHeaderJson())
      .pipe(
        map(super.extractData),
        catchError(super.serviceError));
  }
}
