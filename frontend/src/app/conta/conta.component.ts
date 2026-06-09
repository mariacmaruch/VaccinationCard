import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ApiService } from '../shared/services/api.service';
import { CurrentUser } from '../shared/models/models';

@Component({
  selector: 'app-conta',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './conta.component.html'
})
export class ContaComponent {
  @Input() currentUser: CurrentUser = { userName: '', contaId: 0 };
  @Output() contaRemoved = new EventEmitter<void>();

  loading = false;
  msg: string | null = null;

  get apiBase() { return this.api.apiBase(); }
  set apiBase(val: string) { this.api.apiBase.set(val); }

  constructor(private api: ApiService) {}

  removeConta() {
    if (!confirm('Tem certeza? Esta ação é permanente e não pode ser desfeita.')) return;
    this.loading = true;
    this.api.removeConta(this.currentUser.contaId).subscribe({
      next: () => { this.contaRemoved.emit(); this.loading = false; },
      error: (err) => { this.msg = this.api.extractError(err); this.loading = false; }
    });
  }
}
