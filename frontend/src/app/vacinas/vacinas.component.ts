import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ApiService } from '../shared/services/api.service';
import { Vacina } from '../shared/models/models';

@Component({
  selector: 'app-vacinas',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './vacinas.component.html'
})
export class VacinasComponent implements OnInit {
  vacinas: Vacina[] = [];
  loading = false;
  nome = '';
  msg: string | null = null;
  msgOk = false;

  constructor(private api: ApiService) {}

  ngOnInit() {
    this.api.getVacinas().subscribe({
      next: (data) => this.vacinas = data,
      error: (err) => console.error('Erro ao carregar vacinas', err)
    });
  }

  cadastrar() {
    this.msg = null;
    if (!this.nome.trim()) { this.msg = 'Informe o nome da vacina.'; this.msgOk = false; return; }
    this.loading = true;
    this.api.createVacina(this.nome.trim()).subscribe({
      next: (res) => {
        this.msg = `Vacina "${res.nomeVacina}" cadastrada!`; this.msgOk = true;
        this.vacinas.push({ nomeVacina: res.nomeVacina, vacinaId: res.vacinaId ?? this.vacinas.length + 1 });
        this.nome = '';
        this.loading = false;
      },
      error: (err) => { this.msg = this.api.extractError(err); this.msgOk = false; this.loading = false; }
    });
  }
}