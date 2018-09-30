import React, {Component} from 'react';
import {ReportStatus} from "./CaseReportList.js";

export default class QuickFilters extends Component {
  static get FiltersList () {
    return {
      all: 'All',

      success: ['Success', report => {
        return report.status === ReportStatus.Success || report.status === ReportStatus.UnknownDataCollector;
      }],

      error: ['Data error', report => {
        return report.status === ReportStatus.TextMessageParsingError
          || report.status === ReportStatus.TextMessageParsingErrorAndUnknownDataCollector;
      }],

      unknownSender: ['Unknown sender', report => {
        return report.status === ReportStatus.UnknownDataCollector
          || report.status === ReportStatus.TextMessageParsingErrorAndUnknownDataCollector;
      }]
    }
  }

  render() {
    const {currentFilter} = this.props;

    return <table className="table table-bordered table-striped">
      <tbody>
      <tr>
        <td>
          Quick Filters:
          <span>
            {Object.keys(QuickFilters.FiltersList).map((filterKey, index) => {
              const filter = Array.isArray(QuickFilters.FiltersList[filterKey]) ?
                QuickFilters.FiltersList[filterKey] : [QuickFilters.FiltersList[filterKey]];

              return <button key={index}
                             style={{
                               fontWeight: currentFilter === filterKey ? 'bold' : 'normal'
                             }}
                             onClick={this.props.onClickFilter.bind(this, filterKey)}>{filter[0]}</button>
            })}
          </span>
        </td>
      </tr>
      </tbody>
    </table>
  }
}