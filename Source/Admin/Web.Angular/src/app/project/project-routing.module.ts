import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AddProjectComponent } from './add-project/add-project.component';
import { ProjectlistComponent } from './projectlist/projectlist.component';

const routes: Routes = [
    {
        path: 'project',
        children: [
            {
                path: '',
                redirectTo: 'add',
                pathMatch: 'full'
            },
            {
                path: 'add',
                component: AddProjectComponent
            },
            {
                path: 'list',
                component: ProjectlistComponent
            }
        ]
    }
];

export const ProjectRouting = RouterModule.forChild(routes);