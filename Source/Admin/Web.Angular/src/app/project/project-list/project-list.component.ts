import { Component, OnInit, TemplateRef } from '@angular/core';
import { ProjectService } from '../../core/project.service';
import { Project } from '../../shared/models/project.model';
import { BsModalService } from 'ngx-bootstrap/modal';
import { BsModalRef } from 'ngx-bootstrap/modal/bs-modal-ref.service';
import { NationalSocietyService } from '../../core/nationalsociety.service';
import { UserService } from '../../core/user.service';
import { UtilityService } from '../../core/utility.service';
import { AddProject, NationalSociety, User } from '../../shared/models';

@Component({
    selector: 'cbs-project-list',
    templateUrl: './project-list.component.html',
    styleUrls: ['./project-list.component.scss']
})

export class ProjectListComponent implements OnInit {
    projects: Project[];
    modalRef: BsModalRef;
    name: string;
    societies: NationalSociety[];
    owners: User[];
    selectedSociety: string;
    selectedOwner: string;
    projectOwners: User[];
    selectedSurveillance: number;

    constructor(
        private projectService: ProjectService,
        private modalService: BsModalService,
        private utilityService: UtilityService,
        private userService: UserService,
        private nationalSocietyService: NationalSocietyService,
    ) { }

    ngOnInit() {
        this.projectService.getProjects()
            .subscribe((result) => this.projects = result,
            (error) => { console.log(error); });
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

    openModal(template: TemplateRef<any>) {
        this.modalRef = this.modalService.show(template);
    }
}
