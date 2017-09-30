import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AddProjectComponent } from './add-project/add-project.component';

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
            }
        ]
    }
];

export const ProjectRouting = RouterModule.forChild(routes);