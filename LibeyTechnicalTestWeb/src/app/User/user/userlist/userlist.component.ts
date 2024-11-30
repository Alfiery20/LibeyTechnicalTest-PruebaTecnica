import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LibeyUserService } from '../../../core/service/libeyuser/libeyuser.service';
import { LibeyUser } from 'src/app/entities/libeyuser';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-userlist',
  templateUrl: './userlist.component.html',
  styleUrls: ['./userlist.component.css'],
})
export class UserlistComponent implements OnInit {
  Termino = '';
  libeyUsers: LibeyUser[] = [];

  constructor(private libeyUserService: LibeyUserService) {}

  ngOnInit(): void {}

  Buscar() {
    this.libeyUserService.Find(this.Termino).subscribe((users) => {
      this.libeyUsers = users;
    });
  }

  Delete(Termino: string) {
    this.libeyUserService.Delete(Termino).subscribe((response) => {
      if (response) {
        Swal.fire({
          title: 'Proceso Exitoso!',
          text: 'Usuario Eliminado!',
          icon: 'success',
        });
        this.Buscar();
      }
    });
  }
}
