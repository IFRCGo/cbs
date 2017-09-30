import { Component, OnInit } from '@angular/core';

import { NationalSocietyService } from '../../core/nationalsociety.service';
import { ProjectService } from '../../core/project.service';
import { UtilityService } from '../../core/utility.service';
import { AddProject, NationalSociety, User } from '../../shared/models';

@Component({
    selector: 'cbs-add-project',
    templateUrl: './add-project.component.html',
    styleUrls: ['./add-project.component.scss']
})

export class AddProjectComponent implements OnInit {
    name: string;
    societies: Array<NationalSociety>;
    owners: Array<User>;
    selectedSociety: string;
    selectedOwner: string;

    constructor(
        private projectService: ProjectService,
        private utilityService: UtilityService,
        private nationalSocietyService: NationalSocietyService
    ) { }

    ngOnInit() {
        this.nationalSocietyService.getNationalSocieties()
            .then((result) => this.societies = result)
            .catch((error) => console.error(error));
    }

    async addProject() {
        const projectId = this.utilityService.createGuid();

        let project = new AddProject();
        project.name = this.name;
        project.id = projectId;

        await this.projectService.saveProject(project);
    }
}
