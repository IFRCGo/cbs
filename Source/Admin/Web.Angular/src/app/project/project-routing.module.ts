import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AddProjectComponent } from './add-project/add-project.component';
import { ProjectListComponent } from './project-list/project-list.component';

const routes: Routes = [
    {
        path: 'project',
        children: [
            {
                path: '',
                redirectTo: 'list',
                pathMatch: 'full'
            },
            {
                path: 'list',
                component: ProjectListComponent
            },
            {
                path: 'add',
                component: AddProjectComponent
            } //TODO: edit
        ]
    }
];

export const ProjectRouting = RouterModule.forChild(routes);