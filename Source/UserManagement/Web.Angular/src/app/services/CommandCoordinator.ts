import 'rxjs/add/operator/toPromise';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs/Observable';

import { Injectable } from '@angular/core';
import { CommandRequest } from './CommandRequest';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const API_URL = environment.api + '/api/Dolittle/Commands';

const httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

export class CommandResult {
    allValidationMessages: string[];
    command: CommandRequest;
    commandValidationMessages: string[];
    exceptionMessage: string;
    invalid: boolean;
    passedSecurity: boolean;
    securityMessages: string[];
    success: boolean;
}
@Injectable()
export class CommandCoordinator2 {

    static commandResultIsSuccess(response) {
        return response.success;
    }
    constructor(private http: HttpClient) { }

    handle(command): Promise<CommandResult> {
        const commandRequestAsJson = JSON.stringify(CommandRequest.createFrom(command))
        return this.http
            .post(API_URL, commandRequestAsJson, httpOptions)
            .toPromise() as Promise<CommandResult>;
    }
}
