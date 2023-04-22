import { Endereco } from "src/app/base/models/endereco";
import { EstadoCivilEnum } from "./enums/estadoCivilEnum";
import { StatusFuncionarioEnum } from "./enums/statusFuncionarioEnum";

export interface Funcionario {
  id: number,
  telefone: string,
  dataNascimento: Date,
  nacionalidade: string,
  endereco: Endereco,
  ctpsNumero: string,
  ctspSerie: string,
  cpf: string,
  rg: string,
  pis: string,
  reservista: string,
  cargo: string,
  salario: number,
  estadoCivil: EstadoCivilEnum,
  dataAdmissao: Date,
  dataDemissao?: Date,
  statusFuncionario: StatusFuncionarioEnum
}
