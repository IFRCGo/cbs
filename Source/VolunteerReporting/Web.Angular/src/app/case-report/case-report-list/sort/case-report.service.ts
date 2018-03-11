import {Injectable} from '@angular/core';

import {Report} from '../../../shared/models/report.model';
import {CaseReportForListing} from '../../../shared/models/case-report-for-listing.model';
import {CaseReportStatus} from '../../../shared/models/case-report-status.model';

@Injectable()
export class ReportService {

  static hasDC(report: CaseReportForListing) {
    return report.dataCollectorId != null;
  }

  static hasHealthRisk(report: CaseReportForListing) {
    return report.healthRiskId != null;
  }

  static compareStandard(a: CaseReportForListing, b: CaseReportForListing, field: string,
                         predicate: (report: CaseReportForListing) => boolean, criteria: ReportSearchCriteria) {
    const res = (!predicate(a) && !predicate(b)) ? 0
      : (!predicate(a) && predicate(b)) ? -1
        : (predicate(a) && !predicate(b)) ? 1
          : (a[field] < b[field]) ? 1
            : (a[field] > b[field]) ? -1 : 0;

    return (criteria.sortDirection === 'desc') ? res : res * -1;
  }

  getReports(reports: Array<CaseReportForListing>, criteria: ReportSearchCriteria) {

    if (criteria.sortColumn === 'timeStamp') {
      return reports.sort(function (a, b) {
        return (criteria.sortDirection === 'desc') ?
          a.timestamp < b.timestamp ? 1 : a.timestamp > b.timestamp ? -1 : 0
          : a.timestamp > b.timestamp ? 1 : a.timestamp < b.timestamp ? -1 : 0;
      });
    }

    // Sort by status
    if (criteria.sortColumn === 'status') {
      return reports.sort(function (a, b) {
        const result =
          ((a.healthRiskId && b.healthRiskId) || (!a.healthRiskId && !b.healthRiskId)) ?
            0 : a.healthRiskId ? -1 : 1;

        return (criteria.sortDirection === 'desc') ? result : result * -1;
      });
    }

    // Sort by datacollector displayname
    if (criteria.sortColumn === 'dataCollector') {
      return reports.sort(function (a, b) {
        return ReportService.compareStandard(a, b, 'dataCollectorDisplayName',
          ReportService.hasDC, criteria);
      });
    }

    // Sort by HealthRisk
    if (criteria.sortColumn === 'healthRisk') {
      return reports.sort(function (a, b) {
        return ReportService.compareStandard(a, b, 'healthRisk',
          ReportService.hasHealthRisk, criteria);
      });
    }

    // Sort by femalesAgedOver4
    if (criteria.sortColumn === 'femalesAgedOver4') {
      return reports.sort(function (a, b) {
        return ReportService.compareStandard(a, b, 'numberOfFemalesAgedOver4',
          ReportService.hasHealthRisk, criteria);
      });
    }

    // Sort by femalesAges0To4
    if (criteria.sortColumn === 'femalesAges0To4') {
      return reports.sort(function (a, b) {
        return ReportService.compareStandard(a, b, 'numberOfFemalesAges0To4',
          ReportService.hasHealthRisk, criteria);
      });
    }

    // Sort by malesOAgedOver4
    if (criteria.sortColumn === 'malesAgedOver4') {
      return reports.sort(function (a, b) {
        return ReportService.compareStandard(a, b, 'numberOfMalesAgedOver4',
          ReportService.hasHealthRisk, criteria);
      });
    }

    // Sort by malesAges0To4
    if (criteria.sortColumn === 'malesAges0To4') {
      return reports.sort(function (a, b) {
        return ReportService.compareStandard(a, b, 'numberOfMalesAges0To4',
          ReportService.hasHealthRisk, criteria);
      });
    }

    return reports;
  }
}

export class ReportSearchCriteria {
  sortColumn: string;
  sortDirection: string;
}
