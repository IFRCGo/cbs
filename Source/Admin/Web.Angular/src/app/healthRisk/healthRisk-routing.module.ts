import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HealthRiskListComponent } from './healthRisk-list/healthRisk-list.component';
import { AddEditHealthRiskComponent } from './add-edit-healthRisk/add-edit-healthRisk.component';

const routes: Routes = [
    {
        path: 'healthrisk',
        children: [
            {
                path: '',
                component: HealthRiskListComponent
            },
            {
                path: 'add',
                component: AddEditHealthRiskComponent
            },
            {
                path: ':id/update',
                component: AddEditHealthRiskComponent
            },
        ]
    }
];

export const HealthRiskRouting = RouterModule.forChild(routes);