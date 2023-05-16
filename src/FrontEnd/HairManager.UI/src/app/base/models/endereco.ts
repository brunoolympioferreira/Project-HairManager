import { EstadosEnum } from "./estadosEnum";

export interface Endereco {
  rua: string,
  numero: string,
  complemento?: string,
  bairro: string,
  cidade: string,
  estado: EstadosEnum,
  pais: string
}
