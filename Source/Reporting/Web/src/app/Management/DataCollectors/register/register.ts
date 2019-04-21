import { Component, OnInit} from '@angular/core';
import { Router } from '@angular/router';

import { CommandCoordinator } from '@dolittle/commands';
import { Guid } from '@dolittle/core';
import { Language } from '../../Language';
import { Sex } from '../../Sex';
import { ToastrService } from 'ngx-toastr';
import { ChangeVillage } from '../EditInformation/ChangeVillage';
import { RegisterDataCollector } from '../Registration/RegisterDataCollector';
import { AppInsightsService } from '../../../services/app-insights-service';

@Component({
    templateUrl: './register.html',
    styleUrls: ['./register.scss']
})
export class Register {
    locationSelected = false;
    defaultLat: number = 9.216515;
    defaultLng: number = 45.523637;

    phoneNumberString = '';
    command: RegisterDataCollector = new RegisterDataCollector();
    changeVillageCommand: ChangeVillage = new ChangeVillage();

    languageOptions = [{desc: Language[Language.English], id: Language.English},
                        {desc: Language[Language.French], id: Language.French}];
    sexOptions = [{ desc: Sex[Sex.Male], id: Sex.Male },
                 { desc: Sex[Sex.Female], id: Sex.Female }];

    constructor(
        private router: Router,
        private commandCoordinator: CommandCoordinator,
        private toastr: ToastrService,
        private appInsightsService: AppInsightsService
    ) {
        toastr.toastrConfig.positionClass = 'toast-top-center';
    }

    ngOnInit() {
        this.appInsightsService.trackPageView('RegisterDataCollector');
        this.command.gpsLocation.latitude = this.defaultLat;
        this.command.gpsLocation.longitude = this.defaultLng;
    }

    onLocationSelected(event){
        this.locationSelected = true;
        this.command.gpsLocation.latitude = event.coords.lat;
        this.command.gpsLocation.longitude = event.coords.lng;
    }
    submit() {
        this.command.dataCollectorId = Guid.create();
        this.command.phoneNumbers = this.phoneNumberString.split(',').map(number => number.trim());
        this.command.dataVerifierId = Guid.create();
        this.commandCoordinator.handle(this.command)
            .then(response => {
                if (response.success)  {
                    this.toastr.success('Successfully registered a new data collector!');
                    this.handleChangeVillage();
                    this.router.navigate(['/datacollectors']);
                } else {
                    if (!response.passedSecurity) { // Security error
                        this.toastr.error('Could not register a new data collector because of security issues');
                    } else {
                        const errors = response.allValidationMessages.join('\n');
                        this.toastr.error('Could not register new data collector:\n' + errors);
                    }
                }
            })
            .catch(response => {
                if (!response.passedSecurity) { // Security error
                    this.toastr.error('Could not register a new data collector because of security issues');
                } else {
                    const errors = response.allValidationMessages.join('\n');
                    this.toastr.error('Could not register new data collector:\n' + errors);
                }
            });
    }

    handleChangeVillage() {
        if (this.changeVillageCommand.village != null && this.changeVillageCommand.village !== '') {
            this.changeVillageCommand.dataCollectorId = this.command.dataCollectorId;

            this.commandCoordinator.handle(this.changeVillageCommand)
            .then(response => {
                if (response.success)  {
                    this.toastr.success('Successfully added village to data collector!');
                } else {
                    if (!response.passedSecurity) { // Security error
                        this.toastr.error('Could not change village of data collector because of security issues');
                    } else {
                        const errors = response.allValidationMessages.join('\n');
                        this.toastr.error('Could not change village of data collector:\n' + errors);
                    }
                }
            })
            .catch(response => {
                if (!response.passedSecurity) { // Security error
                    this.toastr.error('Could not change village of data collector because of security issues');
                } else {
                    const errors = response.allValidationMessages.join('\n');
                    this.toastr.error('Could not change village of data collector:\n' + errors);
                }
            });
        }
    }
}
