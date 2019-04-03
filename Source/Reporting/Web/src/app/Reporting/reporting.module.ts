import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormsModule} from '@angular/forms';
import {NgxSmartModalModule} from 'ngx-smart-modal';

import {CaseReportRouting} from './reporting-routing.module';
import {CaseReportListComponent} from './CaseReportsForListing/case-report-list.component';
import {CaseReportExportComponent} from './CaseReportsForListing/export/case-report-export.component';
import {SortableColumnComponent} from './CaseReportsForListing/sort/sortable-column.component';
import {Filter} from './CaseReportsForListing/filtering/filter.pipe';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    CaseReportRouting,
    NgxSmartModalModule.forChild()
  ],
  declarations: [
    CaseReportListComponent,
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
