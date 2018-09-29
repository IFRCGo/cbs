import { DataCollector } from './../domain/data-collector';
import 'rxjs/add/operator/toPromise';
import { environment } from '../../environments/environment';

import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const API_URL = environment.api + '/api/datacollectors';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()
export class DataCollectorService {

  constructor(private http: HttpClient) { }

  getAllDataCollectors (): Observable<DataCollector[]> {
    return this.http.get<DataCollector[]>(API_URL);
  }

  getDataCollector(id: string): Observable<DataCollector[]> {
    const url = `${API_URL}/${id}`;
    return this.http.get<DataCollector[]>(url, httpOptions);
  }
  getDataCollectorsPromise(): Promise<DataCollector[]> {
    return this.http
        .get(API_URL, {headers: httpOptions.headers})
        .toPromise() as Promise<DataCollector[]>;
  }
  getDataCollectorPromise(id: string): Promise<DataCollector[]> {
    const url = `${API_URL}/${id}`;
    return this.http
        .get(url, {headers: httpOptions.headers})
        .toPromise() as Promise<DataCollector[]>;
  }
}
