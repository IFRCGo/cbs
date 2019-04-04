import ReportStatus from './ReportStatus';

function stringCompare(a, b) {
  a = a || 'unknown';
  b = b || 'unknown';

  a = a.toLocaleString();
  b = b.toLocaleString();

  if (a < b) {return -1}
  if (a > b) {return 1}

  return 0;
}

function dateCompare(a, b) {
  return new Date(a.timestamp).valueOf() - new Date(b.timestamp).valueOf();
}

function numericalSort(a, b) {
  return Number(a) - Number(b);
}

function hasHealthRisk(c) {
  return c.healthRiskId !== null;
}

function statusCompare(a, b) {
  return ReportStatus.isSuccess(a.status) - ReportStatus.isSuccess(b.status);
}

function dataCollectorCompare(fieldName) {
  return function(a, b) {
    return stringCompare(a[fieldName], b[fieldName]);
  }
}

function numericalFieldSort(fieldName) {
  return function(a, b) {
    return numericalSort(a[fieldName], b[fieldName]);
  }
}

export default class ReportColumns {
  static get Columns() {
    return {
      date: ['Date', dateCompare, c => true],
      time: 'Time',
      status: ['Status', statusCompare, c => true],
      dataCollector: ['Data Collector', dataCollectorCompare('dataCollectorDisplayName'), hasHealthRisk],
      region: ['Region', dataCollectorCompare('dataCollectorRegion'), hasHealthRisk],
      district: ['District', dataCollectorCompare('dataCollectorDistrict'), hasHealthRisk],
      village: ['Village', dataCollectorCompare('dataCollectorVillage'), hasHealthRisk],
      healthRisk: ['Health Risk', dataCollectorCompare('healthRisk'), hasHealthRisk],
      malesAges0To4: ['Males < 5', numericalFieldSort('numberOfMalesUnder5'), hasHealthRisk],
      malesAgedOver4: ['Males ≥ 5', numericalFieldSort('numberOfMalesAged5AndOlder'), hasHealthRisk],
      femalesAges0To4: ['Females < 5', numericalFieldSort('numberOfFemalesUnder5'), hasHealthRisk],
      femalesAgesOver4: ['Females ≥ 5', numericalFieldSort('numberOfFemalesAged5AndOlder'), hasHealthRisk]
    }
  }

  static getColumnData(columnKey) {
    return Array.isArray(ReportColumns.Columns[columnKey]) ? ReportColumns.Columns[columnKey] :
      [ReportColumns.Columns[columnKey]];
  }

  static renderer(currentSortColumn, renderItemFn) {
    return Object.keys(ReportColumns.Columns).map((columnKey, index) => {
      const columnData = ReportColumns.getColumnData(columnKey);
      const isSortable = columnData[1];
      const isActiveSortColumn = currentSortColumn === columnKey;

      return renderItemFn({
        name: columnData[0],
        isSortable,
        columnKey,
        index,
        isActiveSortColumn
      });
    });
  }

  static applySorting(data, currentSortColumn, isSortedAscending) {
    const column = ReportColumns.Columns[currentSortColumn];
    const sortFn = Array.isArray(column) ? column[1] : null;
    const predicateFn = Array.isArray(column) ? column[2] : null;

    if (sortFn) {
      return data.sort((a, b) => {
        const aIsSortable = predicateFn(a);
        const bIsSortable = predicateFn(b);

        if (aIsSortable && !bIsSortable) {
          return -1;
        }

        if (!aIsSortable && bIsSortable) {
          return 1;
        }

        return sortFn(a, b) * (isSortedAscending ? 1 : -1);
      });
    }

    return null;
  }
}
