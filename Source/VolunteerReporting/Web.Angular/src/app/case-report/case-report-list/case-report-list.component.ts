import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { AggregatedCaseReportService } from '../../core/aggregated-case-report.service';
import { CaseReportForListing } from '../../shared/models/case-report-for-listing.model';
import { Column, SortableColumn, CaseReportColumns } from './sort/columns';
import { QuickFilter, Filter } from './filtering/filter.pipe';
import { CaseReportExporter } from './exporter/case-report-exporter.service';
import { Report } from '../../shared/models/report.model';

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

    listedReports: Array<CaseReportForListing>;

    allFilters: Array<QuickFilter> = QuickFilter.Filters;
    currentFilter: QuickFilter = QuickFilter.All;

    allColumns: Array<Column> = CaseReportColumns;
    sortDescending: boolean = true;
    currentSortColumn: SortableColumn = CaseReportColumns[0] as SortableColumn; // Timestamp

    constructor(
        private caseReportService: AggregatedCaseReportService,
        private caseReportExporter: CaseReportExporter,
        private route: ActivatedRoute,
        private router: Router
    ) { }

    updateNavigation(filter: QuickFilter, column: SortableColumn, sortDescending: boolean) {
      this.router.navigate(['../'+filter.name], { relativeTo: this.route, queryParams: {
        sortBy: column.name,
        order: sortDescending ? 'desc' : 'asc'
      }});
    }

    filterButtonStyle(filter: QuickFilter) {
        return {
            'font-weight': this.currentFilter === filter ? 'bold' : 'normal'
        };
    }
    clickFilter(filter: QuickFilter) {
        this.updateNavigation(filter, this.currentSortColumn, this.sortDescending);
    }

    toggleSortColum(column: Column) {
        if (column instanceof SortableColumn) {
            if (column !== this.currentSortColumn) {
                this.updateNavigation(this.currentFilter, column, true);
            } else {
                this.updateNavigation(this.currentFilter, this.currentSortColumn, !this.sortDescending);
            }
        }
    }

    ngOnInit() {
        this.caseReportService.getReports().then(result => {
            this.listedReports = result || [];
        }).catch(error => console.error(error));

        this.route.params.subscribe(params => {
            this.currentFilter = QuickFilter.fromName(params.filter);
        });

        this.route.queryParams.subscribe(query => {
            this.sortDescending = query.order != 'asc';
            this.currentSortColumn = this.allColumns.find(column => {
                return column instanceof SortableColumn && column.name == query.sortBy;
            }) as SortableColumn || this.currentSortColumn;
        });
    }
}
