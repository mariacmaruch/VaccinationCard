import { Injectable, signal } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { CartaoVacinacao, CurrentUser, Vacina } from '../models/models';
import { map } from 'rxjs/operators';

@Injectable({ providedIn: 'root' })
export class ApiService {
  apiBase = signal('https://localhost:44347');
  token = signal<string | null>(null);
  currentUser = signal<CurrentUser | null>(null);

  constructor(private http: HttpClient) {}

  private headers(): { headers: HttpHeaders } {
    return {
      headers: new HttpHeaders({
        'Authorization': `Bearer ${this.token()}`,
        'Content-Type': 'application/json'
      })
    };
  }

  private headersWithParams(params: HttpParams) {
    return {
      headers: new HttpHeaders({
        'Authorization': `Bearer ${this.token()}`,
        'Content-Type': 'application/json'
      }),
      params
    };
  }

  // AUTH
  login(body: { userName: string; cpfCnpj: string }): Observable<{ token: string }> {
    return this.http.post<{ token: string }>(`${this.apiBase()}/Login/Login`, body);
  }

  signup(body: { userName: string; cpfCnpj: string }): Observable<any> {
    return this.http.post(`${this.apiBase()}/Login/SignUp`, body);
  }

  removeConta(contaId: number): Observable<any> {
    const params = new HttpParams().set('contaId', contaId);
    return this.http.delete(`${this.apiBase()}/Login/RemoveConta`, this.headersWithParams(params));
  }

  // CARTÃO
  getCartaoVacinacao(contaId: number): Observable<CartaoVacinacao> {
    const params = new HttpParams().set('contaId', contaId);
    return this.http.get<CartaoVacinacao>(`${this.apiBase()}/Vacinacao/GetCartaoVacinacao`, this.headersWithParams(params));
  }

  // VACINAÇÃO
  createVacinacao(body: { contaId: number; vacinaId: number; dose: number }): Observable<any> {
    return this.http.post(`${this.apiBase()}/Vacinacao/CreateVacinacao`, body, this.headers());
  }

  deleteVacinacao(vacinacaoId: number): Observable<any> {
    const params = new HttpParams().set('vacinacaoId', vacinacaoId.toString());
    return this.http.delete(`${this.apiBase()}/Vacinacao/Delete`, this.headersWithParams(params));
  }

  // VACINAS
  createVacina(nomeVacina: string): Observable<Vacina> {
    return this.http.post<Vacina>(`${this.apiBase()}/Vacina/CreateVacina`, { nomeVacina }, this.headers());
  }

  getVacinas(): Observable<Vacina[]> {
    return this.http.get<{ vacinas: Vacina[] }>(`${this.apiBase()}/Vacina/GetAllVacinas`, this.headers())
      .pipe(map(res => res.vacinas));
  }

  extractError(error: any): string {
    if (error?.error) {
      if (typeof error.error === 'string') return error.error;
      if (error.error.errors) return Object.values(error.error.errors).flat().join('; ');
      if (error.error.title) return error.error.title;
    }
    return 'Erro na requisição. Verifique o console.';
  }
}
