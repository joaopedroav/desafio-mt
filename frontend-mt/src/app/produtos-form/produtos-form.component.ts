import { Component, OnInit, Input, Output, EventEmitter, OnChanges, SimpleChanges } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProdutoCreate } from '../_models/produtoCreate';
import { ProdutoService } from '../_services/produto.service';
import { DepartamentoService } from '../_services/departamento.service';
import { Departamento } from '../_models/departamento';

@Component({
  selector: 'app-produtos-form',
  standalone: false,
  templateUrl: './produtos-form.component.html',
  styleUrl: './produtos-form.component.scss'
})
export class ProdutosFormComponent implements OnInit, OnChanges {
  @Input() produtoToBeSaved: any = {};
  @Input() showModal: boolean = false;
  @Output() save = new EventEmitter<any>();
  @Output() cancel = new EventEmitter<void>();

  erro: string | null = null;
  produtoForm: FormGroup;

  departamentos: Departamento[] = [];

  constructor(
    private formBuilder: FormBuilder,
    private produtoService: ProdutoService,
    private departamentoService: DepartamentoService
  ) {
    this.produtoForm = this.formBuilder.group({
      id: [''],
      codigo: ['', [Validators.required, Validators.maxLength(4)]],
      descricao: ['', [Validators.required, Validators.maxLength(50)]],
      departamentoId: ['', [Validators.required]],
      preco: [0, [Validators.required, Validators.min(0)]],
      status: [true, [Validators.required]]
    });
   }

  submit() {
    if (this.produtoForm.valid) {
      this.save.emit(this.produtoForm.value);
    }
  }

  close() {
    this.produtoForm.reset();
    this.cancel.emit();
  }

  ngOnInit() {
    this.loadDepartamentos();
  }

  onClose() {
    this.produtoForm.reset();
    this.cancel.emit();
  }

  loadDepartamentos(): void {
    this.departamentoService.loadDepartamentos()
      .then(response => {
        this.departamentos = response.value;
      })
      .catch(error => {
        this.erro = 'Erro ao carregar os departamentos';
        console.error(error);
      });
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['produtoToBeSaved'] && this.produtoToBeSaved) {
      this.produtoForm.patchValue(this.produtoToBeSaved);
    }
  }
}
