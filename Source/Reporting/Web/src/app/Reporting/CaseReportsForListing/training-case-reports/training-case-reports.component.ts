import { Component, OnInit, HostListener } from '@angular/core';
import { Column, SortableColumn, CaseReportColumns } from '../sort/columns';
import {QueryCoordinator} from '@dolittle/queries';
import {CommandCoordinator} from '@dolittle/commands';
import { QuickFilter } from '../filtering/filter.pipe';
import { ActivatedRoute, Router } from '@angular/router';
import { AllTrainingCaseReportsForListing } from '../../TrainingCaseReportsForListing/AllTrainingCaseReportsForListing';
import { TrainingCaseReportForListing } from '../../TrainingCaseReportsForListing/TrainingCaseReportForListing';
import { NgxSmartModalService } from 'ngx-smart-modal';
import { ConvertToLiveReport } from '../../CaseReports/ConvertToLiveReport';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'cbs-training-case-reports',
  templateUrl: './training-case-reports.component.html',
  styleUrls: ['./training-case-reports.component.scss']
})
export class TrainingCaseReportsComponent implements OnInit {

    convertToLiveReportCommand: ConvertToLiveReport;
    listedReports: Array<TrainingCaseReportForListing> = []; //TODO: Should be another, TrainingCaseReports, read model

    allFilters: Array<QuickFilter> = QuickFilter.FiltersWithoutUnknownSender;
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

    selectedCase;

    constructor(
        private queryCoordinator: QueryCoordinator,
        private commandCoordinator: CommandCoordinator,
        private toastr: ToastrService,
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
        const query = new AllTrainingCaseReportsForListing(); //TODO: Should be another, TrainingCaseReports, read model. Another query
        query.pageNumber = this.page.number;
        query.pageSize = this.page.size;
        query.sortField = this.sortField;
        query.sortAscending = !this.sortDescending;
        this.page.isLoading = true;
        this.queryCoordinator.execute(query)
            .then(response => {
                if (response.success) {
                    this.listedReports = response.items as Array<TrainingCaseReportForListing>; //TODO: Should be another, TrainingCaseReports, read model
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

    convertToLiveCase(caseReport): void {
        this.convertToLiveReportCommand = new ConvertToLiveReport();
        this.convertToLiveReportCommand.caseReportId = caseReport.id;
        this.modal.getModal('modalExportDataCollectors').open();
    }

    convert() { 
        console.log(this.convertToLiveReportCommand);
        this.commandCoordinator.handle(this.convertToLiveReportCommand)
            .then(response => {
                if (response.success)  {
                    this.toastr.success('Successfully converted case report');
                } else {
                    if (!response.passedSecurity) { // Security error
                        this.toastr.error('Could not convert case report because of security issues');
                    } else {
                        const errors = response.allValidationMessages.join('\n');
                        this.toastr.error('Could not convert case report:\n' + errors);
                    }
                }
            })
            .catch(response => {
                if (!response.passedSecurity) { // Security error
                    this.toastr.error('Could not convert case report because of security issues');
                } else {
                    const errors = response.allValidationMessages.join('\n');
                    this.toastr.error('Could not convert case report:\n' + errors);
                }
            });
        this.modal.getModal('modalExportDataCollectors').close();
    }
}
