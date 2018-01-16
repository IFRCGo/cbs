import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';
import { ProjectRouting } from './project-routing.module';
import { AddProjectComponent } from './add-project/add-project.component';
import { ProjectlistComponent } from './projectlist/projectlist.component';

@NgModule({
    imports: [
        ProjectRouting,
        SharedModule
    ],
    declarations: [
        AddProjectComponent, 
        ProjectlistComponent
    ]
})

export class ProjectModule { }
