import { Endereco } from 'src/app/base/models/endereco';
import { FuncionarioService } from './../services/funcionario.service';
import { Funcionario } from './../models/funcionario';
import { Component, ElementRef, OnInit, ViewChildren } from '@angular/core';
import { FormBuilder, FormControlName, FormGroup, Validators } from '@angular/forms';
import { FormBaseComponent } from 'src/app/base/form-base-component';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DatePipe } from '@angular/common';

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
    private funcionarioService: FuncionarioService,
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

    this.funcionario = this.route.snapshot.data['funcionario'];
    console.log(this.funcionario)
    console.log(this.funcionario.endereco.rua)
  }

  ngOnInit(): void {
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
      estadoCivil: [0],
      dataAdmissao: [{ value: Date, disabled: true }, [Validators.required]],
      dataDemissao: [Date],
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
    this.editarFuncionarioForm.patchValue({
      nome: this.funcionario.nome,
      telefone: this.funcionario.telefone,
      dataNascimento: this.funcionario.dataNascimento,
      nacionalidade: this.funcionario.nacionalidade,
      ctpsNumero: this.funcionario.ctpsNumero,
      ctpsSerie: this.funcionario.ctpsSerie,
      cpf: this.funcionario.cpf,
      rg: this.funcionario.rg,
      pis: this.funcionario.pis,
      reservista: this.funcionario.reservista,
      cargo: this.funcionario.cargo,
      salario: this.funcionario.salario,
      estadoCivil: this.funcionario.estadoCivil,
      dataAdmissao: this.funcionario.dataAdmissao,
      dataDemissao: this.funcionario.dataDemissao,
      statusFuncionario: this.funcionario.statusFuncionario,
      endereco: {
        rua: this.funcionario.endereco.rua,
        numero: this.funcionario.endereco.numero,
        complemento: this.funcionario.endereco.complemento,
        bairro: this.funcionario.endereco.bairro,
        cidade: this.funcionario.endereco.cidade,
        estado: this.funcionario.endereco.estado,
        pais: this.funcionario.endereco.pais
      }
    });
  }



  ngAfterViewInit(): void {
    super.configurarValidacaoFormularioBase(this.formInputElements, this.editarFuncionarioForm);
    super.validarFormulario(this.editarFuncionarioForm)
  }

  editarFuncionario() {
    if (this.editarFuncionarioForm.dirty && this.editarFuncionarioForm.valid) {

      this.funcionario = Object.assign({}, this.funcionario, this.editarFuncionarioForm.value);

      this.funcionarioService.atualizarFuncionario(this.funcionario)
        .subscribe({
          next: sucesso => { this.processarSucesso(sucesso) },
          error: falha => { this.processarFalha(falha) }
        })
    }
  }

  processarSucesso(response: any) {
    this.errors = [];

    let toast = this.toastr.success('Funcionário atualizado com sucesso!', 'Sucesso');
    if (toast) {
      toast.onHidden.subscribe(() => {
        this.router.navigate(['/funcionario/dash-funcionarios'])
      });
    }
  }

  processarFalha(fail: any) {
    this.errors = fail.error.errors;
    this.toastr.error('Ocorreu um erro!', 'Opa :(');
  }
}
