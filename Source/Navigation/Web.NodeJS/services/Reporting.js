const BaseService = require('../lib/BaseService.js');

module.exports = class Reporting extends BaseService {
  getCaseReports() {
    return this.post(`${this.options.baseUrl}/volunteerreportingbackend/api/Dolittle/Queries`, {
      body: {
        nameOfQuery: 'allCaseReportsForListing',
        generatedFrom: 'Read.CaseReportsForListing.AllCaseReportsForListing',
        parameters: {
          pageNumber: 0,
          pageSize: 50,
          sortAscending: true
        }
      }
    });
  }
};


