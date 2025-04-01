import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ClienteService, Cliente } from '../cliente.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-cliente-form',
  templateUrl: './cliente-form.component.html',
  styleUrls: ['./cliente-form.component.css']
})
export class ClienteFormComponent {
  clienteForm: FormGroup;

  constructor(private fb: FormBuilder, private clienteService: ClienteService) {
    this.clienteForm = this.fb.group({
      nome: ['', Validators.required],
      cpfCnpj: ['', [Validators.required]],
      tipo: ['F', Validators.required],
      dataNascimento: [''],
      telefone: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      inscricaoEstadual: [''],
      isentoIE: [false]
    });

    this.onTipoChange();
  }

  onTipoChange() {
    this.clienteForm.get('tipo')?.valueChanges.subscribe(tipo => {
      if (tipo === 'F') {
        this.clienteForm.get('dataNascimento')?.setValidators([Validators.required]);
        this.clienteForm.get('inscricaoEstadual')?.clearValidators();
      } else {
        this.clienteForm.get('dataNascimento')?.clearValidators();
        this.clienteForm.get('inscricaoEstadual')?.setValidators([Validators.required]);
      }
      this.clienteForm.get('dataNascimento')?.updateValueAndValidity();
      this.clienteForm.get('inscricaoEstadual')?.updateValueAndValidity();
    });
  }

  salvarCliente() {
    if (this.clienteForm.invalid) {
      Swal.fire('Erro', 'Preencha todos os campos obrigatórios!', 'error');
      return;
    }

    const cliente: Cliente = this.clienteForm.value;

    this.clienteService.createCliente(cliente).subscribe(() => {
      Swal.fire('Sucesso', 'Cliente cadastrado com sucesso!', 'success');
      this.clienteForm.reset();
    }, (error: any) => {
      Swal.fire('Erro', 'Erro ao cadastrar cliente.', 'error');
    });
  }
}