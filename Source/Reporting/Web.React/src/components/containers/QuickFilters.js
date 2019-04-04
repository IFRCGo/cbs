import React, {Component} from 'react';
import {Link} from 'react-router-dom';

import Filters from '../../lib/Filters';

export default class QuickFilters extends Component {
  render() {
    const {currentFilter} = this.props;

    return (<table className="table table-bordered table-striped">
      <tbody>
      <tr>
        <td>
          Quick Filters:
          <span>
            {Object.keys(Filters.List).map((filterKey, index) => {
              let filter = Filters.List[filterKey];
              if (!Array.isArray(filter)) {
                filter = [Filters.List[filterKey]];
              }

              return (<Link to={`/reporting/${filterKey}`}
                           className="btn btn-sm btn-info"
                           key={index}
                           style={{
                             marginRight: '2px',
                             marginLeft: '2px',
                             fontWeight: currentFilter === filterKey ? 'bold' : 'normal'
                           }}>{filter[0]}</Link>)
            })}
          </span>
        </td>
      </tr>
      </tbody>
    </table>);
  }
}
