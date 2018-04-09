import { DataCollector } from './../domain/data-collector';
import 'rxjs/add/operator/toPromise';
import { environment } from '../../environments/environment';

import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';


@Injectable()
export class DataCollectorService {
  private headers = new Headers({ 'Content-Type': 'application/json' });

  constructor(private http: Http) { }

  saveDataCollector(dataCollector: DataCollector): Promise<any> {
    const url = environment.api + '/api/datacollectors/register';

    console.log(dataCollector);

    dataCollector.phoneNumbers = dataCollector.phoneNumberString.split(',').map(function(item) {
      return item.trim();
    });

    console.log("Register url: " + url);

    return this.http
      .post(url, JSON.stringify(dataCollector), { headers: this.headers })
      .toPromise();
  }

  getAllDataCollectors(): Promise<any> {
    const url = environment.api + '/api/dataCollectors';

    return this.http
      .get(url, { headers: this.headers })
      .toPromise();
  }
}
