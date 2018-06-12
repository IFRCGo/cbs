import { QueryRequest } from "../../../services/QueryRequest";

export class AllHealthRisks extends QueryRequest {
    constructor() {
        super('allHealthRisks', 'Read.HealthRiskFeatures.Queries.AllHealthRisks',{});
    }
}