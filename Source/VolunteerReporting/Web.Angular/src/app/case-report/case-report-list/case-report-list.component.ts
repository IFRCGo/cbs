import { Component, OnInit } from '@angular/core';
import { CaseReportService } from '../../core/case-report.service';
import { CaseReport } from '../../shared/models/case-report.model';
import { AnonymousCaseReportService } from '../../core/anonymous-case-report.service';
import { AnonymousCaseReport } from '../../shared/models/anonymous-case-report.model';

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
