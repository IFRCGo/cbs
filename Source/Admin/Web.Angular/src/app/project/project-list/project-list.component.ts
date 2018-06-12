import { Component, OnInit, TemplateRef } from '@angular/core';
import { ProjectService } from '../../core/project.service';
import { Project } from '../../shared/models/project.model';
import { QueryCoordinator } from '../../services/QueryCoordinator';
import { AllProjects } from '../../domain/project/queries/AllProjects';

@Component({
    selector: 'cbs-project-list',
    templateUrl: './project-list.component.html',
    styleUrls: ['./project-list.component.scss'],
})

export class ProjectListComponent implements OnInit {
    projects: Project[];

    constructor(
        private queryCoordinator: QueryCoordinator<Project>
    ) { }

    ngOnInit() {
        this.queryCoordinator.handle(new AllProjects())
      .then(response => {
          if (response.success) {
            this.projects = response.items as Project[];
          } else {
            console.error(response);
          }
      })
      .catch(response => {
        console.error(response);
      });
    }

}
