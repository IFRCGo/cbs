import { Component, OnInit } from '@angular/core';
import { HealthRiskService } from '../../core/healthRisk.service';
import { Router } from '@angular/router';
import { ApiService } from '../../core/api.service';
import { HealthRisk } from '../../shared/models/index';

@Component({
    selector: 'add-edit-healthRisk',
    templateUrl: './add-edit-healthRisk.component.html',
    styleUrls: ['./add-edit-healthRisk.component.scss']
})

export class AddEditHealthRiskComponent implements OnInit {
    risk: HealthRisk;
    isAdd: boolean;

    constructor(
        private healthRiskService: HealthRiskService,
        private router: Router
    ) { }

    ngOnInit() {
        this.risk = new HealthRisk();

       var pathSections = this.router.url.split("/");

       if (pathSections.indexOf('update') > -1)
       {
           this.isAdd = false;
           this.healthRiskService.getHealthRisk(pathSections[2])
                .subscribe((result) => this.risk = result,
                    (error) => { console.log(error); });
       }
       else
       {
           this.isAdd = true;
       }
    }

    async addEditHealthRisk() {
        if(this.risk !== new HealthRisk())
        {
            if(this.isAdd){
                this.addHealthRisk();
            }
            else
            {
                this.editHealthRisk();
            }
        }
    }

    addHealthRisk(){
        this.healthRiskService.saveHealthRisk(this.risk)
            .subscribe(() => //go to healthrisk page
                (error) => {console.log(error); });
    };

    editHealthRisk(){
        this.healthRiskService.updateHealthRisk(this.risk)
        .subscribe(() => //go to healthrisk page
            (error) => {console.log(error); });
    };
}
