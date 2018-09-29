import { Component, OnInit, TemplateRef } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { HealthRisk } from '../HealthRisk';
import { DeleteHealthRisk } from '../DeleteHealthRisk';
import { AllHealthRisks } from '../AllHealthRisks';
import { CommandCoordinator } from '@dolittle/commands';
import { QueryCoordinator } from '@dolittle/queries';

@Component({
    selector: 'cbs-healthRisk-list',
    templateUrl: './healthRisk-list.component.html',
    styleUrls: ['./healthRisk-list.component.scss']
})

export class HealthRiskListComponent implements OnInit {
    risks: HealthRisk[];
    sortType: string;
    sortReverse: boolean = false;


    deleteHealthRiskCmd: DeleteHealthRisk = new DeleteHealthRisk();
    constructor(
        private queryCoordinator: QueryCoordinator,
        private commandCoordinator: CommandCoordinator,
        private toastr: ToastrService
    ) { }

    ngOnInit() {
        this.queryCoordinator.execute(new AllHealthRisks())
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
