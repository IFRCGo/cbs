import { Query } from '@dolittle/queries';
// import {AllDataCollectors} from '../src/app/Management/DataCollectors/AllDataCollectors';
// import {DataCollectorById} from '../src/app/Management/DataCollectors/DataCollectorById';
// import dataCollectors from './dataCollectors';

export class MockQueryCoordinator {
    dataCollectors = [];
    caseReports = [];
     /**
     * Execute a query
     * @param {Query} query
     * @returns {Promise<QueryResult>}
     */
    execute(query) {
        return new Promise((resolve, reject) => {
            resolve(this.handleQuery(query));
        });
    }
    handleQuery(query) {
        // if (query instanceof AllDataCollectors) {
        //     let items = dataCollectors;
        //     return new QueryResult(query, items);

        // }
        // else if(query instanceof DataCollectorById) {
        //     let items = dataCollectors.filter(_ => _.id === query.dataCollectorId);
        //     return new QueryResult(query, items);
        // }
    }
}
export class QueryResult {
    queryName = '';
    totalItems = 0;
    items = [];
    exception = null;
    securityMessages = [];
    brokenRules = [];
    passedSecurity = true;
    success = true;
    /**
     *Creates an instance of QueryResult.
     * @param {Query} query
     * @memberof QueryResult
     */
    constructor(query, items) {
        this.queryName = query.nameOfQuery;
        this.items = items;
        this.totalItems = items.length;
    }
}