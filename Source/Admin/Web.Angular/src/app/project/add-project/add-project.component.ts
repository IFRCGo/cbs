import { Component, OnInit } from '@angular/core';

import { NationalSocietyService } from '../../core/nationalsociety.service';
import { ProjectService } from '../../core/project.service';
import { UserService } from '../../core/user.service';
import { UtilityService } from '../../core/utility.service';
import { AddProject, NationalSociety, User } from '../../shared/models';

@Component({
    selector: 'add-project',
    templateUrl: './add-project.component.html',
    styleUrls: ['./add-project.component.scss']
})

export class AddProjectComponent implements OnInit {
    name: string;
    societies: Array<NationalSociety>;
    owners: Array<User>;
    selectedSociety: string;
    selectedOwner: string;
    projectOwners: Array<User>;

    constructor(
        private projectService: ProjectService,
        private utilityService: UtilityService,
        private userService: UserService,
        private nationalSocietyService: NationalSocietyService
    ) { }

    ngOnInit() {
        this.nationalSocietyService.getNationalSocieties()
            .subscribe((result) => this.societies = result,
            (error) => { console.log(error) });
    }

    onSocietyChange(selectedNationalSocietyId: string) {
        this.getProjectOwners(selectedNationalSocietyId);
    }

    getProjectOwners(nationalSocietyId: string) {
        this.userService.getProjectOwners(nationalSocietyId).subscribe(
            (users) => {
                this.projectOwners = users;
            },
            (error) => {
                console.error(error);
            }
        );
    }

    async addProject() {
        const projectId = this.utilityService.createGuid();

        let project = new AddProject();
        project.name = this.name;
        project.id = projectId;

        await this.projectService.saveProject(project);
    }
}
