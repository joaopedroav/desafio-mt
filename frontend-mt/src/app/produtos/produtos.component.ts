import { Component, OnInit } from '@angular/core';
import { ProdutoService } from '../_services/produto.service';
import { DepartamentoService } from '../_services/departamento.service';
import { ProdutoView } from '../_models/produtoView';
import { faTrash, faEdit, faCheckCircle, faXmarkCircle } from '@fortawesome/free-solid-svg-icons';
import { ProdutoCreate } from '../_models/produtoCreate';
import { ProdutosFormComponent } from '../produtos-form/produtos-form.component';
import { Departamento } from '../_models/departamento';

@Component({
  selector: 'app-produtos',
  standalone: false,
  templateUrl: './produtos.component.html',
  styleUrl: './produtos.component.scss'
})
export class ProdutosComponent implements OnInit {

  produtos: ProdutoView[] = [];
  erro: string | null = null;
  removedProdutoId: string | null = null;

  faTrash = faTrash;
  faEdit = faEdit;
  faCheckCircle = faCheckCircle;
  faXmarkCircle = faXmarkCircle;

  modalVisible = false;
  selectedProduto: any = {};

  constructor(private produtoService: ProdutoService) {}
  
  ngOnInit(): void {
    this.loadProdutos();
  }

  loadProdutos(): void {
    this.produtoService.loadProdutos()
      .then(response => {
        this.produtos = response.value;
      })
      .catch(error => {
        this.erro = 'Erro ao carregar as pessoas';
        console.error(error);
      });
  }

  openNewProduto() {
    this.selectedProduto = {};
    this.modalVisible = true;
  }

  openEditProduto(produto: ProdutoView) {
    this.selectedProduto = { ...produto };
    this.modalVisible = true;
  }

  saveProduto(produto: ProdutoView){
    if (produto.id) {
      this.produtoService.updateProduto(produto)
        .then(response => {
          console.log("Produto atualizado com sucesso");
        })
        .catch(error => {
          this.erro = 'Erro ao salvar o produto';
          console.error(error);
        });
    } else {
      this.produtoService.createProduto(produto)
        .then(response => {
          console.log("Produto criado com sucesso");
        })
        .catch(error => {
          this.erro = 'Erro ao salvar o produto';
          console.error(error);
        });
    }
    this.modalVisible = false;
  }

  cancelOperationSave() {
    this.modalVisible = false;
  }

  openConfirmModal(id: string){
    this.removedProdutoId = id;
  }

  removeProduto(): void {
    if (this.removedProdutoId != undefined)
    this.produtoService.removeProduto(this.removedProdutoId)
      .then(response => {
        console.log('Produto removido com sucesso', response);
        this.removedProdutoId = null;
        this.loadProdutos();
      })
      .catch(error => {
        this.erro = `Erro ao remover produto com ID ${this.removedProdutoId}`;
        console.error(error);
      });
  }
}
