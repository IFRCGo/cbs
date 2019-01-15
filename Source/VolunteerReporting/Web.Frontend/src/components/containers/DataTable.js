import React, {Component} from 'react';
import {Link} from 'react-router-dom';
import {utils} from '@ifrc-cbs/common-react-ui';
import ReportStatus from '../../lib/ReportStatus';
import ReportColumns from '../../lib/ReportColumns';

const {formatDate, formateTime} = utils;

class TableHead extends Component {
  renderSortArrowTag(columnData) {
    const {isSortedAscending} = this.props;
    const cssClassName = `fa ${isSortedAscending ? 'fa-chevron-up' : 'fa-chevron-down' }`;

    return columnData.isActiveSortColumn ? <i className={cssClassName} /> : null;
  }

  renderTableColumnHeader(columnData) {
    const {currentFilter, isSortedAscending} = this.props;

    if (columnData.isSortable) {
      return (
        <th key={columnData.index}>
          <Link to={`/reporting/${currentFilter}?sortBy=${columnData.columnKey}&order=${isSortedAscending ? 'desc' : 'asc'}`}>
            {this.renderSortArrowTag(columnData)}
            {columnData.name}
          </Link>
        </th>);
    }

    return <th key={columnData.index}>{columnData.name}</th>;
  }

  render() {
    const {currentSortColumn} = this.props;

    return (
      <thead>
        <tr>
          {
            ReportColumns.renderer(currentSortColumn, (column) => {
              return this.renderTableColumnHeader(column);
            })
          }
        </tr>
      </thead>
    );
  }
}

export default class DataTable extends Component {
  render() {
    const {currentSortColumn, currentFilter, data, isSortedAscending} = this.props;

    return (
      <table className="table table-bordered table-striped">
        <TableHead isSortedAscending={isSortedAscending}
                   currentFilter={currentFilter}
                   currentSortColumn={currentSortColumn}/>

        <tbody>
        {
          data.map((caseReport, index) => {
            const isOriginStatus = ReportStatus.isOriginStatus(caseReport.origin);
            const isSuccess = ReportStatus.isSuccess(caseReport.status);

            return (<tr key={index}>
              <td>{formatDate(caseReport.timestamp)}</td>
              <td>{formateTime(caseReport.timestamp)}</td>
              <td>
                <span className={`label ${isSuccess ? 'label-success' : 'label-danger'}`}>{isSuccess ? 'Success' : 'Error'}</span>
              </td>

              {
                isOriginStatus ? <td>Origin: {caseReport.origin}</td> :
                  <td>{caseReport.dataCollectorDisplayName || 'Unknown'}</td>
              }
              { isOriginStatus ? <td /> : <td>{caseReport.dataCollectorRegion || 'Unknown'}</td> }
              { isOriginStatus ? <td /> : <td>{caseReport.dataCollectorDistrict || 'Unknown'}</td> }
              { isOriginStatus ? <td /> : <td>{caseReport.dataCollectorVillage || 'Unknown'}</td>}

              { isSuccess ? <td>{caseReport.healthRisk}</td> : <td colSpan="5">
                  {caseReport.message} Parsing errors: {caseReport.parsingErrorMessage}
                </td>
              }
              { isSuccess ? <td>{caseReport.numberOfMalesUnder5}</td> : null}
              { isSuccess ? <td>{caseReport.numberOfMalesAged5AndOlder}</td> : null}
              { isSuccess ? <td>{caseReport.numberOfFemalesUnder5}</td> : null}
              { isSuccess ? <td>{caseReport.numberOfFemalesAged5AndOlder}</td> : null}
            </tr>)
          })
        }
        </tbody>
      </table>
    );
  }
}
