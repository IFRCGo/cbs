import { CaseReportForListing} from '../app/Reporting/CaseReportsForListing/CaseReportForListing';
import {Guid} from '@dolittle/core';
import dataCollectors from './dataCollectors';
/**
 * @type {CaseReportForListing[]}
 */
let caseReports = [];
for(let i = 0; i < 5; i++) {
    let dataCollector = dataCollectors[i];
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

// Data error

for(let i = 0; i < 5; i++) {
    let dataCollector = dataCollectors[i];
    let caseReport = new CaseReportForListing();
    caseReport.id = Guid.create();
    caseReport.message = '1#1#1';
    caseReport.origin = '123456789';
    caseReport.status = 1 ;
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

let dataCollector = dataCollectors[0];
    let caseReport = new CaseReportForListing();
    caseReport.id = Guid.create();
    caseReport.message = '1#1#1';
    caseReport.origin = '123456789';
    caseReport.status = 1 ;
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
    caseReport.timestamp = new Date('2011-02-01');
    caseReport.location = dataCollector.location;
    caseReport.dataCollectorId = dataCollector.id;


    let dataCollector1 = dataCollectors[1];
    let caseReport1 = new CaseReportForListing();
    caseReport1.id = Guid.create();
    caseReport1.message = '1#1#1';
    caseReport1.origin = '123456789';
    caseReport1.status = 1 ;
    caseReport1.dataCollectorDisplayName = dataCollector1.displayName;
    caseReport1.dataCollectorDistrict = dataCollector1.district;
    caseReport1.dataCollectorRegion = dataCollector1.region;
    caseReport1.dataCollectorVillage = dataCollector1.village;
    caseReport1.healthRisk = 'Health Risk';
    caseReport1.healthRiskId = '1';
    caseReport1.numberOfFemalesAged5AndOlder = 0;
    caseReport1.numberOfFemalesUnder5 = 0;
    caseReport1.numberOfMalesAged5AndOlder = 0;
    caseReport1.numberOfMalesUnder5 = 1;
    caseReport1.parsingErrorMessage = [];
    caseReport1.timestamp = new Date('2010-01-01');
    caseReport1.location = dataCollector1.location;
    caseReport1.dataCollectorId = dataCollector1.id;

caseReports.push(caseReport) ;
caseReports.push(caseReport1);

export default caseReports;