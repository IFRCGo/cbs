import { Component, OnInit, HostListener } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { QueryCoordinator } from '@dolittle/queries';
import { Column, SortableColumn, CaseReportColumns } from './sort/columns';
import { QuickFilter } from './filtering/filter.pipe';
import { TrainingReport } from '../CaseReports/TrainingReport';
import { AllTrainingReports } from '../CaseReports/AllTrainingReports';

@Component({
    selector: 'cbs-training-report-list',
    templateUrl: './training-report-list.component.html',
    styleUrls: ['./case-report-list.component.scss']
})
export class TrainingReportListComponent implements OnInit {

    listedReports: Array<TrainingReport> = [];

    allFilters: Array<QuickFilter> = QuickFilter.Filters;
    currentFilter: QuickFilter = QuickFilter.All;

    allColumns: Array<Column> = CaseReportColumns;
    sortDescending: boolean = true;
    sortField: string;
    currentSortColumn: SortableColumn = CaseReportColumns[0] as SortableColumn; // Timestamp

    page = {
        isLoading: false,
        number: 0,
        size: 50,
        sizes: [10, 20, 50, 100, 200, 500, 1000]
    };

    constructor(
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

    loadListData(): void {
        const queryCoordinator = new QueryCoordinator();
        const query = new AllTrainingReports();
        query.pageNumber = this.page.number;
        query.pageSize = this.page.size;
        query.sortField = this.sortField;
        query.sortAscending = !this.sortDescending;
        this.page.isLoading = true;
        queryCoordinator.execute(query)
            .then(response => {
                if (response.success) {
                    this.listedReports = response.items as Array<TrainingReport>;
                    this.listedReports.forEach(element => {
                        element.timestamp = new Date(element.timestamp);
                    });
                    console.log(this.listedReports);
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
}
