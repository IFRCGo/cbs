import { CaseReportForListing} from '../app/Reporting/CaseReportsForListing/CaseReportForListing';
import {Guid} from '@dolittle/core';
import dataCollectors from './dataCollectors';

let caseReports : CaseReportForListing[] = [];
for(let i = 0; i < 5; i++) {
    let dataCollector = dataCollectors[i];
    if (!dataCollector.inTraining) {
        let caseReport = new CaseReportForListing();
        caseReport.id = Guid.create();
        caseReport.message = '1#1#1';
        caseReport.origin = '123456789';
        caseReport.status = 0;
        caseReport.dataCollectorDisplayName = dataCollector.displayName;
        caseReport.dataCollectorDistrict = dataCollector.district;
        caseReport.dataCollectorRegion = dataCollector.region;
        caseReport.dataCollectorVillage = dataCollector.village;
        caseReport.healthRisk = 'Health Risk';
        caseReport.healthRiskId = '1';
        caseReport.numberOfFemalesAged5AndOlder = 0;
        caseReport.numberOfFemalesUnder5 = 0;
        caseReport.numberOfMalesAged5AndOlder = 0;
        caseReport.numberOfMalesUnder5 = 1;
        caseReport.parsingErrorMessage = [];
        caseReport.timestamp = new Date();
        caseReport.location = dataCollector.location;
        caseReport.dataCollectorId = dataCollector.id;
        caseReports.push(caseReport);
    }
}

//for status = 1
for(let i = 5; i < 10; i++) {
    let dataCollector = dataCollectors[i];
    if (!dataCollector.inTraining) {
        let caseReport = new CaseReportForListing();
        caseReport.id = Guid.create();
        caseReport.message = 'Some bad message';
        caseReport.origin = '123456789';
        caseReport.status = 1;
        caseReport.dataCollectorDisplayName = dataCollector.displayName;
        caseReport.dataCollectorDistrict = dataCollector.district;
        caseReport.dataCollectorRegion = dataCollector.region;
        caseReport.dataCollectorVillage = dataCollector.village;
        caseReport.healthRisk =  null;
        caseReport.healthRiskId = null;
        caseReport.numberOfFemalesAged5AndOlder = 0;
        caseReport.numberOfFemalesUnder5 = 0;
        caseReport.numberOfMalesAged5AndOlder = 6;
        caseReport.numberOfMalesUnder5 = 0;
        caseReport.parsingErrorMessage = ['Incorrect format something'];
        caseReport.timestamp = new Date();
        caseReport.location = dataCollector.location;
        caseReport.dataCollectorId = dataCollector.id;
        caseReports.push(caseReport);
    }
}

//for status = 2
for (let i = 0; i < 5; i++) {
    let caseReport = new CaseReportForListing();
    caseReport.id = Guid.create();
    caseReport.message = '1#1#1';
    caseReport.origin = '123456789';
    caseReport.status = 2;
    caseReport.healthRisk = 'Health Risk';
    caseReport.healthRiskId = '1';
    caseReport.numberOfFemalesAged5AndOlder = 0;
    caseReport.numberOfFemalesUnder5 = 0;
    caseReport.numberOfMalesAged5AndOlder = 0;
    caseReport.numberOfMalesUnder5 = 1;
    caseReport.parsingErrorMessage = [];
    caseReport.timestamp = new Date();
    caseReports.push(caseReport);
}
//for status = 3
for (let i = 0; i < 5; i++) {
    let caseReport = new CaseReportForListing();
    caseReport.id = Guid.create();
    caseReport.message = 'Some bad message';
    caseReport.origin = '123456789';
    caseReport.status = 3;
    caseReport.healthRisk =  null;
    caseReport.healthRiskId = null;
    caseReport.numberOfFemalesAged5AndOlder = 0;
    caseReport.numberOfFemalesUnder5 = 0;
    caseReport.numberOfMalesAged5AndOlder = 6;
    caseReport.numberOfMalesUnder5 = 0;
    caseReport.parsingErrorMessage = ['Incorrect format something'];
    caseReport.timestamp = new Date();
    caseReports.push(caseReport);
}

export default caseReports;
