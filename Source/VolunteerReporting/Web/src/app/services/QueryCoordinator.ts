import 'rxjs/add/operator/toPromise';
import { environment } from '../../environments/environment';

import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { QueryResult } from './QueryResult';
import { QueryRequest } from './QueryRequest';

const API_URL = environment.api + '/api/Dolittle/Queries';

const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()
export class QueryCoordinator<T> {

    constructor(private http: HttpClient) { }

    handle(queryRequest: QueryRequest): Promise<QueryResult<T>> {
        return this.http
            .post(API_URL, queryRequest, httpOptions)
            .toPromise() as Promise<QueryResult<T>>;
    }
}