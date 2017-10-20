import { Component, OnInit } from '@angular/core';
import { CaseReportService } from '../../core/casereport.service';
import { CaseReport } from '../../shared/models/casereport.model';

@Component({
    selector: 'cbs-casereportlist',
    templateUrl: './casereportlist.component.html',
    styleUrls: ['./casereportlist.component.scss']
})
export class CaseReportListComponent implements OnInit {

    caseReports: Array<CaseReport>;

    constructor(private caseReportService: CaseReportService) { }

    ngOnInit() {
        this.caseReportService.getCaseReports()
            .then((result) => this.caseReports = result)
            .catch((error) => console.error(error));
    }
}
