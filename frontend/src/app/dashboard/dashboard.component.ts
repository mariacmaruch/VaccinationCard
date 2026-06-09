import { Component, Input } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { CartaoVacinacao, CurrentUser } from '../shared/models/models';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule, DatePipe],
  templateUrl: './dashboard.component.html'
})
export class DashboardComponent {
  @Input() cartao: CartaoVacinacao = { vacinas: [] };
  @Input() currentUser: CurrentUser = { userName: '', contaId: 0 };

  get uniqueVaccines(): number {
    if (!this.cartao.vacinas) return 0;
    return new Set(this.cartao.vacinas.map(v => v.nomeVacina)).size;
  }
}
