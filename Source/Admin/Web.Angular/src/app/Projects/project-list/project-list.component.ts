import { Component, OnInit, TemplateRef } from '@angular/core';
import { QueryCoordinator } from '@dolittle/queries';
import { AllProjects } from '../AllProjects';
import { Project } from '../Project';

@Component({
    selector: 'cbs-project-list',
    templateUrl: './project-list.component.html',
    styleUrls: ['./project-list.component.scss'],
})

export class ProjectListComponent implements OnInit {
    projects: Project[];

    constructor(
        private queryCoordinator: QueryCoordinator
    ) { }

    ngOnInit() {
        /*
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
      });*/
    }

}
