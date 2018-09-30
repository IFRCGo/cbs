import {BaseController} from 'repertoire';

import QueriesApi from '../services/Queries.js';

export default class VolunteerReportingController extends BaseController {
  get stateNamespace() {
    return 'app';
  }

  fetchAllCaseReports() {
    return QueriesApi.fetchAllCaseReports()
      .then(response => {
        return {
          caseReports: response.items
        }
      });
  }

  applyFilter(currentFilter) {
    return {
      currentFilter
    }
  }

  toggleSortColumn(params) {
    const {sortBy, sortDescending} = params;

    return {
      currentSortColumn: sortBy,
      sortDescending: sortDescending === undefined ? !this.state.sortDescending : sortDescending
    }
  }

  constructor(component) {
    super(component);

    this.state = {
      caseReports(state) {
        return state.caseReports || null;
      },

      currentFilter(state) {
        return state.currentFilter || 'all';
      },

      sortDescending(state) {
        return (state.sortDescending === undefined) || state.sortDescending // true by default;
      },

      currentSortColumn(state) {
        return state.currentSortColumn || 'date';
      }
    };

    this.connect();
  }
}