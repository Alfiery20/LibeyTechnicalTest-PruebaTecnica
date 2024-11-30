import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';
import { LibeyUser } from 'src/app/entities/libeyuser';
import { log } from 'console';
@Injectable({
  providedIn: 'root',
})
export class LibeyUserService {
  constructor(private http: HttpClient) {}
  Find(documentNumber: string): Observable<Array<LibeyUser>> {
    const uri = `${environment.pathLibeyTechnicalTest}LibeyUser/${documentNumber}`;
    return this.http.get<Array<LibeyUser>>(uri);
  }

  Create(libeyUser: LibeyUser): Observable<boolean> {
    console.log('HOLA');

    const uri = `${environment.pathLibeyTechnicalTest}LibeyUser`;
    return this.http.post<boolean>(uri, libeyUser);
  }

  Delete(documentNumber: string): Observable<boolean> {
    const uri = `${environment.pathLibeyTechnicalTest}LibeyUser/${documentNumber}`;
    return this.http.delete<boolean>(uri);
  }
}
