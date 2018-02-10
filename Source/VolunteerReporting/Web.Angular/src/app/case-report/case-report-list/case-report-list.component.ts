import { Component, OnInit } from '@angular/core';
import { AggregatedCaseReportService } from '../../core/aggregated-case-report.service';
import { Report } from '../../shared/models/report.model';

import { ReportService, ReportSearchCriteria } from './sort/case-report.service';

@Component({
    selector: 'cbs-case-report-list',
    templateUrl: './case-report-list.component.html',
    styleUrls: ['./case-report-list.component.scss']
})

export class CaseReportListComponent implements OnInit {

    reports: Array<Report>;
    reports_detailed: Array<any>;
    
    constructor(
        private caseReportService: AggregatedCaseReportService,
        private service: ReportService
    ) { }

    getReports(criteria: ReportSearchCriteria) {
        this.reports = this.service.getReports(this.reports,this.reports_detailed, criteria);
    }

    onSorted($event) {
        console.log(this.reports);
        console.log("DETAILED");
        console.log(this.reports_detailed);
        this.getReports($event);
    }

    ngOnInit() {
        this.caseReportService.getReports()
            .then((result) => 
                this.reports = result || [] 
            )
            .catch((error) => console.error(error));
        this.caseReportService.getReports()
            .then((result) => 
                this.reports_detailed = result || [] 
            )
            .catch((error) => console.error(error));
    }
}
