import { Query } from '@dolittle/queries';
import {AllDataCollectors} from '../app/Management/DataCollectors/AllDataCollectors';
import {DataCollectorById} from '../app/Management/DataCollectors/DataCollectorById';
import {AllCaseReportsForListing} from '../app/Reporting/CaseReportsForListing/AllCaseReportsForListing';
import {CaseReportForListingById} from '../app/Reporting/CaseReportsForListing/CaseReportForListingById';
import {AllTrainingCaseReportsForListing} from '../app/Reporting/TrainingCaseReportsForListing/AllTrainingCaseReportsForListing';
import {TrainingCaseReportForListingById} from '../app/Reporting/TrainingCaseReportsForListing/TrainingCaseReportForListingById';
import dataCollectors from './dataCollectors';
import caseReports from './caseReports';
import dataVerifiers from './dataVerifiers';
import { AllDataVerifiers } from '../app/Management/DataVerifiers/AllDataVerifiers';
import { DataVerifierById } from '../app/Management/DataVerifiers/DataVerifierById';
import trainingCaseReports from './trainingCaseReports';

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
        if (query instanceof AllDataCollectors) {
            let items = dataCollectors;
            return new QueryResult(query, items);

        }
        else if(query instanceof DataCollectorById) {
            let items = dataCollectors.filter(_ => _.id === query.dataCollectorId);
            return new QueryResult(query, items);
        }
        else if (query instanceof AllCaseReportsForListing) {
            let items = caseReports;
            console.log(items);
            return new QueryResult(query, items);
        }

        else if(query instanceof CaseReportForListingById) {
            let items = caseReports.filter(_ => _.id === query.caseReportId);
            return new QueryResult(query, items);
        }
        else if (query instanceof AllTrainingCaseReportsForListing) {
            let items = trainingCaseReports;
            return new QueryResult(query, items);
        }
        else if(query instanceof TrainingCaseReportForListingById) {
            let items = trainingCaseReports.filter(_ => _.id === query.caseReportId);
            return new QueryResult(query, items);
        }
        else if (query instanceof AllDataVerifiers) {
            let items = dataVerifiers;
            return new QueryResult(query, items);
        }

        else if(query instanceof DataVerifierById) {
            let items = dataVerifiers.filter(_ => _.id === query.dataVerifierId);
            return new QueryResult(query, items);
        }
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