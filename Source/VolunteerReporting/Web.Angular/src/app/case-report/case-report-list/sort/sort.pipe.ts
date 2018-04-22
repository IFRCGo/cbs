import {Pipe, PipeTransform} from '@angular/core';
import {CaseReportForListing} from '../../../shared/models/case-report-for-listing.model';

import {SortableColumn} from './columns';

@Pipe({
    name: 'sort',
    pure: false
})
export class Sort implements PipeTransform {
    transform(reports: Array<CaseReportForListing>, column: SortableColumn, sortDescending: boolean) {
        if (!reports) { return []; }
        return reports.sort((a: CaseReportForListing, b: CaseReportForListing) => {
            const aIsSortable = column.predicate(a);
            const bIsSortable = column.predicate(b);
            // Show "non-sortable" elements last
            if (aIsSortable && !bIsSortable) { return -1; }
            if (!aIsSortable && bIsSortable) { return 1; }
            // Otherwise, sort by comparison function (possibly reversed)
            return column.compare(a, b) * (sortDescending ? -1 : 1);
        });
    }
}
