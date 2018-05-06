import { Command } from "../../services/Command";

export class AddThresholdToHealthRisk extends Command {
    /*
    public Guid HealthRiskId { get; set; }  
    public int Threshold { get; set; }
    */

    healthRiskId: string;
    threshold: number;

    constructor() {
        super();
        this.type = 'CBS#Admin.HealthRisk-AddThresholdToHealthRisk+Command|Domain';
    }
}