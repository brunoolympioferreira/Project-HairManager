//Angular
import { AfterViewInit, Component, ElementRef, OnInit, ViewChildren } from '@angular/core';
import { FormBuilder, FormControlName, FormGroup, Validators } from '@angular/forms';
import { FormBaseComponent } from 'src/app/base/form-base-component';
//Utils
import { Funcionario } from '../models/funcionario';
import { FuncionarioService } from '../services/funcionario.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

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
    private funcionarioService: FuncionarioService,
    private router: Router,
    private toastr: ToastrService
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
      endereco: this.fb.group({
        rua: ['', [Validators.required]],
        numero: ['', [Validators.required]],
        complemento: [''],
        bairro: ['', [Validators.required]],
        cidade: ['', [Validators.required]],
        estado: [Number, [Validators.required]],
        pais: ['', [Validators.required]]
      })
    });

  }

  ngAfterViewInit(): void {
    super.configurarValidacaoFormularioBase(this.formInputElements, this.adicionarFuncionarioForm);
    super.validarFormulario(this.adicionarFuncionarioForm)
  }

  adicionarFuncionario() {
    if (this.adicionarFuncionarioForm.dirty && this.adicionarFuncionarioForm.valid) {
      this.funcionario = Object.assign({}, this.funcionario, this.adicionarFuncionarioForm.value);

      this.funcionarioService.registrarFuncionario(this.funcionario)
        .subscribe(
          sucesso => { this.processarSucesso(sucesso) },
          falha => { this.processarFalha(falha) }
        );
      console.log(this.funcionario)
    }
  }

  processarSucesso(response: any) {
    this.adicionarFuncionarioForm.reset();
    this.errors = [];

    let toast = this.toastr.success('Registro realizado com sucesso!', 'Funcionario Adicionado')

    if (toast) {
      toast.onHidden.subscribe(() => {
        this.router.navigate(['/home'])
      });
    }

  }

  processarFalha(fail: any) {
    this.errors = fail.error.errors;
    this.toastr.error('Ocurreu um erro!', 'Opa :(');
  }
}
