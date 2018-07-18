import { Command } from "../../services/Command";

export class CreateHealthRisk extends Command{
    /*    
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int ReadableId { get; set; }
    public string CaseDefinition { get; set; }
    //public string ConfirmedCase { get; set; }
    public string Note { get; set; }
    //public string SuspectedCase { get; set; }
    //public string ProbableCase { get; set; }
    public string CommunityCase { get; set; }
    public string KeyMessage { get; set; }
    */

    id: string;
    name: string;
    readableId: number;
    caseDefinition: string;
    note: string;
    communityCase: string;
    keyMessage: string;

    constructor() {
        super();
        this.type = 'CBS#Admin.HealthRisk-CreateHealthRisk+Command@1'
    }
}