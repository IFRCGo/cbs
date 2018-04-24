import {Injectable} from '@angular/core';
import {CaseReportForListing} from '../../../shared/models/case-report-for-listing.model';

import 'rxjs/add/operator/toPromise';
import 'rxjs/add/observable/forkJoin';

import {Headers, Http} from '@angular/http';

import {environment} from '../../../../environments/environment';

@Injectable()
export class CaseReportExporter {
  private headers = new Headers({'Content-Type': 'application/json'});
  constructor(private http: Http) {
  }

  exportToExcel(filter: string, orderBy: string, direction: string): void {
    //TODO: Export to pdf should work on the backend now, we just need to make a button for exporting
    const url = `${environment.api}/api/casereports/export/excel?` +
                `filter=${filter}&orderBy=${orderBy}&direction=${direction}`;

    console.log(url);
    window.open(url, '_blank');
    // return this.http.get(`${environment.api}/api/casereports/export/excel`, {headers: this.headers})
    //   .toPromise()
    //   .then(res => {
    //       const blob = new Blob([res], {type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet'});
    //       console.log(blob);
    //       return blob;
    //   })
    //   .catch(error => console.error(error));
  }
  exportToPdf(filter: string, orderBy: string, direction: string): void {
    //TODO: Export to pdf should work on the backend now, we just need to make a button for exporting
    const url = `${environment.api}/api/casereports/export/pdf?` +
                `filter=${filter}&orderBy=${orderBy}&direction=${direction}`;

    console.log(url);
    window.open(url, '_blank');
    // return this.http.get(`${environment.api}/api/casereports/export/pdf`, {headers: this.headers})
    //   .toPromise()
    //   .then(res => {
    //       return res;
    //   })
    //   .catch(error => console.error(error));
  }

  exportToCsv(filter: string, orderBy: string, direction: string): void {
    //TODO: Export to pdf should work on the backend now, we just need to make a button for exporting
    const url = `${environment.api}/api/casereports/export/csv?` +
                `filter=${filter}&orderBy=${orderBy}&direction=${direction}`;

    console.log(url);
    window.open(url, '_blank');
    // return this.http.get(`${environment.api}/api/casereports/export/csv`, {headers: this.headers})
    //   .toPromise()
    //   .then(res => {
    //       return res;
    //   })
    //   .catch(error => console.error(error));
  }
}
