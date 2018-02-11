import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { CaseReportRouting } from './case-report-routing.module';
import { CaseReportListComponent } from './case-report-list/case-report-list.component';

import { ReportService } from './case-report-list/sort/case-report.service';
import { SortService } from './case-report-list/sort/sort.service';
import { SortableTableDirective } from './case-report-list/sort/sortable-table.directive';
import { SortableColumnComponent } from './case-report-list/sort/sortable-column.component';
@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        CaseReportRouting
    ],
    declarations: [
        CaseReportListComponent,
        SortableTableDirective,
        SortableColumnComponent
    ],
    providers: [
        ReportService,
        SortService
    ]
})

export class CaseReportModule { }
