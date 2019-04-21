import { Component, OnInit, HostListener } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { QueryCoordinator } from '@dolittle/queries';
import { Column, SortableColumn, CaseReportColumns } from './sort/columns';
import { QuickFilter } from './filtering/filter.pipe';
import { AllCaseReportsForListing } from './AllCaseReportsForListing';
import { CaseReportForListing } from './CaseReportForListing';

import { NgxSmartModalService } from 'ngx-smart-modal';

//import * as fromServices from '../../services';
//import * as fromModels from '../../shared/models';

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

    listedReports: Array<CaseReportForListing> = [];
    allReports: Array<CaseReportForListing> = [];

    allFilters: Array<QuickFilter> = QuickFilter.Filters;
    currentFilter: QuickFilter = QuickFilter.All;

    allColumns: Array<Column> = CaseReportColumns;
    sortDescending: boolean = true;
    sortField: string;
    currentSortColumn: SortableColumn = CaseReportColumns[0] as SortableColumn; // Timestamp
    dateDebut : any ;
    dateFin : any;

    page = {
        isLoading: false,
        number: 0,
        size: 50,
        sizes: [10, 20, 50, 100, 200, 500, 1000]
    };

    selectedCase;

    constructor(
        private queryCoordinator: QueryCoordinator,
        private route: ActivatedRoute,
        private router: Router,
        private modal: NgxSmartModalService
        //private logService: fromServices.LogService
    ) { }

    @HostListener('window:keyup', ['$event'])
    keyEvent(event: KeyboardEvent) {
        if (event.keyCode === 37) {
            this.showPrevPage();
        }

        if (event.keyCode === 39) {
            this.showNextPage();
        }
    }

    updateNavigation(filter: QuickFilter, column: SortableColumn, sortDescending: boolean) {
      this.router.navigate(['../'+filter.name], { relativeTo: this.route, queryParams: {
        sortBy: column.name,
        order: sortDescending ? 'desc' : 'asc'
      }});
    }

    clickFilter(filter: QuickFilter) {
        this.updateNavigation(filter, this.currentSortColumn, this.sortDescending);
    }

    sortDate( datefrom : Date , dateto : Date )
    {
        let dateFrom = new Date(datefrom) ;
        let dateTo = new Date(dateto) ;
        this.listedReports = this.allReports;
        let newReports = [] ;

        this.listedReports.forEach( listedReport => {
            let date = listedReport.timestamp;
            if (date.getTime() >= dateFrom.getTime() && date.getTime() <= dateTo.getTime()) newReports.push(listedReport);
        });

        this.listedReports = newReports;
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

    loadListData(): void {
        const query = new AllCaseReportsForListing();
        query.pageNumber = this.page.number;
        query.pageSize = this.page.size;
        query.sortField = this.sortField;
        query.sortAscending = !this.sortDescending;
        this.page.isLoading = true;
        this.queryCoordinator.execute(query)
            .then(response => {
                if (response.success) {
                    this.listedReports = response.items as Array<CaseReportForListing>;
                    this.listedReports.forEach(element => {
                        element.timestamp = new Date(element.timestamp);
                    });
                    this.allReports = this.listedReports;
                } else {
                    console.error(response);
                }
                this.page.isLoading = false;
            })
            .catch(response => {
                console.error(response);
                this.page.isLoading = false;
            });
    }

    resetPage(): void {
        this.page.number = 0;
        this.loadListData();
    }

    showPrevPage(): void {
        if (this.page.number && !this.page.isLoading) {
            this.page.number--;
            this.loadListData();
        }
    }

    showNextPage(): void {
        if (!this.isLastPage() && !this.page.isLoading) {
            this.page.number++;
            this.loadListData();
        }
    }

    isLastPage(): boolean {
        return this.page.size > this.listedReports.length;
    }

    isSuccess(status: number): boolean {
        return status === 0;
    }

    isError(status: number): boolean {
        return status === 1;
    }

    isSuccessUnknown(status: number): boolean {
        return status === 2;
    }

    isErrorUnknown(status: number): boolean {
        return status === 3;
    }

    ngOnInit() {
        this.route.params.subscribe(params => {
            this.currentFilter = QuickFilter.fromName(params.filter);
        });

        this.route.queryParams.subscribe(query => {
            this.sortDescending = query.order === 'desc';
            this.sortField = query.sortBy;

            this.currentSortColumn = this.allColumns.find(column => {
                return column instanceof SortableColumn && column.name == query.sortBy;
            }) as SortableColumn || this.currentSortColumn;

            this.resetPage();
        });
    }
    
    convertToTrainingCase(caseReport): void {
      this.selectedCase = caseReport;
      this.modal.getModal('modalExportDataCollectors').open();
    }

    convert() {
      console.log(this.selectedCase);
      this.modal.getModal('modalExportDataCollectors').close();
    }
}
