import { Query } from '@dolittle/queries';
import {AllAlertRules} from '../Features/AlertRules/AllAlertRules';
import {AlertRule} from '../Features/AlertRules/AlertRule';
import {GetDataOwner} from '../Features/DataOwners/GetDataOwner';
import {DataOwner} from '../Features/DataOwners/DataOwner';
import { AlertOverview } from '../Features/Alerts/AlertOverview';
import { AllAlertOverviews } from '../Features/Alerts/AllAlertOverviews';

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
            let items = this.CreateAlertRuleTestData();            
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
        else if (query instanceof AllAlertOverviews){
            let items = this.CreateOverviewTestData();
            
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

    CreateOverviewTestData() {
        let overview1 = new AlertOverview();
        overview1.id = '2cd2dd84-de45-df46-34fg-der45fr5678s';
        overview1.alertNumber = 8;
        overview1.healthRiskNumber = 1;
        overview1.healthRiskName = 'Cholera';
        overview1.numberOfReports = 10;
        overview1.openedAt = new Date('December 17, 2018 03:24:00');
        overview1.status = 2;
        let overview2 = new AlertOverview();
        overview2.id = '23hd45h3-94j3-34k2-fo45-37dhru2304h2';
        overview2.alertNumber = 6;
        overview2.healthRiskNumber = 2;
        overview2.healthRiskName = 'Ebola';
        overview2.numberOfReports = 2;
        overview2.openedAt = new Date('December 17, 2018 04:25:00');
        overview2.status = 1;
        let overview3 = new AlertOverview();
        overview3.id = 'hd4u23j8-74hu-094j-fye4-238hfr5y1hs4';
        overview3.alertNumber = 4;
        overview3.healthRiskNumber = 3;
        overview3.healthRiskName = 'Measles';
        overview3.numberOfReports = 10;
        overview3.openedAt = new Date('January 01, 2019 18:00:00');
        overview3.status = 3;
        let overview4 = new AlertOverview();
        overview4.id = 'dg36he74-hs8a-345m-n3n6-kd08h37yh23j';
        overview4.alertNumber = 4;
        overview4.healthRiskNumber = 4;
        overview4.healthRiskName = 'YellowFever';
        overview4.numberOfReports = 2;
        overview4.openedAt = new Date('January 01, 2019 18:00:00');
        overview4.status = 2;
        let items = [overview1, overview2, overview3, overview4];
        return items;
    }

    CreateAlertRuleTestData() {
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
            rule1, rule2, rule3, rule4
        ];
        return items;
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