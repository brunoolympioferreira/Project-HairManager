﻿using HairManager.Comunication.DTO;
using HairManager.Comunication.Enums;

namespace HairManager.Comunication.Requests;
public class RequestFuncionarioDTO
{
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Nacionalidade { get; set; }
    public EnderecoDTO Endereco { get; set; }
    public string CTPSNumero { get; set; }
    public string CTPSSerie { get; set; }
    public string CPF { get; set; }
    public string RG { get; set; }
    public string PIS { get; set; }
    public string Reservista { get; set; } // reservista pode ser nulo em caso de mulher -> corrigir no banco de dados
    public string Cargo { get; set; }
    public decimal Salario { get; set; }
    public EstadoCivilEnum EstadoCivil { get; set; }
    public DateTime DataAdmissao { get; set; }
    public DateTime? DataDemissao { get; set; } // Esse campo nao serve para registro de funcionario
    public StatusFuncionarioEnum StatusFuncionario { get; set; }
}
