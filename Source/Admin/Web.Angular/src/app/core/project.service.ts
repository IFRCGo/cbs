import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import { ApiService } from './api.service';
import { AddProject } from '../shared/models/add-project.model';
import { Project } from '../shared/models/project.model';

@Injectable()
export class ProjectService {

    constructor(private apiService: ApiService) { }

    saveProject(item: AddProject): Observable<void> {
        let project = new AddProject();
        project = item; // Simple assignment, will probably handle values differently later

        return this.apiService.post('/api/project', project);
    }

    getProjects(): Observable<Array<Project>> {
        return this.apiService
            .get('/api/project');
    }
}