import { QueryRequest } from "../../../services/QueryRequest";

export class HealthRiskById extends QueryRequest {
    constructor(healthRiskId: string) {
        super('healthRiskById', 'Read.HealthRiskFeatures.Queries.HealthRiskById', 
        {
        'healthRiskId': healthRiskId
        });
    }
}