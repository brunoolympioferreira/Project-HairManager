//Angular
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AfterViewInit, Component, ElementRef, OnInit, ViewChildren } from '@angular/core';
import { FormControlName } from '@angular/forms';
import { Router } from '@angular/router';
//Utils
import { FormBaseComponent } from 'src/app/base/form-base-component';
import { CustomValidators } from '@narik/custom-validators';
import { ToastrService } from 'ngx-toastr';
//Models e Services
import { Usuario } from '../models/usuario';
import { UsuarioService } from '../services/usuario.service';

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
    private fb: FormBuilder,
    private usuarioService: UsuarioService,
    private router: Router,
    private toastr: ToastrService) {

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
      confirmeSenha: confirmPassword,
      status: ['', [Validators.required]]
    });

    this.registroForm.patchValue({ ativo: true })

  }

  ngAfterViewInit(): void {
    super.configurarValidacaoFormularioBase(this.formInputElements, this.registroForm)
  }


  registrarConta() {
    if (this.registroForm.dirty && this.registroForm.valid) {
      this.usuario = Object.assign({}, this.usuario, this.registroForm.value);

      this.usuarioService.registrarUsuario(this.usuario)
        .subscribe(
          sucesso => { this.processarSucesso(sucesso) },
          falha => { this.processarFalha(falha) }
        );
      console.log(this.usuario)
    }
  }

  processarSucesso(response: any) {
    this.registroForm.reset();
    this.errors = [];

    this.usuarioService.LocalStorage.salvarDadosLocaisUsuario(response);

    let toast = this.toastr.success('Registro realizado com sucesso!', 'Bem vindo!!!');

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
