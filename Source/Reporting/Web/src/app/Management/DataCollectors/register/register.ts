import { AfterViewInit, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CommandCoordinator } from '@dolittle/commands';
import { Guid } from '@dolittle/core';
import * as L from 'leaflet';
import { ToastrService } from 'ngx-toastr';
import { AppInsightsService } from '../../../services/app-insights-service';
import { Language } from '../../Language';
import { Sex } from '../../Sex';
import { ChangeVillage } from '../ChangeVillage';
import { RegisterDataCollector } from '../RegisterDataCollector';


@Component({
    templateUrl: './register.html',
    styleUrls: ['./register.scss']
})
export class Register implements OnInit, AfterViewInit {
  
    commandCoordinator: CommandCoordinator;
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
    map: L.Map;
    marker: L.Marker;
    constructor(
        private router: Router,
        private toastr: ToastrService,
        private appInsightsService: AppInsightsService
    ) {
        toastr.toastrConfig.positionClass = 'toast-top-center';
    }

    ngOnInit() {
        this.appInsightsService.trackPageView('RegisterDataCollector');
        this.commandCoordinator = new CommandCoordinator();
    }
    ngAfterViewInit(): void {
        this.map = L.map("mapid").setView([this.defaultLat, this.defaultLng], 7);
        L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
            attribution: '&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors',
          }).addTo(this.map)
        this.map.on('click', (e) => {
            this.onLocationSelected(e);
        });
    }
    
    onLocationSelected(event){
        this.locationSelected = true;
        this.selectedLat = event.latlng.lat;
        this.selectedLng = event.latlng.lng;
        if (this.marker) {
            this.map.removeLayer(this.marker);
        }
        this.marker = L.marker([event.latlng.lat, event.latlng.lng]).addTo(this.map);

        this.command.gpsLocation.latitude = this.selectedLat;
        this.command.gpsLocation.longitude = this.selectedLng;
    }

    submit() {
        this.command.dataCollectorId = Guid.create();
        this.command.phoneNumbers = this.phoneNumberString.split(',').map(number => number.trim());
        this.command.dataVerifierId = Guid.create(); //TODO: THis is just temporary, dataVerifier should be bound through the form
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
