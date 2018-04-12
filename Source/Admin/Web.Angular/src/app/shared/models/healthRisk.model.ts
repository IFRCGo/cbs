export class HealthRisk {
    id: string;
    name: string;
    readableId: string;
    caseDefinition: string;
    note: string;
    communityCase: string;
    threshold?: number;
    keyMessage: string;
}