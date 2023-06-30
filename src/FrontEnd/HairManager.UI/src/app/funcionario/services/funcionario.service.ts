import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BaseService } from "src/app/services/base.service";
import { Funcionario } from "../models/funcionario";
import { Observable, catchError, map } from "rxjs";

@Injectable()
export class FuncionarioService extends BaseService {
  constructor(private http: HttpClient) { super() }

  registrarFuncionario(funcionario: Funcionario): Observable<Funcionario> {
    let response = this.http
      .post(this.UrlServiceV1 + 'funcionario', funcionario, this.ObterAuthHeaderJson())
      .pipe(
        map(this.extractData),
        catchError(this.serviceError));

    return response;
  }

  obterTodos(): Observable<Funcionario[]> {
    return this.http
      .get<Funcionario[]>(this.UrlServiceV1 + "funcionario", this.ObterAuthHeaderJson())
      .pipe(catchError(super.serviceError));
  }
}
