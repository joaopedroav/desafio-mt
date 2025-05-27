import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { ProdutoCreate } from '../_models/produtoCreate';
import { ProdutoView } from '../_models/produtoView';

@Injectable({
  providedIn: 'root'
})
export class ProdutoService {

  constructor() { }

  loadProdutos(): Promise<any> {
    return fetch(`${environment.apiBaseUri}/api/Produto`)
      .then(response => response.json())
      .catch(error => {
        console.error('Erro ao buscar produtos:', error);
        throw error;
      });
  }

  loadProduto(id: string): Promise<any> {
    return fetch(`${environment.apiBaseUri}/api/Produto/${id}`)
      .then(response => response.json())
      .catch(error => {
        console.error('Erro ao buscar produto:', error);
        throw error;
      });
  }

  createProduto(produto: ProdutoCreate): Promise<any> {
    return fetch(`${environment.apiBaseUri}/api/Produto/create`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(produto),
    })
      .then(response => response.json())
      .catch(error => {
        console.error('Erro ao salvar novo produto:', error);
        throw error;
      });
  }

  updateProduto(produto: ProdutoView): Promise<any> {
    return fetch(`${environment.apiBaseUri}/api/Produto/update`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify(produto),
    })
      .then(response => response.json())
      .catch(error => {
        console.error('Erro ao atualizar produto:', error);
        throw error;
      });
  }

  removeProduto(id: string): Promise<void> {
    return fetch(`${environment.apiBaseUri}/api/Produto/delete/${id}`, { method: "DELETE" })
      .then(response => {
        if (!response.ok) {
          return Promise.reject(`Erro ao remover: ${response.status} - ${response.statusText}`);
        }
        return;
      });
  }
}
