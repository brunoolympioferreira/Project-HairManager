import { FuncionarioService } from './../services/funcionario.service';
import { Funcionario } from './../models/funcionario';
import { Component, ElementRef, OnInit, ViewChildren } from '@angular/core';
import { FormBuilder, FormControlName, FormGroup, Validators } from '@angular/forms';
import { FormBaseComponent } from 'src/app/base/form-base-component';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-editar-funcionario',
  templateUrl: './editar-funcionario.component.html'
})
export class EditarFuncionarioComponent extends FormBaseComponent implements OnInit {
  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  errors: any[] = [];
  errosEndereco: any[] = []
  editarFuncionarioForm: FormGroup;

  funcionario: Funcionario;

  textoDocumento: string = '';

  constructor(private fb: FormBuilder,
    private FuncionarioService: FuncionarioService,
    private router: Router,
    private toastr: ToastrService,
    private route: ActivatedRoute) {
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
    };
    super.configurarMensagensValidacaoBase(this.validationMessages);

    this.route.snapshot.data['funcionario'];
  }

  ngOnInit() {
    this.editarFuncionarioForm = this.fb.group({
      nome: [{ value: '', disabled: true }, [Validators.required]],
      telefone: ['', [Validators.required]],
      dataNascimento: [{ value: Date, disabled: true }, [Validators.required]],
      nacionalidade: [{ value: '', disabled: true }, [Validators.required]],
      ctpsNumero: [{ value: '', disabled: true }, [Validators.required]],
      ctpsSerie: [{ value: '', disabled: true }, [Validators.required]],
      cpf: [{ value: '', disabled: true }, [Validators.required]],
      rg: [{ value: '', disabled: true }, [Validators.required]],
      pis: [{ value: '', disabled: true }, [Validators.required]],
      reservista: [{ value: '', disabled: true }, [Validators.required]],
      cargo: ['', [Validators.required]],
      salario: [Number, [Validators.required]],
      estadoCivil: [Number, [Validators.required]],
      dataAdmissao: [{ value: Date, disabled: true }, [Validators.required]],
      //add data demissao
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
    this.preencherForm();
  }

  preencherForm() {

  }

  ngAfterViewInit() {

  }

  editarFuncionario() {

  }

  processarSucesso() {

  }

  processarFalha() {

  }
}
