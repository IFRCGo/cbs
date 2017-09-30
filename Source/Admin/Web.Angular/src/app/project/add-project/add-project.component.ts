import { Component, OnInit } from '@angular/core';

import { AddProject, NationalSociety, User } from '../../shared/models';
import { ProjectService } from '../../core/project.service';
import { UtilityService } from '../../core/utility.service';

@Component({
    selector: 'cbs-add-project',
    templateUrl: './add-project.component.html',
    styleUrls: ['./add-project.component.scss']
})

export class AddProjectComponent implements OnInit {
    name: string;
    societies: NationalSociety[];
    owners: User[];

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
