import { Component, OnInit } from '@angular/core';
import { AggregatedCaseReportService } from '../../core/aggregated-case-report.service';
import { Report } from '../../shared/models/report.model';

@Component({
    selector: 'cbs-case-report-list',
    templateUrl: './case-report-list.component.html',
    styleUrls: ['./case-report-list.component.scss']
})
export class CaseReportListComponent implements OnInit {

    reports: Array<Report>;
    
    constructor(
        private caseReportService: AggregatedCaseReportService
    ) { }

    ngOnInit() {
        this.caseReportService.getReports()
            .then((result) => 
                this.reports = result || [] 
            )
            .catch((error) => console.error(error));
    }
}
