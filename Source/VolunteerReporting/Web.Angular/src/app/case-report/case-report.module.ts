import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormsModule} from '@angular/forms';

import {CaseReportRouting} from './case-report-routing.module';
import {CaseReportListComponent} from './case-report-list/case-report-list.component';
import {SortableColumnComponent} from './case-report-list/sort/sortable-column.component';
import {CaseReportExporter} from './case-report-list/exporter/case-report-exporter.service';
import {Filter} from './case-report-list/filtering/filter.pipe';
import {Sort} from './case-report-list/sort/sort.pipe';
import { CaseReportExporterComponent } from './case-report-list/exporter/case-report-exporter.component';
import {CaseReportExporterModalContent} from './case-report-list/exporter/case-report-exporter.component';

import { ModalModule } from 'ngx-bootstrap/modal';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    CaseReportRouting,
    ModalModule.forRoot()
  ],
  declarations: [
    CaseReportListComponent,
    SortableColumnComponent,
    Filter,
    Sort,
    CaseReportExporterComponent,
    CaseReportExporterModalContent
  ],
  providers: [
    Filter,
    Sort,
    CaseReportExporter
  ],
  entryComponents: [CaseReportExporterModalContent]
})

export class CaseReportModule {
}
