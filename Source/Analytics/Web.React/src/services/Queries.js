import BaseApi from './baseapi.js';

const environment = {
  api: 'http://localhost:5001'
};

const API_URL = environment.api + '/api/Dolittle/Queries';


export default class QueriesApi extends BaseApi {
  static performQuery(data) {
    return BaseApi.fetch(API_URL, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(data)
    });
  }

  static fetchAllCaseReports() {
    return QueriesApi.performQuery({
      nameOfQuery: 'allCaseReportsForListing',
      generatedFrom: 'Read.CaseReportsForListing.Queries.AllCaseReportsForListing',
      parameters: {}
    });
  }

};



