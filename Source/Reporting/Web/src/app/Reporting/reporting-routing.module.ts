import {Routes, RouterModule} from '@angular/router';
import {CaseReportListComponent} from './CaseReportsForListing/case-report-list.component';
import { TrainingReportListComponent } from './CaseReportsForListing/training-report-list.component';

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
  },
  {
    path: 'training-reports',
    children: [
      {
        path: '',
        redirectTo: 'list/all',
        pathMatch: 'full'
      },
      {
        path: 'list/:filter',
        component: TrainingReportListComponent
      }
    ]
  }
];

export const CaseReportRouting = RouterModule.forChild(routes);
