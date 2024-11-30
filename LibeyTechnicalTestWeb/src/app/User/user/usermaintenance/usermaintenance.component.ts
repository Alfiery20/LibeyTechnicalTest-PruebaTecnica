import swal from 'sweetalert2';
import { Component, OnInit } from '@angular/core';
import { LocationService } from '../../../core/service/location/location.service';
import { Region } from '../../../entities/region';
import { Province } from 'src/app/entities/province';
import { ubigeo } from 'src/app/entities/ubigeo';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { log } from 'console';
import { TypeDocumentService } from 'src/app/core/service/typeDocument/typeDocument.service';
import { TypeDocument } from 'src/app/entities/typeDocument';
import { LibeyUser } from '../../../entities/libeyuser';
import { LibeyUserService } from 'src/app/core/service/libeyuser/libeyuser.service';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-usermaintenance',
  templateUrl: './usermaintenance.component.html',
  styleUrls: ['./usermaintenance.component.css'],
})
export class UsermaintenanceComponent implements OnInit {
  formulario: FormGroup;

  ListRegion: Array<Region> = [];
  ListProvince: Array<Province> = [];
  ListUbigeo: Array<ubigeo> = [];

  ListDocument: Array<TypeDocument> = [];

  constructor(
    private libeyUserService: LibeyUserService,
    private locationService: LocationService,
    private typeDocumentService: TypeDocumentService,
    private fb: FormBuilder
  ) {
    this.formulario = this.fb.group({
      TipoDocumento: ['', Validators.required],
      NumeroDocumento: ['', Validators.required],
      Nombre: ['', Validators.required],
      ApellidoPaterno: ['', Validators.required],
      ApellidoMaterno: ['', Validators.required],
      Direccion: ['', Validators.required],
      Region: ['', Validators.required],
      Province: ['', Validators.required],
      Ubigeo: ['', Validators.required],
      Telefono: ['', Validators.required],
      Correo: ['', Validators.required],
      Pass: ['', Validators.required],
    });
  }

  ngOnInit(): void {
    this.locationService.FindRegion().subscribe((region) => {
      this.ListRegion = region;
    });

    this.typeDocumentService.Find().subscribe((documents) => {
      this.ListDocument = documents;
    });
  }

  BuscarProvincia(codRegion: string) {
    this.locationService.FindProvince(codRegion).subscribe((province) => {
      this.ListProvince = province;
    });
  }

  BuscarUbigeo(codProvince: string) {
    this.locationService.FindPUbigeo(codProvince).subscribe((ubigeo) => {
      this.ListUbigeo = ubigeo;
    });
  }

  Restart() {
    this.formulario.reset();
  }

  Submit() {
    var nuevoUsuario: LibeyUser = {
      documentNumber: this.formulario.value.NumeroDocumento,
      documentTypeId: this.formulario.value.TipoDocumento,
      name: this.formulario.value.Nombre,
      fathersLastName: this.formulario.value.ApellidoPaterno,
      mothersLastName: this.formulario.value.ApellidoMaterno,
      address: this.formulario.value.Direccion,
      phone: this.formulario.value.Telefono,
      email: this.formulario.value.Correo,
      password: this.formulario.value.Pass,
      active: true,
      regionCode: this.formulario.value.Region,
      provinceCode: this.formulario.value.Province,
      ubigeoCode: this.formulario.value.Ubigeo,
      documentTypeDescription: '',
    };
    this.libeyUserService.Create(nuevoUsuario).subscribe((response) => {
      if (response) {
        Swal.fire({
          title: 'Proceso Exitoso!',
          text: 'Usuario Registrado!',
          icon: 'success',
        });
        this.Restart();
      }
    });
  }
}
