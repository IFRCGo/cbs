import { Query } from '@dolittle/queries';
import {AllAlertRules} from '../Features/AlertRules/AllAlertRules';
import {AlertRule} from '../Features/AlertRules/AlertRule';
import {GetDataOwner} from '../Features/DataOwners/GetDataOwner';
import {DataOwner} from '../Features/DataOwners/DataOwner';

// import {AllDataCollectors} from '../src/app/Management/DataCollectors/AllDataCollectors';
// import {DataCollectorById} from '../src/app/Management/DataCollectors/DataCollectorById';
// import dataCollectors from './dataCollectors';

export class MockQueryCoordinator {
    // dataCollectors = [];
    // caseReports = [];
     /**
     * Execute a query
     * @param {Query} query
     * @returns {Promise<QueryResult>}
     */
    execute(query) {
        return new Promise((resolve, reject) => {
            try{
                resolve(this.handleQuery(query));
            }
            catch(e){   
                console.error("Error handling mock query", query, e);             
                reject(e);
            }            
        });
    }
    handleQuery(query) {
        if(query instanceof AllAlertRules){
            let rule1 = new AlertRule();
            rule1.id = 'd44ee99e-fed9-4ba0-a270-b072464fa88c';
            rule1.alertRuleName = 'Cholera';
            rule1.healthRiskId = 1;
            rule1.numberOfCasesThreshold = 4;
            rule1.distanceBetweenCasesInMeters = 1000;
            rule1.thresholdTimeframeInHours = 24;
            let rule2 = new AlertRule();
            rule2.id = 'c55ff00f-fed9-4ba0-a270-c182464fc99d';
            rule2.alertRuleName = 'Ebola';
            rule2.healthRiskId = 2;
            rule2.numberOfCasesThreshold = 1;
            rule2.distanceBetweenCasesInMeters = 0;
            rule2.thresholdTimeframeInHours = 24;
            let rule3 = new AlertRule();
            rule3.id = 'c55ff00f-fed9-4ba0-a380-c1824574fc99d';
            rule3.alertRuleName = 'Yellow Fever';
            rule3.healthRiskId = 3;
            rule3.numberOfCasesThreshold = 1;
            rule3.distanceBetweenCasesInMeters = 0;
            rule3.thresholdTimeframeInHours = 24;
            let rule4 = new AlertRule();
            rule4.id = 'd66aa03f-fce9-34fr-fgr6-se4r56td3456';
            rule4.alertRuleName = 'Measles';
            rule4.healthRiskId = 4;
            rule4.numberOfCasesThreshold = 1;
            rule4.distanceBetweenCasesInMeters = 0;
            rule4.thresholdTimeframeInHours = 24;
            let items = [
                rule1,rule2,rule3,rule4                
            ];            
            return new QueryResult(query, items);
            
        }
        else if(query instanceof GetDataOwner){
           let dataOwner = new DataOwner();
           dataOwner.id = '2db26d84-5be5-4f31-aab8-dc90181f79c8';
           dataOwner.name = 'Data Owner';
           dataOwner.email = 'test@test.com';
           let items = [
               dataOwner
           ];
           return new QueryResult(query, items); 
        }
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