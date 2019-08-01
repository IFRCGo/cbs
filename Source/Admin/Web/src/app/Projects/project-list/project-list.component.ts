import { Component, OnInit } from '@angular/core';
import { QueryCoordinator } from '@dolittle/queries';
import { AllProjects } from '../AllProjects';
import { Project } from '../Project';
import { AppInsightsService } from '../../services/app-insights-service';

@Component({
    selector: 'cbs-project-list',
    templateUrl: './project-list.component.html',
    styleUrls: ['./project-list.component.scss'],
})

export class ProjectListComponent implements OnInit {
    projects: Project[];

    constructor(
        private appInsightsService: AppInsightsService
    ) { }

    ngOnInit() {
        this.allProjects();
        this.appInsightsService.trackPageView('Projects');
    }

    allProjects = () => {
        console.log("AllProjects");
        let query = new AllProjects();
        const queryCoordinator = new QueryCoordinator();
        queryCoordinator.execute(query).then(result => {
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
