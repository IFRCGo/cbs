import { DataVerifier } from '../app/Management/DataVerifiers/DataVerifier';
import {Guid} from '@dolittle/core';

const dataCollectors: DataVerifier[]  = [];
for (let i = 0; i < 10; i++) {
    const dataCollector = new DataVerifier();
    dataCollector.id = Guid.create();
    dataCollector.fullName = `DataVerifier ${i}`;
    dataCollectors.push(dataCollector);
}

export default dataCollectors

