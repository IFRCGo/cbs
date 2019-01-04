import React, {Component} from 'react';

const stringCompare = (a, b) => {
  if (a < b) {
    return -1;
  }

  if (a > b) {
    return 1;
  }

  return 0;
};

const hasHealthRisk = c => {
  return c.healthRiskId !== null;
};

export default class CaseReportColumns extends Component {
  static get Columns() {
    return {
      date: ['Date', (a, b) => a.timestamp.valueOf() - b.timestamp.valueOf(), c => true],
      time: 'Time',
      status: ['Status', (a, b) => Number(!!a.healthRiskId) - Number(!!b.healthRiskId), c => true],
      dataCollector: ['Data Collector', (a, b) => stringCompare(a.dataCollectorDisplayName, b.dataCollectorDisplayName), hasHealthRisk],
      region: ['Region', (a, b) => stringCompare(a.dataCollectorRegion, b.dataCollectorRegion), hasHealthRisk],
      district: ['District', (a, b) => stringCompare(a.dataCollectorDistrict, b.dataCollectorDistrict), hasHealthRisk],
      village: ['Village', (a, b) => stringCompare(a.dataCollectorVillage, b.dataCollectorVillage), hasHealthRisk],
      healthRisk: ['Health Risk', (a, b) => stringCompare(a.healthRisk, b.healthRisk), hasHealthRisk],
      malesAges0To4: ['Males < 5', (a, b) => a.numberOfMalesUnder5 - b.numberOfMalesUnder5, hasHealthRisk],
      malesAgedOver4: ['Males ≥ 5', (a, b) => a.numberOfMalesAged5AndOlder - b.numberOfMalesAged5AndOlder, hasHealthRisk],
      femalesAges0To4: ['Females < 5', (a, b) => a.numberOfFemalesUnder5 - b.numberOfFemalesUnder5, hasHealthRisk],
      femalesAgesOver4: ['Females ≥ 5', (a, b) => a.numberOfFemalesAged5AndOlder - b.numberOfFemalesAged5AndOlder, hasHealthRisk]
    }
  }

  isSortedAscending() {
    return this.props.sortDescending !== true;
  }

  toggleSortColumn(column) {
    this.props.onToggleSortColumn(column);
  }

  render() {
    const {currentSortColumn} = this.props;

    return <thead>
      <tr>
        {Object.keys(CaseReportColumns.Columns).map((columnKey, index) => {
          const column = Array.isArray(CaseReportColumns.Columns[columnKey]) ? CaseReportColumns.Columns[columnKey] : [CaseReportColumns.Columns[columnKey]];

          return column[1] ? <th key={index} onClick={this.toggleSortColumn.bind(this, columnKey)}>
            {currentSortColumn === columnKey ? <i className={`fa ${this.isSortedAscending() ? 'fa-chevron-up' : 'fa-chevron-down' }`}></i> : null}
            {column[0]}</th> : <th key={index}>{column[0]}</th>;
        })}
      </tr>
      </thead>;
  }
}