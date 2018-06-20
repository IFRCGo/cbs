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
    sortType: string;
    private sortReverse: boolean = false;


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
              this.sortRisks('id')
          } else {
            console.error(response);
          }
      })
      .catch(response => {
        console.error(response);
      });
    }

    sortRisks(property) {
        this.sortType = property;
        this.sortReverse = !this.sortReverse;
        this.risks.sort(this.dynamicSort(property));
    }

    dynamicSort(property) {
        let sortRisk = -1;
        if (this.sortReverse)
            sortRisk = 1;
        return function (a, b) {
            let result = (a[property] < b[property]) ? -1 : (a[property] > b[property]) ? 1 : 0;

            return result * sortRisk;
        }
    }

}
