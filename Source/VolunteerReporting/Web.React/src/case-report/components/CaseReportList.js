import React, {Component} from 'react';
import moment from 'moment';

export const ReportStatus = {
  Success: 0,
  TextMessageParsingError: 1,
  UnknownDataCollector: 2,
  TextMessageParsingErrorAndUnknownDataCollector: 3
};

export default class CaseReportList extends Component {

  formatDate(dateString) {
    return moment(dateString).format('DD.MM.YYYY');
  }

  formateTime(dateString) {
    return moment(dateString).format('HH:mm');
  }

  isSuccessStatus(status) {
    return status === ReportStatus.Success || status === ReportStatus.UnknownDataCollector;
  }

  isOriginStatus(status) {
    return status === ReportStatus.UnknownDataCollector || status === ReportStatus.TextMessageParsingErrorAndUnknownDataCollector;
  }

  render() {
    const {caseReports} = this.props;

    return <tbody> {
      caseReports.map((caseReport, index) => {
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
  }
}