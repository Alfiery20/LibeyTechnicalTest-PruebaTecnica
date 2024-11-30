import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';
import { LibeyUser } from 'src/app/entities/libeyuser';
import { Region } from 'src/app/entities/region';
import { Province } from 'src/app/entities/province';
import { ubigeo } from 'src/app/entities/ubigeo';
@Injectable({
  providedIn: 'root',
})
export class LocationService {
  constructor(private http: HttpClient) {}

  FindRegion(): Observable<Array<Region>> {
    const uri = `${environment.pathLibeyTechnicalTest}Location/region`;
    return this.http.get<Array<Region>>(uri);
  }

  FindProvince(codRegion : string): Observable<Array<Province>> {
    const uri = `${environment.pathLibeyTechnicalTest}Location/province/${codRegion}`;
    return this.http.get<Array<Province>>(uri);
  }

  FindPUbigeo(codProvince : string): Observable<Array<ubigeo>> {
    const uri = `${environment.pathLibeyTechnicalTest}Location/ubigeo/${codProvince }`;
    return this.http.get<Array<ubigeo>>(uri);
  }
}
