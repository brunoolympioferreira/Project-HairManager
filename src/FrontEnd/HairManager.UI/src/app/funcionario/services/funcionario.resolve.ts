import { ActivatedRouteSnapshot, Resolve } from "@angular/router";
import { Funcionario } from "../models/funcionario";
import { FuncionarioService } from "./funcionario.service";
import { Injectable } from "@angular/core";

@Injectable()
export class FuncionarioResolve implements Resolve<Funcionario>{

    constructor(private funcionarioService: FuncionarioService) { }

    resolve(route: ActivatedRouteSnapshot) {
        return this.funcionarioService.obterPorId(route.params['id']);
    }
}