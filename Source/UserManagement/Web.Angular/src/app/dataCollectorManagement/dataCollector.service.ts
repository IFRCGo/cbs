import { DataCollector } from './../domain/dataCollector';
import 'rxjs/add/operator/toPromise';
import { environment } from '../../environments/environment'; 

import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';


@Injectable()
export class DataCollectorService {
  private headers = new Headers({ 'Content-Type': 'application/json' });

  constructor(private http: Http) { }

  saveDataCollector(dataCollector: DataCollector): Promise<void> {
    const url = environment.api + '/api/dataCollectors';

    return this.http
      .post(url, JSON.stringify(dataCollector), { headers: this.headers })
      .toPromise()
      .then(() => { console.log('DataCollector user added successfully'); })
      .catch((error) => console.error(error));
  }

  getAllDataCollectors(): Promise<void> {
    const url = environment.api + '/api/dataCollectors';

    return this.http
      .get(url, { headers: this.headers })
      .toPromise()
      .then((users) => { console.log(users); })
      .catch((error) => console.error(error));
  }
}
