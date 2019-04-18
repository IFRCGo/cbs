import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormsModule} from '@angular/forms';
import {NgxSmartModalModule} from 'ngx-smart-modal';

import {CaseReportRouting} from './reporting-routing.module';
import {CaseReportListComponent} from './CaseReportsForListing/case-report-list.component';
import {CaseReportExportComponent} from './CaseReportsForListing/export/case-report-export.component';
import {SortableColumnComponent} from './CaseReportsForListing/sort/sortable-column.component';
import {Filter} from './CaseReportsForListing/filtering/filter.pipe';
import { TrainingCaseReportsComponent } from './CaseReportsForListing/training-case-reports/training-case-reports.component';
import { TranslateModule } from '@ngx-translate/core';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    CaseReportRouting,
    TranslateModule,
    NgxSmartModalModule.forChild()
  ],
  declarations: [
    CaseReportListComponent,
    TrainingCaseReportsComponent,
    CaseReportExportComponent,
    SortableColumnComponent,
    Filter
  ],
  providers: [
    Filter
  ]
})

export class CaseReportModule {
}
