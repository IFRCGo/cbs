import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CaseReportListComponent } from './casereportlist/casereportlist.component';

const routes: Routes = [
    {
        path: 'casereport',
        children: [
            {
                path: '',
                redirectTo: 'list',
                pathMatch: 'full'
            },
            {
                path: 'list',
                component: CaseReportListComponent
            }
        ]
    }
];

export const CaseReportRouting = RouterModule.forChild(routes);