const BaseService = require('../lib/BaseService.js');

module.exports = class Admin extends BaseService {
  getAllHealthRisks() {
    return this.post(`${this.options.baseUrl}/adminbackend/api/Dolittle/Queries`, {
      body: {
        nameOfQuery: 'AllHealthRisks',
        generatedFrom: 'Read.HealthRisks.AllProjects',
        parameters: {}
      }
    });
  }

  getAllProjects() {
    return this.post(`${this.options.baseUrl}/adminbackend/api/Dolittle/Queries`, {
      body: {
        nameOfQuery: 'AllProjects',
        generatedFrom: 'Read.HealthRisks.AllHealthRisks',
        parameters: {}
      }
    });
  }
};


