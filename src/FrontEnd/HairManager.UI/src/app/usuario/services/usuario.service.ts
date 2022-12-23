//Angular
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, map, Observable } from "rxjs";
//Utils
import { BaseService } from "src/app/services/base.service";
import { Usuario } from "../models/usuario";

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

}
