import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { AggregatedCaseReportService } from './aggregated-case-report.service';

@NgModule({
    imports: [
        CommonModule
    ],
    providers: [
        AggregatedCaseReportService
    ],
    declarations: [
    ]
})

export class CoreModule { }
