import { Component, EventEmitter, Output, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ApiService } from '../shared/services/api.service';
import { CurrentUser } from '../shared/models/models';

@Component({
  selector: 'app-auth',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './auth.component.html'
})
export class AuthComponent {
  @Output() loggedIn = new EventEmitter<CurrentUser>();

  tab: 'login' | 'signup' = 'login';
  loading = false;
  msg: string | null = null;
  msgOk = false;

  loginForm = { userName: '', cpfCnpj: '' };
  signupForm = { userName: '', cpfCnpj: '' };

  constructor(private api: ApiService) {}

  doLogin() {
    this.msg = null;
    if (!this.loginForm.userName || !this.loginForm.cpfCnpj) {
      this.msg = 'Preencha todos os campos.'; this.msgOk = false; return;
    }
    this.loading = true;
    this.api.login(this.loginForm).subscribe({
      next: (res) => {
        this.api.token.set(res.token);
        let contaId: number = 0;
        try {
          const payload = JSON.parse(atob(res.token.split('.')[1]));
          contaId = Number(payload['ContaId'] ?? payload['contaId'] ?? 0);
        } catch {}
        const user: CurrentUser = { userName: this.loginForm.userName, contaId };
        this.api.currentUser.set(user);
        this.loggedIn.emit(user);
        this.loading = false;
      },
      error: (err) => {
        this.msg = this.api.extractError(err);
        this.msgOk = false;
        this.loading = false;
      }
    });
  }

  doSignup() {
    this.msg = null;
    if (!this.signupForm.userName || !this.signupForm.cpfCnpj) {
      this.msg = 'Preencha todos os campos.'; this.msgOk = false; return;
    }
    this.loading = true;
    this.api.signup(this.signupForm).subscribe({
      next: () => {
        this.msg = 'Conta criada com sucesso! Agora faça login.';
        this.msgOk = true;
        this.signupForm = { userName: '', cpfCnpj: '' };
        this.loading = false;
        setTimeout(() => { this.tab = 'login'; this.msg = null; }, 2000);
      },
      error: (err) => {
        this.msg = this.api.extractError(err);
        this.msgOk = false;
        this.loading = false;
      }
    });
  }
}
