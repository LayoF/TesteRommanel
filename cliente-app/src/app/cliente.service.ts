import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

const API_URL = 'http://localhost:5000/api/clientes';

export interface Cliente {
  id: string;
  nome: string;
  cpfCnpj: string;
  tipo: 'F' | 'J';
  dataNascimento?: string;
  telefone: string;
  email: string;
  inscricaoEstadual?: string;
  isentoIE: boolean;
}

@Injectable({
  providedIn: 'root',
})
export class ClienteService {
  constructor(private http: HttpClient) {}

  getClientes(): Observable<Cliente[]> {
    return this.http.get<Cliente[]>(API_URL);
  }

  getCliente(id: string): Observable<Cliente> {
    return this.http.get<Cliente>(`${API_URL}/${id}`);
  }

  createCliente(cliente: Cliente): Observable<Cliente> {
    return this.http.post<Cliente>(API_URL, cliente);
  }

  updateCliente(id: string, cliente: Cliente): Observable<Cliente> {
    return this.http.put<Cliente>(`${API_URL}/${id}`, cliente);
  }

  deleteCliente(id: string): Observable<void> {
    return this.http.delete<void>(`${API_URL}/${id}`);
  }
}