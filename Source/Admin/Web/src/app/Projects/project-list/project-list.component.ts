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
    ) { 

        this.queryCoordinator = new QueryCoordinator();
    }

    ngOnInit() {
        this.allProjects();
    }

    allProjects = () => {
        console.log("AllProjects");
        let query = new AllProjects();
        this.queryCoordinator.execute(query).then(result => {
            if (result.success) {
                console.log("AllProjects", result);
                const sortItems = result.items;
                this.projects = [...sortItems];
            } else {
                console.error(result);
            }

        });
    };
}
