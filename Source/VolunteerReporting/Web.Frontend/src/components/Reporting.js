import React from 'react';
import Helmet from 'react-helmet';
import PropTypes from 'prop-types';
import {utils} from '@ifrc-cbs/common-react-ui';
import ReportingController from '../controllers/Reporting';
import QuickFilters from './containers/QuickFilters';
import DataTable from './containers/DataTable';

const {parseQueryString} = utils;

// import './css/Home.css';
class Reporting extends React.Component {
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
    };
  }

  static parseLocationString(location = {}) {
    const params = {};

    if (location.search) {
      const {sortBy, order} = parseQueryString(location.search.substring(1));

      if (sortBy && order) {
        params.sortBy = sortBy;
        params.direction = order;
      }
    }

    return params;
  }

  getReportsWhenLocationChanged(params, location = {}) {
    Object.assign(params, Reporting.parseLocationString(location));

    this.props.fetchAllCaseReports(params);
  }

  componentDidMount() {
    const {route} = this.context.router;

    const params = {
      filter: route.match.params.filter
    };

    this.getReportsWhenLocationChanged(params, this.props.location);
  }

  componentDidUpdate(prevProps) {
    const {currentFilter, caseReports, location} = this.props;
    const locationChanged = location.pathname !== prevProps.location.pathname || location.search !== prevProps.location.search;

    if (locationChanged) {
      const {route} = this.context.router;
      const params = {};
      if (route.match.params.filter !== currentFilter) {
        params.filter = route.match.params.filter;
      }

      this.getReportsWhenLocationChanged(params, location);
    } else if (caseReports !== this.state.caseReports) {
      this.setState({
        caseReports
      });
    }
  }

  navigateTo(uri) {
    const {history} = this.context.router;
    history.push(uri);
  }

  openExporter() {

  }

  render() {
    const title = 'Reporting';
    const description = '';
    const {caseReports} = this.state;
    const {currentSortColumn, isSortedAscending, currentFilter} = this.props;

    if (!caseReports) {
      return null;
    }

    return (
      <React.Fragment>
        <Helmet>
          <title>{title}</title>
          <meta property="og:title" content={title}/>
          <meta property="og:description" content={description}/>
          <meta name="description" content={description}/>
        </Helmet>
        <article id="introduction">
          <section className="container">
            <h3>Case Reports</h3>

            {/*<cbs-case-report-export #exporter></cbs-case-report-export>*/}

            <div className="actions">
              <button onClick={this.openExporter()}>Export</button>
            </div>

            <QuickFilters currentFilter={currentFilter} />

            <DataTable
              currentSortColumn={currentSortColumn}
              isSortedAscending={isSortedAscending}
              currentFilter={currentFilter}
              data={caseReports}
            />

          </section>
        </article>
      </React.Fragment>
    );
  }
}

export default new ReportingController(Reporting);
