import {BaseController} from 'repertoire';

import AlertsService from './AlertsService';

const ApiBaseUrl = process.env.API_URL;

export default class AlertsController extends BaseController {
  get stateNamespace() {
    return 'app';
  }

  constructor(component) {
    super(component);

    this.reportsService = new AlertsService({
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
