import { DataCollector } from '../app/Management/DataCollectors/DataCollector';
import {Guid} from '@dolittle/core';

import dataVerifiers from './dataVerifiers';

let dataCollectors : DataCollector[] = [];
for(let i = 0; i < 5; i++) {
    let dataCollector = new DataCollector();
    dataCollector.id = Guid.create();
    dataCollector.fullName = `DataCollector ${i}`;
    dataCollector.displayName = `DataCollector ${i}`;
    dataCollector.yearOfBirth = 1980;
    dataCollector.sex = 0;
    dataCollector.preferredLanguage = 0;
    dataCollector.location = {latitude: 1, longitude: 1};
    dataCollector.region = "Default Region";
    dataCollector.district = "Default District";
    dataCollector.village = 'Default Village';
    dataCollector.registeredAt = new Date();
    dataCollector.inTraining = i % 2 === 0;
    dataCollector.phoneNumbers = ["123456789"];
    dataCollector.dataVerifier = dataVerifiers[i].id;
    dataCollectors.push(dataCollector);
}

export default dataCollectors;