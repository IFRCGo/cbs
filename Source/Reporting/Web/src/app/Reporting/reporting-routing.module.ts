import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';

import {CaseReportListComponent} from './CaseReportsForListing/case-report-list.component';
import { TrainingCaseReportsComponent } from './CaseReportsForListing/training-case-reports/training-case-reports.component';

/*import { environment } from './environment';
console.log('PRODUCTION:',environment.production);*/

const routes: Routes = [
  {
    path: 'case-reports',
    children: [
      {
        path: '',
        redirectTo: 'list/all',
        pathMatch: 'full'
      },
      {
        path: 'list/:filter',
        component: CaseReportListComponent
      },
      {
        path: 'training',
        component: TrainingCaseReportsComponent
      }
    ]
  }
];

export const CaseReportRouting = RouterModule.forChild(routes);
