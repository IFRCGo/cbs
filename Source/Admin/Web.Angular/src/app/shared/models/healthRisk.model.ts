export class HealthRisk {
    id: string;
    name: string;
    readableId: number;
    caseDefinition: string;
    note: string;
    communityCase: string;
    threshold?: number;
    keyMessage: string;
}