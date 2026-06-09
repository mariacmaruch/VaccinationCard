import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ApiService } from '../shared/services/api.service';
import { Vacina } from '../shared/models/models';

@Component({
  selector: 'app-registrar',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './registrar.component.html'
})
export class RegistrarComponent implements OnInit {
  @Input() contaId: number = 0;
  @Output() vacinacaoRegistrada = new EventEmitter<void>();

  vacinas: Vacina[] = [];  
  loading = false;

  vacForm = { vacinaId: '', dose: '' };
  vacMsg: string | null = null;
  vacOk = false;

  vacFormOther = { contaId: 0, vacinaId: 0, dose: 0 };
  vacMsgOther: string | null = null;
  vacOkOther = false;

  constructor(private api: ApiService) {}

  ngOnInit() {
    this.api.getVacinas().subscribe({
      next: (data) => this.vacinas = data,
      error: (err) => console.error('Erro ao carregar vacinas', err)
    });
  }

  registrar() {
    this.vacMsg = null;
    if (!this.vacForm.vacinaId || !this.vacForm.dose) {
      this.vacMsg = 'Preencha todos os campos.'; this.vacOk = false; return;
    }
    this.loading = true;
    this.api.createVacinacao({
      contaId: Number(this.contaId),
      vacinaId: Number(this.vacForm.vacinaId),
      dose: Number(this.vacForm.dose)
    }).subscribe({
      next: () => {
        this.vacMsg = 'Vacinação registrada com sucesso!'; this.vacOk = true;
        this.vacForm = { vacinaId: '', dose: '' };
        this.vacinacaoRegistrada.emit();
        this.loading = false;
      },
      error: (err) => { this.vacMsg = this.api.extractError(err); this.vacOk = false; this.loading = false; }
    });
  }

  registrarOutra() {
    this.vacMsgOther = null;
    if (!this.vacFormOther.contaId || !this.vacFormOther.vacinaId || !this.vacFormOther.dose) {
      this.vacMsgOther = 'Preencha todos os campos.'; this.vacOkOther = false; return;
    }
    this.loading = true;
    this.api.createVacinacao({
      contaId: Number(this.vacFormOther.contaId),
      vacinaId: Number(this.vacFormOther.vacinaId),
      dose: Number(this.vacFormOther.dose)
    }).subscribe({
      next: () => {
        this.vacMsgOther = 'Vacinação registrada com sucesso!'; this.vacOkOther = true;
        this.vacFormOther = { contaId: 0, vacinaId: 0, dose: 0 };
        this.loading = false;
      },
      error: (err) => { this.vacMsgOther = this.api.extractError(err); this.vacOkOther = false; this.loading = false; }
    });
  }
}
