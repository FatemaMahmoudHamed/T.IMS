import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Constants } from '../constants';
import { Observable } from 'rxjs';
import { DataService } from './data.service';
@Injectable({ providedIn: 'root' })

export class IncidentService extends DataService {
  
  static readonly BASE_URL: string = 'https://localhost:44390/';
  static readonly API_URL: string = Constants.BASE_URL + 'api/';

  constructor(http: HttpClient) {
    super(Constants.INCIDENTS_API_URL, http);
  }
 
  override create(order: any){
    return this.http.post(
      Constants.INCIDENTS_API_URL + '/create',
      order
    );
  }

  getAllCases() {
    return this.http.get(Constants.INCIDENTS_API_URL);
  }

  override get(id:number) {
    return this.http.get(Constants.INCIDENTS_API_URL +'/'+id);
  }
}
