import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthComponent } from './auth/auth.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { CartaoComponent } from './cartao/cartao.component';
import { RegistrarComponent } from './registrar/registrar.component';
import { VacinasComponent } from './vacinas/vacinas.component';
import { ContaComponent } from './conta/conta.component';
import { ApiService } from './shared/services/api.service';
import { CartaoVacinacao, CurrentUser, RegistroVacinacao, Vacina } from './shared/models/models';

type Page = 'dashboard' | 'cartao' | 'registrar' | 'vacinas' | 'conta';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    CommonModule,
    AuthComponent,
    DashboardComponent,
    CartaoComponent,
    RegistrarComponent,
    VacinasComponent,
    ContaComponent
  ],
  templateUrl: './app.component.html'
})
export class AppComponent {
  isLoggedIn = false;
  page: Page = 'dashboard';
  currentUser: CurrentUser = { userName: '', contaId: 0 };
  cartao: CartaoVacinacao = { vacinas: [] };
  cartaoMsg: string | null = null;
  vacinas: Vacina[] = [];
  deleteTarget: RegistroVacinacao | null = null;
  deleteLoading = false;

  constructor(private api: ApiService) {}

  onLoggedIn(user: CurrentUser) {
    this.currentUser = user;
    this.isLoggedIn = true;
    this.loadCartao();
  }

  logout() {
    this.isLoggedIn = false;
    this.api.token.set(null);
    this.api.currentUser.set(null);
    this.currentUser = { userName: '', contaId: 0 };
    this.cartao = { vacinas: [] };
  }

  navigate(p: Page) {
    this.page = p;
    if (p === 'cartao') this.loadCartao();
  }

  loadCartao() {
    this.cartaoMsg = 'Carregando...';
    this.api.getCartaoVacinacao(this.currentUser.contaId).subscribe({
      next: (data) => { this.cartao = data; this.cartaoMsg = null; },
      error: () => { this.cartaoMsg = 'Erro ao carregar o cartão.'; }
    });
  }

  onDeleteRequest(v: RegistroVacinacao) {
    this.deleteTarget = v;
  }

  confirmDelete() {
    if (!this.deleteTarget) return;
    this.deleteLoading = true;
    this.api.deleteVacinacao(this.deleteTarget.vacinacaoId).subscribe({ 
      next: () => {
        this.deleteTarget = null;
        this.deleteLoading = false;
        this.loadCartao();
      },
      error: (err) => {
        this.cartaoMsg = this.api.extractError(err);
        this.deleteTarget = null;
        this.deleteLoading = false;
      }
    });
  }

  cancelDelete() {
    this.deleteTarget = null;
  }
}
