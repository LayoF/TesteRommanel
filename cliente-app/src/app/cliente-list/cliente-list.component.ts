import { Component, OnInit } from '@angular/core';
import { ClienteService, Cliente } from '../cliente.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-cliente-list',
  templateUrl: './cliente-list.component.html',
  styleUrls: ['./cliente-list.component.css']
})
export class ClienteListComponent implements OnInit {
  clientes: Cliente[] = [];

  constructor(private clienteService: ClienteService) {}

  ngOnInit() {
    this.carregarClientes();
  }

  carregarClientes() {
    this.clienteService.getClientes().subscribe(data => {
      this.clientes = data;
    });
  }

  excluirCliente(id: string) {
    Swal.fire({
      title: 'Tem certeza?',
      text: 'Você deseja excluir este cliente?',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Sim, excluir!',
      cancelButtonText: 'Cancelar'
    }).then(result => {
      if (result.isConfirmed) {
        this.clienteService.deleteCliente(id).subscribe(() => {
          Swal.fire('Excluído!', 'O cliente foi removido.', 'success');
          this.carregarClientes();
        });
      }
    });
  }
}