import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';
import 'rxjs/add/operator/toPromise';

import { AddProject } from '../models/add-project.model';

@Injectable()
export class ProjectService {
    private headers = new Headers({ 'Content-Type': 'application/json' });

    constructor(private http: Http) { }

    saveProject(item: AddProject): Promise<void> {
        const url = `http://localhost:5000/api/project`;

        let project = new AddProject();
        project = item; // Simple assignment, will 

        return this.http
            .post(url, JSON.stringify(project), { headers: this.headers })
            .toPromise()
            .then(() => { console.log('success'); })
            .catch((error) => console.error(error));
    }
}