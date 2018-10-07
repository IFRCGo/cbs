import {BaseController} from 'repertoire';

import QueriesApi from './services/Queries.js';

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

  constructor(component) {
    super(component);

    this.state = {
      caseReports(state) {
        return state.caseReports || [];
      }
    };

    this.connect();
  }
}