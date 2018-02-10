import { Component, OnInit, TemplateRef } from '@angular/core';
import { ProjectService } from '../../core/project.service';
import { Project } from '../../shared/models/project.model';

@Component({
    selector: 'cbs-project-list',
    templateUrl: './project-list.component.html',
    styleUrls: ['./project-list.component.scss'],
})

export class ProjectListComponent implements OnInit {
    projects: Project[];

    constructor(
        private projectService: ProjectService,
    ) { }

    ngOnInit() {
        this.projectService.getProjects()
            .subscribe((result) => this.projects = result,
            (error) => { console.log(error); })
    }

}
