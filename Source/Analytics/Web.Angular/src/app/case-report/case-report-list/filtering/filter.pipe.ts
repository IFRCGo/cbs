import {Pipe, PipeTransform} from '@angular/core';
import {CaseReportForListing} from '../../../shared/models/case-report-for-listing.model';
import {CaseReportStatus} from '../../../shared/models/case-report-status.model';

export class QuickFilter {
    constructor(
        public name: string,
        public description: string,
        public evaluate: (report:CaseReportForListing) => boolean
    ) {}

    static All: QuickFilter = new QuickFilter('all', 'All', report => {
        return true;
    });
    static Success: QuickFilter = new QuickFilter('success', 'Success', report => {
        return report.status === CaseReportStatus.Success
            || report.status === CaseReportStatus.UnknownDataCollector;
    });
    static Error: QuickFilter = new QuickFilter('error', 'Data error', report => {
        return report.status === CaseReportStatus.TextMessageParsingError
            || report.status === CaseReportStatus.TextMessageParsingErrorAndUnknownDataCollector;
    });
    static UnknownSender: QuickFilter = new QuickFilter('unknownSender', 'Unknown sender', report => {
        return report.status === CaseReportStatus.UnknownDataCollector
            || report.status === CaseReportStatus.TextMessageParsingErrorAndUnknownDataCollector;
    });

    static Filters: Array<QuickFilter> = [
        QuickFilter.All, QuickFilter.Success, QuickFilter.Error, QuickFilter.UnknownSender
    ];

    static fromName(name: string) : QuickFilter {
        return QuickFilter.Filters.find(filter => filter.name == name) || QuickFilter.All;
    }
}

@Pipe({
  name: 'filter',
  pure: false
})
export class Filter implements PipeTransform {
  transform(reports: Array<CaseReportForListing>, filter: QuickFilter) {
    if (!reports) { return []; }
    return reports.filter(filter.evaluate);
  }
}
