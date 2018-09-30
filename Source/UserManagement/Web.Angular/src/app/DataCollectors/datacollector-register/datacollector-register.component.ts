import { Component, OnInit} from '@angular/core';
import { Router } from '@angular/router';

import { CommandCoordinator } from '@dolittle/commands';
import { Guid } from '@dolittle/core';
import { Language } from '../../Language';
import { Sex } from '../../Sex';
import { RegisterDataCollector } from '../RegisterDataCollector';
import { ToastrService } from 'ngx-toastr';
import { ChangeVillage } from '../ChangeVillage';

export const DATA_COLLECTOR_PATH = 'data-collector';

@Component({
    templateUrl: './datacollector-register.component.html',
    styleUrls: ['./datacollector-register.component.scss']
})

export class DataCollectorRegisterComponent {
    locationSelected = false;
    defaultLat: number = 9.216515;
    defaultLng: number = 45.523637;
    selectedLat: number = this.defaultLat;
    selectedLng: number = this.defaultLng;

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
        private toastr: ToastrService
    ) {
        toastr.toastrConfig.positionClass = 'toast-top-center';
    }

    onLocationSelected(event){
        this.locationSelected = true;
        this.selectedLat = event.coords.lat;
        this.selectedLng = event.coords.lng;
        this.command.gpsLocation.latitude = this.selectedLat;
        this.command.gpsLocation.longitude = this.selectedLng;
    }

    submit() {
        console.log("inni submit")
        this.command.dataCollectorId = Guid.create();
        this.command.phoneNumbers = this.phoneNumberString.split(',').map(number => number.trim());
        this.commandCoordinator.handle(this.command)
            .then(response => {
                console.log(response);
                if (response.success)  {
                    this.toastr.success('Successfully registered a new data collector!');
                    this.handleChangeVillage();
                    this.router.navigate(['list']);
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
                console.log(response);
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
                console.log(response);
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
                console.log(response);
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
