export class ProdutoCreate {
    codigo: string;
    descricao: string;
    departamentoId: string;
    preco: number;
    status: boolean;

    constructor(codigo: string, descricao: string, departamentoId: string, preco: number, status: boolean) {
        this.codigo = codigo;
        this.descricao = descricao;
        this.departamentoId = departamentoId;
        this.preco = preco;
        this.status = status;
    }

}