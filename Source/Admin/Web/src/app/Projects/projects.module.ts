import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';
import { ProjectsRouting } from './projects-routing.module';
import { AddProjectComponent } from './add-project/add-project.component';
import { ProjectListComponent } from './project-list/project-list.component';

@NgModule({
    imports: [
        ProjectsRouting,
        SharedModule
    ],
    declarations: [
        AddProjectComponent, 
        ProjectListComponent
    ]
})

export class ProjectModule { }
