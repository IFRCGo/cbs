import { DataCollector } from '../app/Management/DataCollectors/DataCollector';
import {Guid} from '@dolittle/core';
/**
 * @type {DataCollector[]}
 */
let dataCollectors = [];
for(let i = 0; i < 5; i++) {
    let dataCollector = new DataCollector();
    dataCollector.id = Guid.create();
    dataCollector.fullName = `DataCollector ${i}`;
    dataCollector.displayName = `DataCollector ${i}`;
    dataCollector.yearOfBirth = 1980;
    dataCollector.sex = {value: 1};
    dataCollector.preferredLanguage = {value: 1};
    dataCollector.location = {latitude: 1, longitude: 1};
    dataCollector.region = "Default Region";
    dataCollector.district = "Default District";
    dataCollector.village = 'Default Village';
    dataCollector.registeredAt = new Date();
    
    dataCollectors.push(dataCollector);
}

export default dataCollectors;