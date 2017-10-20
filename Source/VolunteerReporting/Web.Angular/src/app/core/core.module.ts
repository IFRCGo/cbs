import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { CaseReportService } from './casereport.service';
import { AnonymousCaseReportService } from './anonymouscasereport.service';

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
