import { Component, OnInit, PipeTransform, Pipe  } from '@angular/core';

import { NationalSocietyService } from '../../core/nationalsociety.service';
import { ProjectService } from '../../core/project.service';
import { UserService } from '../../core/user.service';
import { UtilityService } from '../../core/utility.service';
import { AddProject, NationalSociety, User } from '../../shared/models';

interface FormData {
    selectedSociety: string;
    selectedOwner: string;
    projectName: string;
    selectedSurveillanceOptionId: string;
}

@Component({
    selector: 'cbs-add-project',
    templateUrl: './add-project.component.html',
    styleUrls: ['./add-project.component.scss']
})
export class AddProjectComponent implements OnInit {
    societies: NationalSociety[];
    owners: User[];
    projectOwners: User[];
    surveillanceOptions: object[];
    formError: string = '';
    isFormSubmitted: boolean = false;
    formData: FormData;

    constructor(
        private projectService: ProjectService,
        private utilityService: UtilityService,
        private userService: UserService,
        private nationalSocietyService: NationalSocietyService
    ) {}

    ngOnInit() {
        this.nationalSocietyService.getNationalSocieties().subscribe(
            result => (this.societies = result),
            error => {
                this.formError = `Error getting national societies: ${error}`;
            }
        );
        this.resetForm();
        this.surveillanceOptions = [
            { id: '0', name: 'Single Reports' },
            { id: '1', name: 'Aggregated Reports' },
            { id: '2', name: 'Both' }
        ];
    }

    resetForm() {
        this.formError = '';
        this.isFormSubmitted = false;
        this.formData = { selectedSociety: '', selectedOwner: '', projectName: '', selectedSurveillanceOptionId: '' };
    }

    findInArray(id:string, array: any[]) {
        if (!array) {
            return {};
        }
        const found = array.find(element => element.id === id);
        return found || {};            
    }

    onSocietyChange(selectedNationalSocietyId: string) {
        this.getProjectOwners(selectedNationalSocietyId);
    }

    getProjectOwners(nationalSocietyId: string) {
        this.userService.getProjectOwners(nationalSocietyId).subscribe(
            users => {
                this.projectOwners = users;
            },
            error => {
                this.formError = `Error getting project owners: ${error}`;
                console.error(error);
            }
        );
    }

    async addProject() {
        const projectId = this.utilityService.createGuid();
        const { selectedOwner, selectedSociety, selectedSurveillanceOptionId, projectName } = this.formData;

        let project = new AddProject();
        project.id = projectId;
        project.dataOwnerId = selectedOwner;
        project.name = projectName;
        project.nationalSocietyId = selectedSociety;
        project.surveillanceId = selectedSurveillanceOptionId;

        await this.projectService.saveProject(project);
        console.log('project created successfully');
        this.isFormSubmitted = true;
    }
}
