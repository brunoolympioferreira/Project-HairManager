//Angular
import { AfterViewInit, Component, ElementRef, OnInit, ViewChildren } from '@angular/core';
import { FormBuilder, FormControlName, FormGroup, Validators } from '@angular/forms';
import { FormBaseComponent } from 'src/app/base/form-base-component';
//Utils
import { Funcionario } from '../models/funcionario';
import { Endereco } from 'src/app/base/models/endereco';

@Component({
  selector: 'app-adicionar-funcionario',
  templateUrl: './adicionar-funcionario.component.html',
  styleUrls: ['./adicionar-funcionario.component.scss']
})
export class AdicionarFuncionarioComponent extends FormBaseComponent implements OnInit, AfterViewInit {
  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  errors: any[] = [];
  adicionarFuncionarioForm: FormGroup;
  funcionario: Funcionario;

  constructor(
    private fb: FormBuilder,
  ) {
    super();

    this.validationMessages = {
      nome: {
        required: 'Informe o nome'
      },
      telefone: {
        required: 'Informe o telefone'
      },
      dataNascimento: {
        required: 'Informe a data de nascimento'
      },
      nacionalidade: {
        required: 'Informe a nacionalidade'
      },
      ctpsNumero: {
        required: 'Informe o numero da CTPS'
      },
      ctpsSerie: {
        required: 'Informe o numero da série da CTPS'
      },
      cpf: {
        required: 'Informe o CPF'
      },
      rg: {
        required: 'Informe o RG'
      },
      pis: {
        required: 'Informe o PIS'
      },
      cargo: {
        required: 'Informe o cargo'
      },
      salario: {
        required: 'Informe o salário'
      },
      estadoCivil: {
        required: 'Informe o estado civil'
      },
      dataAdmissao: {
        required: 'Informe a data de admissão'
      },
      statusFuncionario: {
        required: 'Informe o status do funcionário'
      },
      rua: {
        required: 'Informe o nome da rua/avenida.'
      },
      numero: {
        required: 'Informe o número do endereço.'
      },
      bairro: {
        required: 'Informe o nome do bairro.'
      },
      cidade: {
        required: 'Informe o nome da cidade.'
      },
      estado: {
        required: 'Informe o Estado.'
      },
      pais: {
        required: 'Informe o país do endereço.'
      }
    }
    super.configurarMensagensValidacaoBase(this.validationMessages);
  }

  ngOnInit(): void {
    this.adicionarFuncionarioForm = this.fb.group({
      nome: ['', [Validators.required]],
      telefone: ['', [Validators.required]],
      dataNascimento: [Date, [Validators.required]],
      nacionalidade: ['', [Validators.required]],
      ctpsNumero: ['', [Validators.required]],
      ctpsSerie: ['', [Validators.required]],
      cpf: ['', [Validators.required]],
      rg: ['', [Validators.required]],
      pis: ['', [Validators.required]],
      reservista: ['', [Validators.required]],
      cargo: ['', [Validators.required]],
      salario: [Number, [Validators.required]],
      estadoCivil: [Number, [Validators.required]],
      dataAdmissao: [Date, [Validators.required]],
      statusFuncionario: [Number, [Validators.required]],
      rua: ['', [Validators.required]],
      numero: ['', [Validators.required]],
      complemento: [''],
      bairro: ['', [Validators.required]],
      cidade: ['', [Validators.required]],
      estado: [Number, [Validators.required]],
      pais: ['', [Validators.required]],
    });

  }

  ngAfterViewInit(): void {
    super.configurarValidacaoFormularioBase(this.formInputElements, this.adicionarFuncionarioForm);
  }

  adicionarFuncionario() { }
  processarSucesso() { }
  processarFalha() { }
}
