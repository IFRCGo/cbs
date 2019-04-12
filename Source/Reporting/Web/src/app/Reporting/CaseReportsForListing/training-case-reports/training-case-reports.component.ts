import { Component, OnInit } from '@angular/core';
import { Column, SortableColumn, CaseReportColumns } from '../sort/columns';
import caseReports from '../../../../mocking/caseReports';
import dataCollectors from '../../../../mocking/dataCollectors';
import { QuickFilter } from '../filtering/filter.pipe';
import { QueryCoordinator } from '@dolittle/queries';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'cbs-training-case-reports',
  templateUrl: './training-case-reports.component.html',
  styleUrls: ['./training-case-reports.component.scss']
})
export class TrainingCaseReportsComponent implements OnInit {

  allColumns: Array<Column> = CaseReportColumns;
  listedReports: any[] = caseReports;
  sortDescending: boolean = true;
  currentSortColumn: SortableColumn = CaseReportColumns[0] as SortableColumn; // Timestamp

  page = {
    isLoading: false,
    number: 0,
    size: 50,
    sizes: [10, 20, 50, 100, 200, 500, 1000]
  };

  constructor(private queryCoordinator: QueryCoordinator,
    private route: ActivatedRoute,
    private router: Router, ) {
  }

  ngOnInit() {
  }

  updateNavigation(filter: QuickFilter, column: SortableColumn, sortDescending: boolean) {
    this.router.navigate(['../' + filter.name], {
      relativeTo: this.route, queryParams: {
        sortBy: column.name,
        order: sortDescending ? 'desc' : 'asc'
      }
    });
  }

  clickFilter(filter: QuickFilter) {
    this.updateNavigation(filter, this.currentSortColumn, this.sortDescending);
  }

  getTimeOrDay(date: Date, elt) {

    switch (elt) {
      case 'date': {
        let day = date.getDate();
        let month = date.getMonth() + 1;
        let year = date.getFullYear();

        let d = day + "";
        let m = month + "";
        let y = year + "";

        if (d.length == 1) {
          d = "0" + day;
        }
        if (m.length == 1) {
          m = "0" + month;
        }
        if (y.length == 1) {
          y = "0" + year;
        }

        return d + "/" + m + "/" + y;
      }
      case 'time': {
        let hours = date.getHours();
        let minutes = date.getMinutes();

        let h = hours + "";
        let m = minutes + "";

        if (h.length == 1) {
          h = "0" + hours;
        }
        if (m.length == 1) {
          m = "0" + minutes;
        }

        return h + ":" + m;
      }
      default: {
        return ''
      }
    }
  }

  getDataCollectorById(id) {
    let collectorsList = dataCollectors;
    let collector: any;

    for (let i = 0; i < collectorsList.length; i++) {
      if (collectorsList[i].id == id) {
        collector = collectorsList[i];
        break;
      }
    }
    return collector;
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

  isLastPage(): boolean {
    return this.page.size > this.listedReports.length;
  }

  resetPage(): void {
    this.page.number = 0;
    this.loadListData();
  }

  loadListData(): void {
    if (this.page.size < caseReports.length) {

      this.listedReports = [];
      let reports = [];
      let i = 0;

      caseReports.forEach(element => {
        if (i < this.page.size) {
          if (this.getDataCollectorById(element.dataCollectorId).inTraining == true) {
            reports.push(element);
            i++;
          }
          else{
            return;
          }
        }
      });

      this.listedReports = reports;
    }
    else {
      this.listedReports = caseReports;
    }
  }

}
