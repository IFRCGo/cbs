import { Component, OnInit } from '@angular/core';
import { CaseReportService } from '../../core/casereport.service';
import { CaseReport } from '../../shared/models/casereport.model';
import { AnonymousCaseReportService } from '../../core/anonymouscasereport.service';
import { AnonymousCaseReport } from '../../shared/models/anonymouscasereport.model';

@Component({
    selector: 'cbs-case-report-list',
    templateUrl: './case-report-list.component.html',
    styleUrls: ['./case-report-list.component.scss']
})
export class CaseReportListComponent implements OnInit {

    caseReports: Array<CaseReport>;
    anonymousCaseReports: Array<AnonymousCaseReport>;
    
    constructor(
        private caseReportService: CaseReportService,
        private anonymousCaseReportService: AnonymousCaseReportService
    ) { }

    ngOnInit() {
        this.caseReportService.getCaseReports()
            .then((result) => this.caseReports = result)
            .catch((error) => console.error(error));
        
        this.anonymousCaseReportService.getAnonymousCaseReports()
            .then((result) => this.anonymousCaseReports = result)
            .catch((error) => console.error(error));
    }
}
