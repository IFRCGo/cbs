import { Component, OnInit, TemplateRef } from '@angular/core';
import { ProjectService } from '../../core/project.service';
import { Project } from '../../shared/models/project.model';
import { BsModalService } from 'ngx-bootstrap/modal';
import { BsModalRef } from 'ngx-bootstrap/modal/bs-modal-ref.service';

@Component({
    selector: 'cbs-projectlist',
    templateUrl: './projectlist.component.html',
    styleUrls: ['./projectlist.component.scss']
})
export class ProjectlistComponent implements OnInit {
    
    projects: Array<Project>;
    modalRef: BsModalRef;

    constructor(
        private projectService: ProjectService,
        private modalService: BsModalService
    ) { }

    ngOnInit() {
        this.projectService.getProjects()
            .subscribe((result) => this.projects = result,
            (error) => { console.log(error); })
    }

    openModal(template: TemplateRef<any>) {
        this.modalRef = this.modalService.show(template);
    }
}
