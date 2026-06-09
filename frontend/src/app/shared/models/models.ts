export interface Vacina {
  vacinaId: number;
  nomeVacina: string;
}

export interface RegistroVacinacao {
  vacinacaoId: number;
  nomeVacina: string;
  dose: number;
  dataAplicacao: string;
}

export interface CartaoVacinacao {
  nomeConta?: string;
  vacinas: RegistroVacinacao[];
}

export interface CurrentUser {
  userName: string;
  contaId: number;
}
