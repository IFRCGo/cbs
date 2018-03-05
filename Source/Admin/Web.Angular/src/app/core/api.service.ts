import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpHeaders, HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs/Rx';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

@Injectable()
export class ApiService {

    constructor(private http: HttpClient) { }

    private setHeaders(): HttpHeaders {
        const headersConfig = {
            'Content-Type': 'application/json',
            'Accept': 'application/json'
        };

        return new HttpHeaders(headersConfig);
    }

    private formatErrors(error: any) {
        return Observable.throw(error.json);
    }

    get(path: string, params: HttpParams = new HttpParams()): Observable<any> {
        return this.http.get(`${environment.api}${path}`, { headers: this.setHeaders(), params })
            .catch(this.formatErrors);
    }

    put(path: string, body: Object = {}): Observable<any> {
        return this.http.put(
            `${environment.api}${path}`,
            JSON.stringify(body),
            { headers: this.setHeaders() }
        )
            .catch(this.formatErrors);
    }

    post(path, body) {
        return this.http
            .post(`${environment.api}${path}`, JSON.stringify(body), { headers: this.setHeaders() })
            .subscribe(
            res => {
                console.log(res);
            },
            err => {
                console.log("Error occured" + err);
            }
            );
    }

    delete(path): Observable<any> {
        return this.http.delete(
            `${environment.api}${path}`,
            { headers: this.setHeaders() }
        )
            .catch(this.formatErrors);
    }
}
