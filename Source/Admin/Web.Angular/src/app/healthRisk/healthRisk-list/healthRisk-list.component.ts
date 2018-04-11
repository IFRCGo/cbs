import { Component, OnInit, TemplateRef } from '@angular/core';
import { HealthRiskService } from '../../core/healthRisk.service';
import { HealthRisk } from '../../shared/models/healthRisk.model';

@Component({
    selector: 'cbs-healthRisk-list',
    templateUrl: './healthRisk-list.component.html',
    styleUrls: ['./healthRisk-list.component.scss']
})

export class HealthRiskListComponent implements OnInit {
    risks: HealthRisk[];

    constructor(
        private healthRiskService: HealthRiskService
    ) { }

    ngOnInit() {
        this.healthRiskService.getHealthRisks()
            .subscribe((result) => this.risks = result,
            (error) => { console.log(error); });
    }

    async deleteHealthRisk(risk){
        this.healthRiskService.removeHealthRisk(risk.id)
            .subscribe(() => console.log("Success"), 
            (error) => {console.log(error);})
    }
}
