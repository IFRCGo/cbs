import { QueryRequest } from '../../../services/QueryRequest';

export class DataCollectorById extends QueryRequest {
    constructor(dataCollectorId: string) {
        super('dataCollectorById', 'Read.DataCollectors.Queries.DataCollectorById', {'dataCollectorId': dataCollectorId})
    }
}
