import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { CaseReportService } from './casereport.service';

@NgModule({
    imports: [
        CommonModule
    ],
    providers: [
        CaseReportService
    ],
    declarations: [
    ]
})

export class CoreModule { }
