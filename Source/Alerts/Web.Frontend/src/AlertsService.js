import {BaseApi} from '@ifrc-cbs/common-react-ui';

export default class Alerts extends BaseApi {
  fetchAllProjects(params) {
    return this.fetch('/api/projects', {
      parameters: {}
    });
  }
};



