import { Component, OnInit } from '@angular/core';
import { Column, SortableColumn, CaseReportColumns } from '../sort/columns';
import caseReports from '../../../../mocking/caseReports';
import dataCollectors from '../../../../mocking/dataCollectors';


@Component({
  selector: 'cbs-training-case-reports',
  templateUrl: './training-case-reports.component.html',
  styleUrls: ['./training-case-reports.component.scss']
})
export class TrainingCaseReportsComponent implements OnInit {

  allColumns: Array<Column> = CaseReportColumns;
  listedReports: any[] = caseReports;

  allReports = caseReports;

  constructor() {
    console.log("allReports", this.allReports[0].timestamp.getDate());
    console.log("dataCollectors: ", dataCollectors);
  }

  ngOnInit() {
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

}
