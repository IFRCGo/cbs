import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { CaseReportRouting } from './casereport-routing.module';
import { CaseReportListComponent } from './casereportlist/casereportlist.component';

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
