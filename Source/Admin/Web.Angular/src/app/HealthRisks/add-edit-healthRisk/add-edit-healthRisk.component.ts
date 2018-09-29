import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CommandCoordinator } from '@dolittle/commands';
import { QueryCoordinator } from '@dolittle/queries';
import { HealthRisk } from '../HealthRisk';
import { CreateHealthRisk } from '../CreateHealthRisk';
import { Guid } from '@dolittle/core';
import { ModifyHealthRisk } from '../ModifyHealthRisk';
import { AddThresholdToHealthRisk } from '../AddThresholdToHealthRisk';
import { ToastrService } from 'ngx-toastr';
import { HealthRiskById } from '../HealthRiskById';

@Component({
    selector: 'add-edit-healthRisk',
    templateUrl: './add-edit-healthRisk.component.html',
    styleUrls: ['./add-edit-healthRisk.component.scss']
})

export class AddEditHealthRiskComponent implements OnInit {
    risk: HealthRisk;

    createCmd: CreateHealthRisk = new CreateHealthRisk();
    modifyCmd: ModifyHealthRisk = new ModifyHealthRisk();
    addThresholdCmd: AddThresholdToHealthRisk = new AddThresholdToHealthRisk();

    isAdd: boolean;

    constructor(
        private queryCoordinator: QueryCoordinator<HealthRisk>,
        private router: Router,
        private commandCoordinator: CommandCoordinator,
        private toastr: ToastrService
    ) { }

    ngOnInit() {
        this.risk = new HealthRisk();

       var pathSections = this.router.url.split("/");

       if (pathSections.indexOf('update') > -1)
       {
           this.isAdd = false;
           const id = pathSections[2];
           var query = new HealthRiskById();
           query.healthRiskId = id;
           
           this.queryCoordinator.handle(query)
           .then(response => {
               if (response.success) {
                 this.risk = response.items[0];
               } else {
                 console.error(response);
               }
           })
           .catch(response => {
             console.error(response);
           });           
           
       }
       else
       {
           this.isAdd = true;
       }
    }

    submit() {
        if (this.isAdd) {
            this.createHealthRisk();
        }
        else {
            this.modifyHealthRisk();
        }
    }

    createHealthRisk() {
        this.risk.id = Guid.create();
        this.createCmd.id = this.risk.id;
        this.createCmd.caseDefinition = this.risk.caseDefinition;
        this.createCmd.readableId = this.risk.readableId;
        this.createCmd.name = this.risk.name;
        this.createCmd.communityCase = this.risk.communityCase || "";
        this.createCmd.keyMessage = this.risk.keyMessage;
        this.createCmd.note = this.risk.note || "";

        console.log(this.createCmd);
        this.commandCoordinator.handle(this.createCmd)
            .then(response => {
                console.log(response);
                if (response.success)  {
                    this.checkThreshold();
                    this.toastr.success('Successfully create a new health risk!');
                    
                    this.router.navigate(['healthrisk']);
                } else {
                    if (!response.passedSecurity) { // Security error
                        this.toastr.error('Could not create a new health risk because of security issues');
                    } else {
                        const errors = response.allValidationMessages.join('\n');
                        this.toastr.error('Could not create a new health risk:\n' + errors);
                    }
                }
            })
            .catch(response => {
                console.log(response);

                if (!response.passedSecurity) { // Security error
                    this.toastr.error('Could not create a new health risk because of security issues');
                } else {
                    const errors = response.allValidationMessages.join('\n');
                    this.toastr.error('Could not create a new health risk:\n' + errors);
                }
            });

    }
    modifyHealthRisk() {
        this.modifyCmd.id = this.risk.id;
        this.modifyCmd.caseDefinition = this.risk.caseDefinition;
        this.modifyCmd.readableId = this.risk.readableId;
        this.modifyCmd.name = this.risk.name;
        this.modifyCmd.communityCase = this.risk.communityCase || "";
        this.modifyCmd.keyMessage = this.risk.keyMessage;
        this.modifyCmd.note = this.risk.note || "";

        console.log(this.modifyCmd);

        this.commandCoordinator.handle(this.modifyCmd)
        .then(response => {
            console.log(response);
            if (response.success)  {
                this.checkThreshold();
                this.toastr.success('Successfully modified new health risk!');
                this.router.navigate(['healthrisk']);
                
            } else {
                if (!response.passedSecurity) { // Security error
                    this.toastr.error('Could not modify health risk because of security issues');
                } else {
                    const errors = response.allValidationMessages.join('\n');
                    this.toastr.error('Could not modify health risk:\n' + errors);
                }
            }
        })
        .catch(response => {
            console.log(response);

            if (!response.passedSecurity) { // Security error
                this.toastr.error('Could not modify health risk because of security issues');
            } else {
                const errors = response.allValidationMessages.join('\n');
                this.toastr.error('Could not modify health risk:\n' + errors);
            }
        });
    }
    checkThreshold() {
        if (this.risk.threshold != null) {
            this.addThresholdCmd.healthRiskId = this.risk.id;
            this.addThresholdCmd.threshold = this.risk.threshold.valueOf();

            console.log("Threshold cmd");
            
            console.log(this.addThresholdCmd);
            this.commandCoordinator.handle(this.addThresholdCmd)
                .then(response => {
                    console.log(response);
                    if (response.success)  {
                        this.toastr.success('Successfully added threshold!');
                        this.router.navigate(['healthrisk']);
                    } else {
                        if (!response.passedSecurity) { // Security error
                            this.toastr.error('Could not add threshold because of security issues');
                        } else {
                            const errors = response.allValidationMessages.join('\n');
                            this.toastr.error('Could not add threshold:\n' + errors);
                        }
                    }
                })
                .catch(response => {
                    console.log(response);

                    if (!response.passedSecurity) { // Security error
                        this.toastr.error('Could not add threshold because of security issues');
                    } else {
                        const errors = response.allValidationMessages.join('\n');
                        this.toastr.error('Could not add threshold:\n' + errors);
                    }
                });
        } 
    }
}
