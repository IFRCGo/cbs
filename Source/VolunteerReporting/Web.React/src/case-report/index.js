import React, {Component} from 'react';
import PropTypes from 'prop-types';

import QuickFilters from './components/QuickFilters.js';
import CaseReportColumns from './components/CaseReportColumns.js';
import CaseReportList from './components/CaseReportList.js';

import Controller from './controller.js';

const parseQueryString = function(query) {
  return query.split('&').reduce((prev, pair) => {
    let parts = pair.split('=');
    prev[parts[0]] = parts[1];

    return prev;
  }, {})
};

class VolunteerReporting extends Component {

  static get contextTypes () {
    return {
      router: PropTypes.shape({
        history: PropTypes.shape({
          push: PropTypes.func.isRequired,
          replace: PropTypes.func.isRequired,
          createHref: PropTypes.func.isRequired
        }).isRequired
      }).isRequired
    };
  }

  constructor(component) {
    super(component);

    this.state = {
      caseReports: null
    }
  }

  navigateTo(uri) {
    const {history} = this.context.router;
    history.push(uri);
  }

  componentDidMount() {
    const {route} = this.context.router;

    const {caseReports, applyFilter, fetchAllCaseReports, toggleSortColumn, location} = this.props;

    if (route.match.params.filter) {
      applyFilter(route.match.params.filter);
    }

    if (location.search) {
      const {sortBy, order} = parseQueryString(location.search.substring(1));
      if (sortBy && order) {
        toggleSortColumn({sortBy, sortDescending: order === 'desc'});
      }
    }

    if (!caseReports) {
      fetchAllCaseReports();
    }
  }

  getFilteredData() {
    const {currentFilter, caseReports} = this.props;
    const filterItem = QuickFilters.FiltersList[currentFilter];
    const filterFn = Array.isArray(filterItem) ? filterItem[1] : null;

    return filterFn ? caseReports.filter(filterFn) : caseReports;
  }

  applyFilter() {
    const {caseReports} = this.props;
    if (!caseReports) {
      return null;
    }

    this.setState({
      caseReports: this.getFilteredData()
    });
  }

  applySorting() {
    const {currentSortColumn, sortDescending, currentFilter} = this.props;
    const column = CaseReportColumns.Columns[currentSortColumn];
    const sortFn = Array.isArray(column) ? column[1] : null;
    const predicateFn = Array.isArray(column) ? column[2] : null;

    const caseReports = currentFilter === 'all' ? this.props.caseReports : this.getFilteredData();
    if (sortFn) {
      const data = caseReports.sort((a, b) => {
        const aIsSortable = predicateFn(a);
        const bIsSortable = predicateFn(b);

        if (aIsSortable && !bIsSortable) {
          return -1;
        }

        if (!aIsSortable && bIsSortable) {
          return 1;
        }

        return sortFn(a, b) * (sortDescending ? -1 : 1);
      });

      this.setState({
        caseReports: data
      });
    }
  }

  componentDidUpdate(prevProps) {
    const {currentFilter, currentSortColumn, caseReports, sortDescending, location} = this.props;
    const sortColumnChanged = currentSortColumn !== prevProps.currentSortColumn;
    const sortDirectionChanged = sortDescending !== prevProps.sortDescending;
    const currentFilterChanged = currentFilter !== prevProps.currentFilter;
    const locationChanged = location.pathname !== prevProps.location.pathname || location.search !== prevProps.location.search;

    if (locationChanged) {
      const {route} = this.context.router;

      if (route.match.params.filter !== currentFilter) {
        this.props.applyFilter(route.match.params.filter);
        return;
      }

      const {sortBy, order} = parseQueryString(location.search.substring(1));
      if (sortBy && order) {
        this.props.toggleSortColumn({sortBy});
      }
    }

    if (currentFilterChanged && caseReports) {
      this.applyFilter();

      return;
    }

    if (caseReports && (!prevProps.caseReports || sortColumnChanged || sortDirectionChanged)) {
      this.applySorting();
    }
  }

  setCurrentFilter(currentFilter) {
    this.navigateTo('/list/' + currentFilter);
  }

  onToggleSortColumn(column) {
    const {currentFilter, sortDescending} = this.props;

    this.navigateTo(`/list/${currentFilter}?sortBy=${column}&order=${sortDescending ? 'asc' : 'desc'}` );
  }

  openExporter() {

  }

  render() {
    const userName = 'DEV';
    const caseReports = this.state.caseReports;
    const isLoggedIn = false;
    const {currentFilter, currentSortColumn, sortDescending} = this.props;

    return <div>
      <header className="navigation-header">
        <figure className="logo">
          <svg xmlns="http://www.w3.org/2000/svg" width="700" height="400" viewBox="0 0 175 100">
            <rect width="175" height="100" fill="#fff" />
            <path d="M20,50h66m-33,-33v66" fill="none" stroke="#c00" strokeWidth="20" />
            <circle cx="132" cy="50" r="34" fill="#c00" />
            <circle cx="142" cy="50" r="28" fill="#fff" />
            <path d="M7,7H168V93H7z" fill="none" stroke="#c00" strokeWidth="3" />
          </svg>
        </figure>

        <nav>
          <a href="/">Project administration</a>
          <a href="/users">User management</a>
          <a href="/reporting">Volunteer reporting</a>
        </nav>

        <div className="login-status">
          <div className="logged-in">
            <p>
              Logged in as:
            </p>
            <p>{userName}</p>
          </div>
        </div>
      </header>

      {
        caseReports ? <div className="container">
            <h3>
              Case Reports
            </h3>

            {/*<cbs-case-report-export #exporter></cbs-case-report-export>*/}

            <div className="actions">
              <button onClick={this.openExporter()}>Export</button>
            </div>

            <QuickFilters currentFilter={currentFilter}
                          onClickFilter={this.setCurrentFilter.bind(this)} />

            <table className="table table-bordered table-striped">
              <CaseReportColumns currentSortColumn={currentSortColumn}
                                 sortDescending={sortDescending}
                                 onToggleSortColumn={this.onToggleSortColumn.bind(this)}
              />
              <CaseReportList caseReports={caseReports}/>
            </table>
          </div>: null
      }
    </div>;
  }
}

export default new Controller(VolunteerReporting);