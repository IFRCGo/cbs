import { DataVerifier } from '../app/Management/DataVerifiers/DataVerifier';
import {Guid} from '@dolittle/core';

let dataCollectors : DataVerifier[]  = [];
for(let i = 0; i < 5; i++) {
    let dataCollector = new DataVerifier();
    dataCollector.id = Guid.create();
    dataCollector.fullName = `DataCollector ${i}`;
    dataCollectors.push(dataCollector);
}

export default dataCollectors;