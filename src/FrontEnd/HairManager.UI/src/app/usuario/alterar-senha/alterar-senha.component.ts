//Angular
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AfterViewInit, Component, ElementRef, OnInit, ViewChildren } from '@angular/core';
import { FormControlName } from '@angular/forms';
//Utils
import { ToastrService } from 'ngx-toastr';
import { FormBaseComponent } from 'src/app/base/form-base-component';
import { Usuario } from '../models/usuario';
import { UsuarioService } from '../services/usuario.service';
import { CustomValidators } from '@narik/custom-validators';

@Component({
  selector: 'app-alterar-senha',
  templateUrl: './alterar-senha.component.html'
})
export class AlterarSenhaComponent extends FormBaseComponent implements OnInit, AfterViewInit {
  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  errors: any[] = [];
  alterarSenhaForm: FormGroup;
  usuario: Usuario;

  returnUrl: string;

  constructor(
    private fb: FormBuilder,
    private usuarioService: UsuarioService,
    private router: Router,
    private route: ActivatedRoute,
    private toastr: ToastrService) {
    super();

    this.validationMessages = {
      senhaAtual: {
        required: 'Informe a senha atual',
        rangeLength: 'A senha deve possuir entre 6 e 15 caracteres'
      },
      novaSenha: {
        required: 'Informe a nova senha',
        rangeLength: 'A senha deve possuir entre 6 e 15 caracteres'
      },
      confirmeNovaSenha: {
        required: 'Informe a nova senha',
        rangeLength: 'A senha deve possuir entre 6 e 15 caracteres',
        equalTo: 'As senhas não conferem'
      }
    };
    super.configurarMensagensValidacaoBase(this.validationMessages);
  }

  ngOnInit(): void {
    let password = new FormControl('', [Validators.required, CustomValidators.rangeLength([6, 15])]);
    let confirmPassword = new FormControl('', [Validators.required, CustomValidators.rangeLength([6, 15]), CustomValidators.equalTo(password)]);

    this.alterarSenhaForm = this.fb.group({
      senhaAtual: ['', [Validators.required]],
      novaSenha: password,
      confirmeNovaSenha: confirmPassword
    });
  }

  ngAfterViewInit(): void {
    super.configurarValidacaoFormularioBase(this.formInputElements, this.alterarSenhaForm)
  }

  alterarSenha() {
    if (this.alterarSenhaForm.dirty && this.alterarSenhaForm.valid) {
      this.usuario = Object.assign({}, this.usuario, this.alterarSenhaForm.value);

      this.usuarioService.alterarSenha(this.usuario)
        .subscribe(
          sucesso => { this.processarSucesso(sucesso) },
          falha => { this.processarFalha(falha) }
        );
    }
  }

  processarSucesso(response: any) {
    this.alterarSenhaForm.reset();
    this.errors = [];

    let toast = this.toastr.success('Senha alterada com sucesso!', 'Sucesso');

    if (toast) {
      toast.onHidden.subscribe(() => {
        this.router.navigate(['/home'])
        location.reload()
      });
    }
  }

  processarFalha(fail: any) {
    this.errors = fail.error.errors;
    this.toastr.error('Ocurreu um erro!', 'Opa :(');
  }

  closeModal() {
    const modalAlterarSenha = document.getElementById('')
  }
}
