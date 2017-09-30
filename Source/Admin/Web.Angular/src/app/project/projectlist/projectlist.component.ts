import { Component, OnInit } from '@angular/core';
import { ProjectService } from '../../core/project.service';
import { Project } from '../../shared/models/project.model';

@Component({
    selector: 'cbs-projectlist',
    templateUrl: './projectlist.component.html',
    styleUrls: ['./projectlist.component.scss']
})
export class ProjectlistComponent implements OnInit {

    projects: Array<Project>;

    constructor(private projectService: ProjectService) { }

    ngOnInit() {
        this.projectService.getProjects()
            .then((result) => this.projects = result)
            .catch((error) => console.error(error));
    }
}
