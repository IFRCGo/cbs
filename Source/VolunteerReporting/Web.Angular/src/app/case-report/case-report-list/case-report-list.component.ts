import { Component, OnInit, HostListener } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Column, SortableColumn, CaseReportColumns } from './sort/columns';
import { QuickFilter } from './filtering/filter.pipe';
import { AllCaseReportsForListing } from '../../domain/case-report/queries/AllCaseReportsForListing';

import * as fromServices from '../../services';
import * as fromModels from '../../shared/models';



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

    listedReports: Array<fromModels.CaseReportForListing>;

    allFilters: Array<QuickFilter> = QuickFilter.Filters;
    currentFilter: QuickFilter = QuickFilter.All;

    allColumns: Array<Column> = CaseReportColumns;
    sortDescending: boolean = true;
    currentSortColumn: SortableColumn = CaseReportColumns[0] as SortableColumn; // Timestamp

    page = {
        isLoading: false,
        number: 0,
        size: 50,
        sizes: [10, 20, 50, 100, 200, 500, 1000]
    };

    constructor(
        private queryCoordinator: fromServices.QueryCoordinator<fromModels.CaseReportForListing>,
        private route: ActivatedRoute,
        private router: Router
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

    buildListParams(): fromModels.ListParams {
        return {
            pageNumber: this.page.number,
            pageSize: this.page.size 
        };
    }

    laodListData(): void {
        const queryRequest = new AllCaseReportsForListing();
        this.page.isLoading = true;
        queryRequest.parameters = this.buildListParams();
        this.queryCoordinator.handle(queryRequest)
            .then(response => {
                if (response.success) {
                    this.listedReports = response.items as Array<fromModels.CaseReportForListing>;
                    this.listedReports.forEach(element => {
                        element.timestamp = new Date(element.timestamp);
                    });
                    
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
        this.laodListData();
    }

    showPrevPage(): void {
        if (this.page.number) {
            this.page.number--;
            this.laodListData();
        }
    }

    showNextPage(): void {
        this.page.number++;
        this.laodListData();
    }

    isSuccessStatus(status: number): boolean {
        return status === 0 || status === 2;
    }

    isOriginStatus(status:number): boolean {
        return status === 2 || status === 3;
    }

    ngOnInit() {
        this.laodListData();

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
