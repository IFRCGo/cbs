import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { CaseReportService } from './case-report.service';
import { AnonymousCaseReportService } from './anonymous-case-report.service';

@NgModule({
    imports: [
        CommonModule
    ],
    providers: [
        CaseReportService,
        AnonymousCaseReportService
    ],
    declarations: [
    ]
})

export class CoreModule { }
