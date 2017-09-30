import { Component, OnInit } from '@angular/core';

import { ProjectService } from '../../shared/services/project.service';
import { AddProject } from '../../shared/models/add-project.model';

@Component({
    selector: 'cbs-add-project',
    templateUrl: './add-project.component.html',
    styleUrls: ['./add-project.component.scss']
})

export class AddProjectComponent implements OnInit {
    name: string;

    constructor(
        private projectService: ProjectService
    ) { }

    ngOnInit() {
    }

    async addProject() {
        let project = new AddProject();
        project.name = this.name;

        await this.projectService.saveProject(project);
    }
}
