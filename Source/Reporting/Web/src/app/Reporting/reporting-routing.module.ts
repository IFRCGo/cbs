import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';

import {CaseReportListComponent} from './CaseReportsForListing/case-report-list.component';

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
      }
    ]
  }
];

export const CaseReportRouting = RouterModule.forChild(routes);
