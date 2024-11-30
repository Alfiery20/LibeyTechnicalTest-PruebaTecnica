import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TypeDocument } from 'src/app/entities/typeDocument';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class TypeDocumentService {
  constructor(private http: HttpClient) {}

  Find(): Observable<Array<TypeDocument>> {
    const uri = `${environment.pathLibeyTechnicalTest}DocumentType`;
    return this.http.get<Array<TypeDocument>>(uri);
  }
}
