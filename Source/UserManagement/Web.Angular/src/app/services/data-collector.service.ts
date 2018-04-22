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

saveDataCollector(dataCollector: DataCollector): Promise<any> {
  console.log(dataCollector);

  dataCollector.phoneNumbers = dataCollector.phoneNumberString.split(',').map(function(item) {
    return { value: item.trim(), confirmed: false};
  });

  return this.http
    .post(API_URL, JSON.stringify(dataCollector), httpOptions)
    .toPromise();
}

  getAllDataCollectors (): Observable<DataCollector[]> {
    return this.http.get<DataCollector[]>(API_URL);
  }

  getDataCollector(id: string): Observable<DataCollector[]> {
    const url = `${API_URL}/${id}`;
    return this.http.get<DataCollector[]>(url, httpOptions);
  }

  deleteDataCollector(id: string): Promise<void> {
    const url = `${API_URL}/${id}`;
    return this.http
      .delete(url, httpOptions)
      .toPromise()
      .then(() => console.log('User deleted' + id))
      .catch((error) => console.error(error));
  }
}
