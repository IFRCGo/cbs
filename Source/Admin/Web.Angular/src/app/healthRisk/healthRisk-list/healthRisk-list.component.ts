import { Component, OnInit, TemplateRef } from '@angular/core';
import { HealthRiskService } from '../../core/healthRisk.service';
import { HealthRisk } from '../../shared/models/healthRisk.model';
import { DeleteHealthRisk } from '../../domain/health-risk/DeleteHealthRisk';
import { CommandCoordinator } from '../../services/CommandCoordinator';
import { ToastrService } from 'ngx-toastr';
import { QueryCoordinator } from '../../services/QueryCoordinator';
import { AllHealthRisks } from '../../domain/health-risk/queries/AllHealthRisks';

@Component({
    selector: 'cbs-healthRisk-list',
    templateUrl: './healthRisk-list.component.html',
    styleUrls: ['./healthRisk-list.component.scss']
})

export class HealthRiskListComponent implements OnInit {
    risks: HealthRisk[];

    deleteHealthRiskCmd: DeleteHealthRisk = new DeleteHealthRisk();
    constructor(
        private queryCoordinator: QueryCoordinator<HealthRisk>,
        private commandCoordinator: CommandCoordinator,
        private toastr: ToastrService
    ) { }

    ngOnInit() {
        this.queryCoordinator.handle(new AllHealthRisks())
      .then(response => {
          if (response.success) {
            this.risks = response.items as HealthRisk[];
          } else {
            console.error(response);
          }
      })
      .catch(response => {
        console.error(response);
      });
    }
}
