import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule, DatePipe } from '@angular/common';
import { CartaoVacinacao, RegistroVacinacao } from '../shared/models/models';

@Component({
  selector: 'app-cartao',
  standalone: true,
  imports: [CommonModule, DatePipe],
  templateUrl: './cartao.component.html'
})
export class CartaoComponent {
  @Input() cartao: CartaoVacinacao = { vacinas: [] };
  @Input() cartaoMsg: string | null = null;
  @Output() deleteRequest = new EventEmitter<RegistroVacinacao>();
}
