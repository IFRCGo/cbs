import {BaseController} from 'repertoire';

import AdminService from './AnalyticsService';

const ApiBaseUrl = process.env.API_URL;

export default class AnalyticsController extends BaseController {
  get stateNamespace() {
    return 'app';
  }

  constructor(component) {
    super(component);

    this.reportsService = new AdminService({
      baseUrl: ApiBaseUrl
    });

    this.state = {
      projects(state) {
        return state.projects || [];
      }
    };

    this.connect();
  }

}
