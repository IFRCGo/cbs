import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { CaseReportRouting } from './case-report-routing.module';
import { CaseReportListComponent } from './case-report-list/case-report-list.component';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        CaseReportRouting
    ],
    declarations: [
        CaseReportListComponent
    ]
})

export class CaseReportModule { }
