//Angular
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AfterViewInit, Component, ElementRef, OnInit, ViewChildren } from '@angular/core';
import { FormControlName } from '@angular/forms';
//Utils
import { ValidationMessages } from './../../utils/generic-form-validation';
import { FormBaseComponent } from 'src/app/base/form-base-component';
import { CustomValidators } from '@narik/custom-validators';
//Models
import { Usuario } from '../models/usuario';

@Component({
  selector: 'app-registrar',
  templateUrl: './registrar.component.html',
  styleUrls: ['./registrar.component.scss']
})

export class RegistrarComponent extends FormBaseComponent implements OnInit, AfterViewInit {

  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  errors: any[] = [];
  registroForm: FormGroup;
  usuario: Usuario

  constructor(
    private fb: FormBuilder
  ) {

    super();

    this.validationMessages = {
      nome: {
        required: 'Informe o nome'
      },
      email: {
        required: "Informe o email",
        email: "E-mail inválido"
      },
      senha: {
        required: "Informe a senha",
        rangeLength: 'A senha deve possuir entre 6 e 15 caracteres'
      },
      confirmeSenha: {
        required: 'Informe a senha novamente',
        rangeLength: 'A senha deve possuir entre 6 e 15 caracteres',
        equalTo: 'As senhas não conferem'
      }
    }

    super.configurarMensagensValidacaoBase(this.validationMessages);
  }

  ngOnInit(): void {

    let password = new FormControl('', [Validators.required, CustomValidators.rangeLength([6, 15])]);
    let confirmPassword = new FormControl('', [Validators.required, CustomValidators.rangeLength([6, 15]), CustomValidators.equalTo(password)]);

    this.registroForm = this.fb.group({
      nome: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      senha: password,
      confirmeSenha: confirmPassword
    });
  };

  ngAfterViewInit(): void {
    super.configurarValidacaoFormularioBase(this.formInputElements, this.registroForm)
  }


  registrarConta() {

  }

  processarSucesso() {

  }

  processarFalha() {

  }
}
