export class HealthRisk {
    id: string;
    name: string;
    caseDefinition: string;
    threshold?: number;
    message: string;
    action: string;
}