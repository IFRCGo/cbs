import { Command } from "../../services/Command";

export class DeleteHealthRisk extends Command {
    /*
    public Guid HealthRiskId { get; set; }   
    */
   healthRiskId: string;

   constructor() {
       super();
       this.type = 'CBS#Admin.HealthRisk-DeleteHealthRisk+Command@1'
   }
}