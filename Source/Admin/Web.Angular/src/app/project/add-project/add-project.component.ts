import { Component, OnInit } from '@angular/core';

import { NationalSocietyService } from '../../core/nationalsociety.service';
import { ProjectService } from '../../core/project.service';
import { UserService } from '../../core/user.service';
import { UtilityService } from '../../core/utility.service';
import { AddProject, NationalSociety, User } from '../../shared/models';

@Component({
    selector: 'cbs-add-project',
    templateUrl: './add-project.component.html',
    styleUrls: ['./add-project.component.scss']
})

export class AddProjectComponent implements OnInit {
    name: string;
    societies: NationalSociety[];
    owners: User[];
    selectedSociety: string;
    selectedOwner: string;
    projectOwners: User[];
    surveillanceOptions: object[];
    selectedSurveillanceOptionId: string;

    constructor(
        private projectService: ProjectService,
        private utilityService: UtilityService,
        private userService: UserService,
        private nationalSocietyService: NationalSocietyService,

    ) { }

    ngOnInit() {
        this.nationalSocietyService.getNationalSocieties()
            .subscribe((result) => this.societies = result,
            (error) => { console.log(error) });
        this.surveillanceOptions = [
                { "id": '0', "name": "Single Reports" },
                { "id": '1', "name": "Aggregated Reports" },
                { "id": '2', "name": "Both" }
            ];
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

    getSurveillanceOptionId(id: string){
        this.selectedSurveillanceOptionId = id;
    }

    async addProject() {
        console.log("Name: " + this.name);
        const projectId = this.utilityService.createGuid();

        let project = new AddProject();
        project.name = this.name;
        project.id = projectId;
        project.nationalSocietyId = this.selectedSociety;
        project.ownerUserId = this.selectedOwner;
        project. surveillanceId = this.selectedSurveillanceOptionId;

        await this.projectService.saveProject(project);
    }
}
