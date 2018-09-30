import {CaseReportForListing} from '../../../shared/models/case-report-for-listing.model';

export class Column {
    constructor(
      public name: string,
      public description: string
    ) {}
}

export class SortableColumn extends Column {
    constructor(
        public name: string,
        public description: string,
        public isSortable: boolean
    ) { super(name, description); }
}

const stringCompare = (a: string, b: string): number => {
    if (a < b) { return -1; }
    if (a > b) { return 1; }
    return 0;
};

const hasHealthRisk = (c : CaseReportForListing): boolean => {
  return c.healthRiskId !== null;
};

export const CaseReportColumns: Array<Column> = [
    new SortableColumn(
        'Timestamp', 'Date', true
    ),
    new Column(
        'time', 'Time'
    ),
    new SortableColumn(
        'Status', 'Status', true
    ),
    new SortableColumn(
        'DataCollectorDisplayName', 'Data Collector', true
    ),
    new Column(
        'region', 'Region'
    ),
    new Column(
        'district', 'District'
    ),
    new Column(
        'village', 'Village'
    ),
    new SortableColumn(
        'HealthRisk', 'Health Risk', true
    ),
    new SortableColumn(
        'NumberOfMalesUnder5', 'Males < 5', true
    ),
    new SortableColumn(
        'NumberOfMalesAged5AndOlder', 'Males ≥ 5', true
    ),
    new SortableColumn(
        'NumberOfFemalesUnder5', 'Females < 5', true
    ),
    new SortableColumn(
        'NumberOfFemalesAged5AndOlder', 'Females ≥ 5', true
    )
];
