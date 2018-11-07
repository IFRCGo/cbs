/*---------------------------------------------------------------------------------------------
 *  This file is an automatically generated ReadModel Proxy
 *  
 *--------------------------------------------------------------------------------------------*/
import { ReadModel } from  '@dolittle/readModels';

export class CaseReportForListing extends ReadModel
{
    constructor() {
        super();
        this.artifact = {
           id: 'c167ac2d-4a00-4171-9d66-caf0b704f13c',
           generation: '1'
        };
        this.id = '00000000-0000-0000-0000-000000000000';
        this.extraElements = [];
        this.status = {};
        this.dataCollectorId = '00000000-0000-0000-0000-000000000000';
        this.dataCollectorDisplayName = '';
        this.dataCollectorRegion = '';
        this.dataCollectorDistrict = '';
        this.dataCollectorVillage = '';
        this.healthRiskId = '00000000-0000-0000-0000-000000000000';
        this.healthRisk = '';
        this.message = '';
        this.numberOfMalesUnder5 = 0;
        this.numberOfMalesAged5AndOlder = 0;
        this.numberOfFemalesUnder5 = 0;
        this.numberOfFemalesAged5AndOlder = 0;
        this.timestamp = 1/1/01 12:00:00 AM +00:00;
        this.location = {};
        this.origin = '';
        this.parsingErrorMessage = [];
    }
}