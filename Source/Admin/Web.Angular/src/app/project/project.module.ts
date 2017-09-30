import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProjectRouting } from './project-routing.module';
import { AddProjectComponent } from './add-project/add-project.component';
import { ProjectlistComponent } from './projectlist/projectlist.component';

@NgModule({
    imports: [
        CommonModule,
        ProjectRouting
    ],
    declarations: [
        AddProjectComponent, 
        ProjectlistComponent
    ]
})

export class ProjectModule { }
