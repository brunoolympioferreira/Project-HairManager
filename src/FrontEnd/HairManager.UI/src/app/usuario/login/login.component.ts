//Angular
import { Component, ElementRef, OnInit, ViewChildren } from '@angular/core';
import { FormControlName, FormGroup } from '@angular/forms';
import { FormBuilder, Validators } from '@angular/forms';
//Utils
import { FormBaseComponent } from 'src/app/base/form-base-component';
import { Usuario } from '../models/usuario';
import { CustomValidators } from '@narik/custom-validators';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent extends FormBaseComponent implements OnInit {
  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  errors: any[] = [];
  loginForm: FormGroup;
  usuario: Usuario;

  returnUrl: string;

  constructor(
    private fb: FormBuilder,
  ) {
    super();

    this.validationMessages = {
      email: {
        required: 'Informe o e-mail',
        email: 'E-mail inválido'
      },
      senha: {
        required: 'Informe a senha',
        rangeLength: 'A senha deve possuir entre 6 e 15 caracteres'
      }
    };

    super.configurarMensagensValidacaoBase(this.validationMessages);
  }


  //this.returnUrl = this.route.snapshot.queryParams['returnUrl'];

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      senha: ['', [Validators.required, CustomValidators.rangeLength([6, 15])]]
    });
  }

  ngAfterViewInit(): void {
    super.configurarValidacaoFormularioBase(this.formInputElements, this.loginForm);
  }

  login() {

  }

  processarSucesso() {

  }

  processarFalha() {

  }

}
