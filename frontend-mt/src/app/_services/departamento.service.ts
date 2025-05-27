import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class DepartamentoService {

  constructor() { }

  loadDepartamentos(): Promise<any> {
    return fetch(`${environment.apiBaseUri}/api/Departamento`)
      .then(response => response.json())
      .catch(error => {
        console.error('Erro ao buscar departamentos:', error);
        throw error;
      });
  }
}
