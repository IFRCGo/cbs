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
        // The compare function should return < 0 if a is to come before b when sorted in ascending order
        public compare: (a: CaseReportForListing, b: CaseReportForListing) => number,
        public predicate: (c: CaseReportForListing) => boolean
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
        'date', 'Date',
        (a: CaseReportForListing, b: CaseReportForListing) =>
            a.timestamp.valueOf() - b.timestamp.valueOf(),
        (c: CaseReportForListing) =>
            true
    ),
    new Column(
        'time', 'Time'
    ),
    new SortableColumn(
        'status', 'Status',
        (a: CaseReportForListing, b: CaseReportForListing) =>
            Number(!!a.healthRiskId) - Number(!!b.healthRiskId),
        (c: CaseReportForListing) =>
            true
    ),
    new SortableColumn(
        'dataCollector', 'Data Collector',
        (a: CaseReportForListing, b: CaseReportForListing) =>
            stringCompare(a.dataCollectorDisplayName, b.dataCollectorDisplayName),
        hasHealthRisk
    ),
    new SortableColumn(
        'region', 'Region',
        (a: CaseReportForListing, b: CaseReportForListing) =>
            stringCompare(a.dataCollectorRegion, b.dataCollectorRegion),
        hasHealthRisk
    ),
    new SortableColumn(
        'district', 'District',
        (a: CaseReportForListing, b: CaseReportForListing) =>
            stringCompare(a.dataCollectorDistrict, b.dataCollectorDistrict),
        hasHealthRisk
    ),
    new SortableColumn(
        'village', 'Village',
        (a: CaseReportForListing, b: CaseReportForListing) =>
            stringCompare(a.dataCollectorVillage, b.dataCollectorVillage),
        hasHealthRisk
    ),
    new SortableColumn(
        'healthRisk', 'Health Risk',
        (a: CaseReportForListing, b: CaseReportForListing) =>
            stringCompare(a.healthRisk, b.healthRisk),
        hasHealthRisk
    ),
    new SortableColumn(
        'malesAges0To4', 'Males < 5',
        (a: CaseReportForListing, b: CaseReportForListing) =>
            a.numberOfMalesUnder5 - b.numberOfMalesUnder5,
        hasHealthRisk
    ),
    new SortableColumn(
        'malesAgedOver4', 'Males ≥ 5',
        (a: CaseReportForListing, b: CaseReportForListing) =>
            a.numberOfMalesAged5AndOlder - b.numberOfMalesAged5AndOlder,
        hasHealthRisk
    ),
    new SortableColumn(
        'femalesAges0To4', 'Females < 5',
        (a: CaseReportForListing, b: CaseReportForListing) =>
            a.numberOfFemalesUnder5 - b.numberOfFemalesUnder5,
        hasHealthRisk
    ),
    new SortableColumn(
        'femalesAgesOver4', 'Females ≥ 5',
        (a: CaseReportForListing, b: CaseReportForListing) =>
            a.numberOfFemalesAged5AndOlder - b.numberOfFemalesAged5AndOlder,
        hasHealthRisk
    )
];
