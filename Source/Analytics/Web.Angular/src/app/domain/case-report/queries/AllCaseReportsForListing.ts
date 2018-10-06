import { QueryRequest } from '../../../services/QueryRequest';

export class AllCaseReportsForListing extends QueryRequest {
    constructor() {
        super('allCaseReportsForListing', 'Read.CaseReportsForListing.Queries.AllCaseReportsForListing', {});
    }
}