import { ProdutoCreate } from './produtoCreate';

export class ProdutoView extends ProdutoCreate {
    id: string;
    departamento: string;

    constructor(id: string, codigo: string, descricao: string, departamento: string, preco: number, status: boolean) {
        super(codigo, descricao, departamento, preco, status)
        this.id = id;
        this.departamento = departamento;
    }

}