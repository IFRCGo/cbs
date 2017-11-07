import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { CaseReportService } from './case-report.service';
import { CaseReportFromUnknownDataCollectorService } from './case-report-from-unknown-data-collector.service';
import { InvalidCaseReportService } from './invalid-case-report.service';
import { InvalidCaseReportFromUnknownDataCollectorService } from './invalid-case-report-from-unknown-data-collector.service';
import { AggregatedCaseReportService } from './aggregated-case-report.service';

@NgModule({
    imports: [
        CommonModule
    ],
    providers: [
        CaseReportService,
        CaseReportFromUnknownDataCollectorService,
        InvalidCaseReportService,
        InvalidCaseReportFromUnknownDataCollectorService,
        AggregatedCaseReportService
    ],
    declarations: [
    ]
})

export class CoreModule { }
