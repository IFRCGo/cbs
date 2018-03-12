import {Injectable} from '@angular/core';
import {CaseReportForListing} from '../../../shared/models/case-report-for-listing.model';


@Injectable()
export class CaseReportExporter {
  constructor() {
  }

  exportToCsv(listedReports: Array<CaseReportForListing>, fields: Array<string>) {
    //TODO: Should export the list of CaseReports using the various applied filters on the list to produce a
    // csv file that will be downloaded by the client.
    // I have not figured out to do this yet, I tried looking it up, tried using different packages, but it
    // all just grew into a mess and nothing worked. That's why I have not done anything here atm.
    // We really should have someone that has experience with this frontend here.
    // --Woksin

  }
}
