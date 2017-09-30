import { Component, OnInit } from '@angular/core';

import { AddProject } from '../../shared/models/add-project.model';
import { ProjectService } from '../../core/project.service';
import { UtilityService } from '../../core/utility.service';

@Component({
    selector: 'cbs-add-project',
    templateUrl: './add-project.component.html',
    styleUrls: ['./add-project.component.scss']
})

export class AddProjectComponent implements OnInit {
    name: string;

    constructor(
        private projectService: ProjectService,
        private utilityService: UtilityService
    ) { }

    ngOnInit() {
    }

    async addProject() {
        const projectId = this.utilityService.createGuid();

        let project = new AddProject();
        project.name = this.name;
        project.id = projectId;

        await this.projectService.saveProject(project);
    }
}
