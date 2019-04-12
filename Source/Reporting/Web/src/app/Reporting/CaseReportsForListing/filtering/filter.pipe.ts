import {Pipe, PipeTransform} from '@angular/core';
import {CaseReportForListing} from '../CaseReportForListing';

enum CaseReportStatus {
    Success = 0,
    TextMessageParsingError,
    UnknownDataCollector,
    TextMessageParsingErrorAndUnknownDataCollector
}  

export class QuickFilter {
    constructor(
        public name: string,
        public description: string,
        public cssClass: string,
        public evaluate: (report:CaseReportForListing) => boolean
    ) {}

    static All: QuickFilter = new QuickFilter('all', 'All', '', () => {
        return true;
    });
    static Success: QuickFilter = new QuickFilter('success', 'Success', 'btn-success', report => {
        return report.status === CaseReportStatus.Success;
    });
    static Error: QuickFilter = new QuickFilter('error', 'Error', 'btn-danger', report => {
        return report.status === CaseReportStatus.TextMessageParsingError
            || report.status === CaseReportStatus.TextMessageParsingErrorAndUnknownDataCollector;
    });
    static UnknownSender: QuickFilter = new QuickFilter('unknownSender', 'Unknown sender', 'btn-warning', report => {
        return report.status === CaseReportStatus.UnknownDataCollector
            || report.status === CaseReportStatus.TextMessageParsingErrorAndUnknownDataCollector;
    });

    static Filters: Array<QuickFilter> = [
        QuickFilter.All, QuickFilter.Success, QuickFilter.Error, QuickFilter.UnknownSender
    ];
    
    static FiltersWithoutUnknownSender: Array<QuickFilter> = [
        QuickFilter.All, QuickFilter.Success, QuickFilter.Error
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
