import React, {Component} from 'react';
import moment from 'moment';
import Controller from '../controller.js';

const Success = 'Success';
const TextMessageParsingError = 'TextMessageParsingError';
const UnknownDataCollector = 'UnknownDataCollector';
const TextMessageParsingErrorAndUnknownDataCollector = 'TextMessageParsingErrorAndUnknownDataCollector';

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

const CaseReportColumns = {
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
};

const CaseReportStatus = {
  Success,
  TextMessageParsingError,
  UnknownDataCollector,
  TextMessageParsingErrorAndUnknownDataCollector
};

class VolunteerReporting extends Component {

  static get Filters () {
    return {
      all: 'All',

      success: ['Success', report => {
        return report.status === CaseReportStatus.Success
          || report.status === CaseReportStatus.UnknownDataCollector;
      }],

      error: ['Data error', report => {
        return report.status === CaseReportStatus.TextMessageParsingError
          || report.status === CaseReportStatus.TextMessageParsingErrorAndUnknownDataCollector;
      }],

      unknownSender: ['Unknown sender', report => {
        return report.status === CaseReportStatus.UnknownDataCollector
          || report.status === CaseReportStatus.TextMessageParsingErrorAndUnknownDataCollector;
      }]
    }
  }

  componentDidMount() {
    this.props.fetchAllCaseReports();
  }

  componentDidUpdate(prevProps) {

  }

  clickFilter() {

  }

  openExporter() {

  }

  formatDate(dateString) {
    return moment(dateString).format('DD.MM.YYYY');
  }

  formateTime(dateString) {
    return moment(dateString).format('HH:mm');
  }

  isSuccessStatus(status) {
    return status === 0 || status === 2;
  }

  isOriginStatus(status) {
    return status === 2 || status === 3;
  }

  render() {
    const userName = 'DEV';
    const {caseReports} = this.props;
    const isLoggedIn = false;
    const currentFilter = 'all';
    const currentSortColumn = '';
    const sortDescending = '';

    return <div>
      
      <div className="container">
        <h3>
          Case Reports
        </h3>

        {/*<cbs-case-report-export #exporter></cbs-case-report-export>*/}

        <div className="actions">
          <button onClick={this.openExporter()}>Export</button>
        </div>

        <table className="table table-bordered table-striped">
          <tbody>
            <tr>
              <td>
                Quick Filters:
                <span>
                  {Object.keys(VolunteerReporting.Filters).map((filterKey, index) => {
                    const filter = Array.isArray(VolunteerReporting.Filters[filterKey]) ?
                      VolunteerReporting.Filters[filterKey] :
                      [VolunteerReporting.Filters[filterKey]];

                    return <button key={index}
                                   style={{
                                     fontWeight: currentFilter === filterKey ? 'bold' : 'normal'
                                   }}
                                   onClick={this.clickFilter.bind(this, filter)}>{filter[0]}</button>
                  })}
                </span>
              </td>
            </tr>
          </tbody>
        </table>

        <table className="table table-bordered table-striped">
          <thead>
            <tr>

                {Object.keys(CaseReportColumns).map((columnKey, index) => {
                  const column = Array.isArray(CaseReportColumns[columnKey]) ? CaseReportColumns[columnKey] : [CaseReportColumns[columnKey]];

                  return <th key={index}>{column[0]}</th>;
                })}

                {/* *ngFor="let column of allColumns"
                [column]="column"
                        [current-sorted]=" currentSortColumn"
                        [sort-descending]=" sortDescending"
                        (click)=" toggleSortColum(column)"*/}
            </tr>
          </thead>

          <tbody> {
            caseReports.map((caseReport, index) => {
              // "let caseReport of listedReports | filter:currentFilter | sort:currentSortColumn:sortDescending"
              return <tr key={index}>
                <td>{this.formatDate(caseReport.timestamp)}</td>
                <td>{this.formateTime(caseReport.timestamp)}</td>
                <td>
                  {
                    this.isSuccessStatus(caseReport.status) ?
                      <span className="label label-success">Success</span>:
                      <span className="label label-danger">Error</span>
                  }
                </td>

                {
                  this.isOriginStatus(caseReport.origin) ?
                    <td>Origin: {caseReport.origin}</td> :
                    <td>{caseReport.dataCollectorDisplayName || 'Unknown'}</td>
                }

                {
                  this.isOriginStatus(caseReport.origin) ?
                    <td></td> :
                    <td>{caseReport.dataCollectorRegion || 'Unknown'}</td>
                }

                {
                  this.isOriginStatus(caseReport.origin) ?
                    <td></td> :
                    <td>{caseReport.dataCollectorDistrict || 'Unknown'}</td>
                }

                {
                  this.isOriginStatus(caseReport.origin) ?
                    <td></td> :
                    <td>{caseReport.dataCollectorVillage || 'Unknown'}</td>
                }

                {
                  this.isSuccessStatus(caseReport.status) ?
                    <td>{caseReport.healthRisk}</td> :
                    <td colSpan="5">
                      {caseReport.message} Parsing errors: {caseReport.parsingErrorMessage}
                    </td>
                }

                {
                  this.isSuccessStatus(caseReport.status) ? <td>{caseReport.numberOfMalesUnder5}</td> : null
                }
                {
                  this.isSuccessStatus(caseReport.status) ? <td>{caseReport.numberOfMalesAged5AndOlder}</td> : null
                }
                {
                  this.isSuccessStatus(caseReport.status) ? <td>{caseReport.numberOfFemalesUnder5}</td> : null
                }
                {
                  this.isSuccessStatus(caseReport.status) ? <td>{caseReport.numberOfFemalesAged5AndOlder}</td> : null
                }
              </tr>
            })
          }
        </tbody>
        </table>

      </div>
    </div>;
  }
}

export default new Controller(VolunteerReporting);