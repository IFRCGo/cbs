import { Component, OnInit, TemplateRef } from '@angular/core';
import { HealthRiskService } from '../../core/healthRisk.service';
import { HealthRisk } from '../../shared/models/healthRisk.model';
import { DeleteHealthRisk } from '../../domain/health-risk/DeleteHealthRisk';
import { CommandCoordinator } from '../../services/CommandCoordinator';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'cbs-healthRisk-list',
    templateUrl: './healthRisk-list.component.html',
    styleUrls: ['./healthRisk-list.component.scss']
})

export class HealthRiskListComponent implements OnInit {
    risks: HealthRisk[];

    deleteHealthRiskCmd: DeleteHealthRisk = new DeleteHealthRisk();
    constructor(
        private healthRiskService: HealthRiskService,
        private commandCoordinator: CommandCoordinator,
        private toastr: ToastrService
    ) { }

    ngOnInit() {
        this.healthRiskService.getHealthRisks()
            .subscribe((result) => this.risks = result,
            (error) => { console.log(error); });
    }
}
