import { Component, Input, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { CommandCoordinator } from '../../services/CommandCoordinator';
import { Command } from '../../services/Command';
import { Language } from '../../domain/language.model';
import { Sex } from '../../domain/sex';
import { ToastrService } from 'ngx-toastr';
import { environment } from '../../../environments/environment.prod';
import { AddPhoneNumberToDataCollector } from '../../domain/data-collector/AddPhoneNumberToDataCollector';
import { ChangeBaseInformation } from '../../domain/data-collector/ChangeBaseInformation';
import { ChangeLocation } from '../../domain/data-collector/ChangeLocation';
import { ChangePreferredLanguage } from '../../domain/data-collector/ChangePreferredLanguage';
import { RemovePhoneNumberFromDateCollector } from '../../domain/data-collector/RemovePhoneNumberFromDataCollector';
import { DataCollector } from '../../domain/data-collector';
import { DataCollectorService } from '../../services/data-collector.service';

export const DATA_COLLECTOR_PATH = 'data-collector';

@Component({
    templateUrl: './edit-user-form-data-collector.component.html',
    styleUrls: ['./edit-user-form-data-collector.component.scss']
})
export class EditUserFormDataCollectorComponent implements OnInit {

    error = false;
    user: DataCollector;
    phoneNumberString = '';

    removePhoneNumberCommands: Array<RemovePhoneNumberFromDateCollector> = new Array;
    addPhoneNumberCommands: Array<AddPhoneNumberToDataCollector> = new Array;
    changeBaseInformationCommand: ChangeBaseInformation = new ChangeBaseInformation();
    changeLocationCommand: ChangeLocation = new ChangeLocation();
    changePreferredLanguageCommand: ChangePreferredLanguage = new ChangePreferredLanguage();

    languageOptions = [{desc: Language[Language.English], id: Language.English},
                        {desc: Language[Language.French], id: Language.French}];
    sexOptions = [{ desc: Sex[Sex.Male], id: Sex.Male },
                 { desc: Sex[Sex.Female], id: Sex.Female }];

    constructor(
        private router: Router,
        private route: ActivatedRoute,
        private commandCoordinator: CommandCoordinator,
        private toastr: ToastrService,
        private dataCollectorService: DataCollectorService
        ) {
        toastr.toastrConfig.positionClass = 'toast-top-center';
    }
    ngOnInit(): void {
        const sub = this.route.params.subscribe(params => {
            const id = params['id'];

        console.log(id);
        this.dataCollectorService.getDataCollectorPromise(id)
                .then(response => {
                    this.user = response[0];
                    this.initChangeBaseInformation();
                    this.initChangeLocation();
                    this.initChangePreferredLanguage();
                    if (this.user != null && this.user !== undefined) {
                        this.toastr.success('Successfully retrieved the data collector');
                        this.error = false;
                    }
                })
                .catch(error => {
                    console.error(error);
                    this.error = true;
                });
        });
    }

    submit() {
        console.log(this.changeBaseInformationCommand);
        console.log(this.changeLocationCommand);
        console.log(this.changePreferredLanguageCommand);
    }
    private initChangeBaseInformation() {
        this.changeBaseInformationCommand.dataCollectorId = this.user.dataCollectorId;
        this.changeBaseInformationCommand.displayName = this.user.displayName;
        this.changeBaseInformationCommand.fullName = this.user.fullName;
        this.changeBaseInformationCommand.sex = Sex[this.user.sex];
        this.changeBaseInformationCommand.yearOfBirth = this.user.yearOfBirth;
    }

    private initChangeLocation() {
        this.changeLocationCommand.dataCollectorId = this.user.dataCollectorId;
        this.changeLocationCommand.location = this.user.location;
    }
    private initChangePreferredLanguage() {
        this.changePreferredLanguageCommand.dataCollectorId = this.user.dataCollectorId;
        this.changePreferredLanguageCommand.preferredLanguage = Language[this.user.preferredLanguage];
    }
    private handleChangeBaseInformation() {
        // TODO:
    }
    private handleChangeLocation() {
        if (this.user.location.latitude !== this.changeLocationCommand.location.latitude
            || this.user.location.longitude !== this.changeLocationCommand.location.longitude) {
                this.commandCoordinator.handle(this.changeLocationCommand)
                    .then(response => {

                    })
                    .catch(error => {

                    });
            }
    }
    private handleChangePreferredLanguage() {
        // TODO:
    }
    

}
