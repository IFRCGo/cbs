import {BaseController} from 'repertoire';

import CaseReportsService from '../services/CaseReports';
import Filters from '../lib/Filters';
import ReportColumns from '../lib/ReportColumns';

const ApiBaseUrl = process.env.API_URL;

export default class ReportingController extends BaseController {
  static get Direction() {
    return {
      DESC: 'desc',
      ASC: 'asc'
    }
  }

  get stateNamespace() {
    return 'app';
  }

  constructor(component) {
    super(component);

    this.reportsService = new CaseReportsService({
      baseUrl: ApiBaseUrl
    });

    this.state = {
      caseReports(state) {
        return state.caseReports || null;
      },

      currentFilter(state) {
        return state.currentFilter || 'all';
      },

      isSortedAscending(state) {
        return (state.isSortedAscending === undefined) || state.isSortedAscending; // true by default
      },

      currentSortColumn(state) {
        return state.currentSortColumn || 'date';
      }
    };

    this.connect();
  }

  fetchAllCaseReports({filter, sortBy, direction}) {
    return this.reportsService.fetchAllCaseReports()
      .then(response => {
        if (filter && filter !== 'all') {
          // ---------------------------------------------------------------\
          // If we have a filter, apply it on the data and also set the     |
          // "currentFilter" on the state                                   |
          // ---------------------------------------------------------------/
          return {
            currentFilter: filter,
            caseReports: Filters.applyFilter(response.items, filter)
          }
        }

        return {
          caseReports: response.items
        }
      })
      .then(responseData => {
        if (sortBy && direction) {
          // ---------------------------------------------------------------\
          // If we have a sort column and direction, apply the sorting on   |
          // the existing data and also set the "currentSortColumn" and     |
          // "sortDescending" properties on the state                       |
          // ---------------------------------------------------------------/
          const isSortedAscending = direction === ReportingController.Direction.ASC;
          Object.assign(responseData, {
            currentSortColumn: sortBy,
            isSortedAscending
          });

          responseData.caseReports = ReportColumns.applySorting(responseData.caseReports, sortBy, isSortedAscending);
        }

        return responseData;
      })
  }
}
