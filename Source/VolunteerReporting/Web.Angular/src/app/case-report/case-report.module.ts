import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormsModule} from '@angular/forms';

import {CaseReportRouting} from './case-report-routing.module';
import {CaseReportListComponent} from './case-report-list/case-report-list.component';
import {SortableColumnComponent} from './case-report-list/sort/sortable-column.component';
import {CaseReportExporter} from './case-report-list/exporter/case-report-exporter.service';
import {Filter} from './case-report-list/filtering/filter.pipe';
import {Sort} from './case-report-list/sort/sort.pipe';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    CaseReportRouting
  ],
  declarations: [
    CaseReportListComponent,
    SortableColumnComponent,
    Filter,
    Sort
  ],
  providers: [
    Filter,
    Sort,
    CaseReportExporter
  ]
})

export class CaseReportModule {
}
