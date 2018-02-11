import { Component, OnInit } from '@angular/core';
import { AggregatedCaseReportService } from '../../core/aggregated-case-report.service';
import { Report } from '../../shared/models/report.model';

import { ReportService, ReportSearchCriteria } from './sort/case-report.service';

@Component({
    selector: 'cbs-case-report-list',
    templateUrl: './case-report-list.component.html',
    styleUrls: ['./case-report-list.component.scss']
})

/**
 * maxReports: number
 *      The number of reports that can be shown on a page
 * listedReports: Array<any>
 *      The list of reports that is actually shown. Can hold any object so that the data
 *      that the actual object, CaseReport, holds can be accessed. Since when reports 
 *      are referenced using the interface Report we can only access the id, success and timeStamp values.
 * reports: Array<Report>
 *      The list of reports fetched from the DB, objects referenced with the Report interface.
 * reports_detailed: Array<any>
 *      The same as reports, the objects are just any object. Not typesafe, but we can access fields that
 *      cannot be accessed through the Report interface
 */
export class CaseReportListComponent implements OnInit {
    maxReports: number;
    listedReports: Array<any>;

    reports: Array<Report>;
    reportsDetailed: Array<any>;
    
    constructor(
        private caseReportService: AggregatedCaseReportService,
        private service: ReportService
    ) { this.maxReports = 10 }

    /**
     * Calls a getReports method in a class that handles sorting on the data passed.
     * It may, or may not, be done by sending both an array that holds all the reports referenced to by
     * the Report interface and an array of raw CaseReport objects.
     * Ideally it would be nice to just pass an array of the raw data 
     * @param criteria The sorting criteria passed to the sorter service. 
     */
    getReports(criteria: ReportSearchCriteria) {
        
        this.listedReports = this.service.getReports(this.reports,this.reportsDetailed, criteria).slice(0, this.maxReports);
    }

    onSorted($event) {
        this.getReports($event);
    }

    ngOnInit() {
        this.caseReportService.getReports()
            .then(
                (result) => {
                    this.reports = this.reportsDetailed = result || []

                    this.listedReports = this.reportsDetailed.slice(0, this.maxReports);
                    console.log(this.listedReports);
                }
            )
            .catch((error) => console.error(error));
            
    }
}
