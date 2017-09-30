import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProjectRouting } from './project-routing.module';
import { AddProjectComponent } from './add-project/add-project.component';

@NgModule({
    imports: [
        CommonModule,
        ProjectRouting
    ],
    declarations: [AddProjectComponent]
})

export class ProjectModule { }
