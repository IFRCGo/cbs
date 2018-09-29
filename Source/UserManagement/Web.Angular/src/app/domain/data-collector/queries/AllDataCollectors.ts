import { QueryRequest } from '../../../services/QueryRequest';

export class AllDataCollectors extends QueryRequest {
    constructor() {
        super('allDataCollectors', 'Read.DataCollectors.Queries.AllDataCollectors', {})
    }
}
