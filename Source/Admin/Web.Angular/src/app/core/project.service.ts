import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';

import { ApiService } from './api.service';
import { AddProject } from '../shared/models/add-project.model';
import { Project } from '../shared/models/project.model';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class ProjectService {

    constructor(private apiService: ApiService, private http: HttpClient) { }

    saveProject(item: AddProject) {
        let project = new AddProject();
        project = item; 
        
        this.apiService.post('/api/project', project);
    }

    getProjects(): Observable<Array<Project>> {
        return this.apiService
            .get('/api/project');
    }
}