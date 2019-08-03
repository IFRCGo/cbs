import { Component, OnInit} from '@angular/core';
import { Router } from '@angular/router';

import { CommandCoordinator } from '@dolittle/commands';
import { Guid } from '@dolittle/core';
import { Language } from '../../Language';
import { Sex } from '../../Sex';
import { RegisterDataCollector } from '../RegisterDataCollector';
import { ToastrService } from 'ngx-toastr';
import { ChangeVillage } from '../ChangeVillage';
import { AppInsightsService } from '../../../services/app-insights-service';

@Component({
    templateUrl: './register.html',
    styleUrls: ['./register.scss']
})
export class Register {
    // https://www.google.com/maps/@-0.2737178,21.7762443,4.04z
    locationSelected = false;
    defaultLat: number = 21.7762443;
    defaultLng: number = 0.2737178;
    selectedLat: number; 
    selectedLng: number;    

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
        // Check the current location or take the default location values
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(position => {
             this.showPosition(position);
           });
           } else {
         this.selectedLng = this.defaultLng;
         this.selectedLat = this.defaultLat;
        }
        this.appInsightsService.trackPageView('RegisterDataCollector');
    }

showPosition(position) {
        // update longitude and latitude with current location data
        this.locationSelected = true;
        this.selectedLng = position.coords.longitude;
        this.selectedLat = position.coords.latitude;
        // Replace the default map value with the current lat/long
        this.defaultLng = this.selectedLng;
        this.defaultLat = this.selectedLat;
        // update the map
        this.command.gpsLocation.latitude = this.selectedLat;
        this.command.gpsLocation.longitude = this.selectedLng;
        console.log(`longitude: ${ position.coords.longitude} | latitude: ${ position.coords.latitude }`);
        console.log(`selectedLng: ${ this.selectedLng} | selectedLat: ${ this.selectedLat }`);
    }

    onLocationSelected(event){
        this.locationSelected = true;
        this.selectedLat = event.coords.lat;
        this.selectedLng = event.coords.lng;
        this.command.gpsLocation.latitude = this.selectedLat;
        this.command.gpsLocation.longitude = this.selectedLng;
    }

    submit() {
        this.command.dataCollectorId = Guid.create();
        this.command.phoneNumbers = this.phoneNumberString.split(',').map(number => number.trim());
        this.command.dataVerifierId = Guid.create(); //TODO: THis is just temporary, dataVerifier should be bound through the form
        console.log(this.command);
        this.commandCoordinator.handle(this.command)
            .then(response => {
                console.log(response);
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
