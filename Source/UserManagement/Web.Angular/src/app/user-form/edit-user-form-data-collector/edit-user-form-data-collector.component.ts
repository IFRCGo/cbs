import { Component, Input, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { CommandCoordinator } from '../../services/CommandCoordinator';
import { Command } from '../../services/Command';
import { Language } from '../../domain/language.model';
import {Location } from '../../domain/location.model';
import { Sex } from '../../domain/sex';
import { ToastrService } from 'ngx-toastr';
import { AddPhoneNumberToDataCollector } from '../../domain/data-collector/AddPhoneNumberToDataCollector';
import { ChangeBaseInformation } from '../../domain/data-collector/ChangeBaseInformation';
import { ChangeLocation } from '../../domain/data-collector/ChangeLocation';
import { ChangePreferredLanguage } from '../../domain/data-collector/ChangePreferredLanguage';
import { RemovePhoneNumberFromDataCollector } from '../../domain/data-collector/RemovePhoneNumberFromDataCollector';
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

    changeBaseInformationCommand: ChangeBaseInformation = new ChangeBaseInformation();
    changeLocationCommand: ChangeLocation = new ChangeLocation();
    changePreferredLanguageCommand: ChangePreferredLanguage = new ChangePreferredLanguage();

    languageOptions = [{desc: Language[Language.English], id: Language.English as number},
                        {desc: Language[Language.French], id: Language.French as number}];
    sexOptions = [{ desc: Sex[Sex.Male], id: Sex.Male as number },
                 { desc: Sex[Sex.Female], id: Sex.Female as number }];

    private userHasChanged = false;

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

        this.route.params.subscribe(params => {
            const id = params['id'];

        this.dataCollectorService.getDataCollectorPromise(id)
                .then(response => {
                    this.user = response[0];
                    if (this.user != null && this.user !== undefined) {
                        this.initChangeBaseInformation();
                        this.initChangeLocation();
                        this.initChangePreferredLanguage();
                        this.initPhoneNumbers();
                    } else {
                        console.error(response);
                        this.toastr.error('Could not retrieve data collector from server');
                        this.router.navigate(['list']);
                    }
                })
                .catch(error => {
                    console.error(error);
                    this.toastr.error('Could not retrieve data collector from server');
                    this.router.navigate(['list']);
                });
        });
    }

    submit() {
        this.handleChangeBaseInformation();
        this.handleChangeLocation();
        this.handleChangePreferredLanguage();
        this.handleAddPhoneNumbers();
        this.handleRemovePhoneNumbers();
        if (this.userHasChanged) {
            this.router.navigate(['list']);
            this.toastr.info('Reload page to see changes');
        } else {
            this.toastr.warning('No changes has been made');
        }
    }
    private initChangeBaseInformation() {
        this.changeBaseInformationCommand.dataCollectorId = this.user.dataCollectorId;
        this.changeBaseInformationCommand.displayName = this.user.displayName;
        this.changeBaseInformationCommand.fullName = this.user.fullName;
        this.changeBaseInformationCommand.sex = this.user.sex;
        this.changeBaseInformationCommand.yearOfBirth = this.user.yearOfBirth;
    }

    private initChangeLocation() {
        this.changeLocationCommand.dataCollectorId = this.user.dataCollectorId;
        this.changeLocationCommand.location = new Location();
        this.changeLocationCommand.location.latitude = this.user.location.latitude;
        this.changeLocationCommand.location.longitude = this.user.location.longitude;

    }
    private initChangePreferredLanguage() {
        this.changePreferredLanguageCommand.dataCollectorId = this.user.dataCollectorId;
        this.changePreferredLanguageCommand.preferredLanguage = this.user.preferredLanguage;
    }
    private initPhoneNumbers() {
        this.phoneNumberString = this.user.phoneNumbers.map(number => number.value).join(', ');

    }

//#region Handling of commands
    private handleChangeBaseInformation() {
        if (this.hasChangedBaseInformation()) {
            this.userHasChanged = true;
            this.commandCoordinator.handle(this.changeBaseInformationCommand)
                .then(response => {
                    console.log('Response from ChangeBaseInformation command')
                    console.log(response);
                    if (response.success)  {
                        this.toastr.success(`Successfully changed ${this.changeBaseInformationCommand.displayName}s base information`);
                    } else {
                        if (!response.passedSecurity) { // Security error
                            this.toastr.error(`Could not change ${this.changeBaseInformationCommand.displayName}s` +
                                ' base information because of security issues');
                        } else {
                            const errors = response.allValidationMessages.join('\n');
                            this.toastr.error(`Could not change ${this.changeBaseInformationCommand.displayName}s`
                             + ` base information :\n${errors}`);
                        }
                    }
                })
                .catch(response => {
                    console.log('Response from ChangeBaseInformation command')
                    console.log(response);
                    if (!response.passedSecurity) { // Security error
                        this.toastr.error(`Could not change ${this.changeBaseInformationCommand.displayName}s` +
                                ' base information because of security issues');
                    } else {
                        const errors = response.allValidationMessages.join('\n');
                        this.toastr.error(`Could not change ${this.changeBaseInformationCommand.displayName}s`
                             + ` base information:\n${errors}`);
                    }
                    this.router.navigate(['list']);
                });
        }
    }
    private handleChangeLocation() {
        if (this.hasChangedLocation()) {
            this.userHasChanged = true;
            this.commandCoordinator.handle(this.changeLocationCommand)
                .then(response => {
                    console.log('Response from ChangeLocation command')
                    console.log(response);
                    if (response.success)  {
                        this.toastr.success(`Successfully changed ${this.changeBaseInformationCommand.displayName}s location`);
                    } else {
                        if (!response.passedSecurity) { // Security error
                            this.toastr.error(`Could not change ${this.changeBaseInformationCommand.displayName}s` +
                                ' location because of security issues');
                        } else {
                            const errors = response.allValidationMessages.join('\n');
                            this.toastr.error(`Could not change ${this.changeBaseInformationCommand.displayName}s location:\n${errors}`);
                        }
                    }
                })
                .catch(response => {
                    console.log('Response from ChangeLocation command')
                    console.log(response);
                    if (!response.passedSecurity) { // Security error
                        this.toastr.error(`Could not change ${this.changeBaseInformationCommand.displayName}s` +
                                ' location because of security issues');
                    } else {
                        const errors = response.allValidationMessages.join('\n');
                        this.toastr.error(`Could not change ${this.changeBaseInformationCommand.displayName}s location:\n${errors}`);
                    }
                });
        }
    }
    private handleChangePreferredLanguage() {
        if (this.hasChangedPreferredLanguage()) {
            this.userHasChanged = true;
            this.commandCoordinator.handle(this.changePreferredLanguageCommand)
                .then(response => {
                    console.log('Response from ChangePreferredLanguage command')
                    console.log(response);
                    if (response.success)  {
                        this.toastr.success(`Successfully changed ${this.changeBaseInformationCommand.displayName}s preferred language`);
                    } else {
                        if (!response.passedSecurity) { // Security error
                            this.toastr.error(`Could not change ${this.changeBaseInformationCommand.displayName}s` +
                                ' preferred languagebecause of security issues');
                        } else {
                            const errors = response.allValidationMessages.join('\n');
                            this.toastr.error(`Could not change ${this.changeBaseInformationCommand.displayName}s`
                             + ` preferred language:\n${errors}`);
                        }
                    }
                })
                .catch(response => {
                    console.log('Response from ChangePreferredLanguage command')
                    console.log(response);
                    if (!response.passedSecurity) { // Security error
                        this.toastr.error(`Could not change ${this.changeBaseInformationCommand.displayName}s` +
                                ' preferred language because of security issues');
                    } else {
                        const errors = response.allValidationMessages.join('\n');
                        this.toastr.error(`Could not change ${this.changeBaseInformationCommand.displayName}s`
                             + ` preferred language:\n${errors}`);
                    }
                });
        }
    }

    private handleAddPhoneNumbers() {
        const prevNumbers = this.user.phoneNumbers.map(number => number.value.trim());
        const newNumbers = this.phoneNumberString.split(',').map(s => s.trim());
        const addednumbers = [];
        newNumbers.forEach(number => {
            if (!prevNumbers.some(prevNumber => prevNumber === number)) {
                addednumbers.push(number);
            }
        });
        addednumbers.forEach(number => {
            this.userHasChanged = true;
            const cmd = new AddPhoneNumberToDataCollector();
            cmd.dataCollectorId = this.user.dataCollectorId;
            cmd.phoneNumber = number;
            this.commandCoordinator.handle(cmd)
                .then(response => {
                    console.log('Response from AddPhoneNumberToDataCollector command')
                    console.log(response);
                    if (response.success)  {
                        this.toastr.success(`Successfully added ${cmd.phoneNumber} ${this.changeBaseInformationCommand.displayName}s`
                        + ' phone numbers');
                    } else {
                        if (!response.passedSecurity) { // Security error
                            this.toastr.error(`Could not add ${cmd.phoneNumber} to ${this.changeBaseInformationCommand.displayName}s` +
                                ' phone numbers because of security issues');
                        } else {
                            const errors = response.allValidationMessages.join('\n');
                            this.toastr.error(`Could not add ${cmd.phoneNumber} to ${this.changeBaseInformationCommand.displayName}s`
                                + ` phone numbers:\n${errors}`);
                        }
                    }
                })
                .catch(response => {
                    console.log('Response from AddPhoneNumberToDataCollector command')
                    console.log(response);
                    if (!response.passedSecurity) { // Security error
                        this.toastr.error(`Could not add ${cmd.phoneNumber} to ${this.changeBaseInformationCommand.displayName}s` +
                                ' phone numbers because of security issues');
                    } else {
                        const errors = response.allValidationMessages.join('\n');
                        this.toastr.error(`Could not add ${cmd.phoneNumber} to ${this.changeBaseInformationCommand.displayName}s`
                                + ` phone numbers:\n${errors}`);
                    }
                });
        });
    }

    private handleRemovePhoneNumbers() {
        const prevNumbers = this.user.phoneNumbers.map(number => number.value.trim());
        const newNumbers = this.phoneNumberString.split(',').map(s => s.trim());
        const removednumbers = [];
        prevNumbers.forEach(number => {
            if (!newNumbers.some(newNumber => newNumber === number)) {
                removednumbers.push(number);
            }
        });
        removednumbers.forEach(number => {
            this.userHasChanged = true;
            const cmd = new RemovePhoneNumberFromDataCollector();
            cmd.dataCollectorId = this.user.dataCollectorId;
            cmd.phoneNumber = number;

            this.commandCoordinator.handle(cmd)
                .then(response => {
                    console.log('Response from Remove PhoneNumberFromDataCollector command')
                    console.log(response);
                    if (response.success)  {
                        this.toastr.success(`Successfully removed ${cmd.phoneNumber} from`
                        + ` ${this.changeBaseInformationCommand.displayName} sphone numbers`);
                    } else {
                        if (!response.passedSecurity) { // Security error
                            this.toastr.error(`Could not remove ${cmd.phoneNumber} from`
                                + ` ${this.changeBaseInformationCommand.displayName}s phone numbers because of security issues`);
                        } else {
                            const errors = response.allValidationMessages.join('\n');
                            this.toastr.error(`Could not remove ${cmd.phoneNumber} from`
                                + ` ${this.changeBaseInformationCommand.displayName}s phone numbers:\n${errors}`);
                        }
                    }
                })
                .catch(response => {
                        console.log('Response from Remove PhoneNumberFromDataCollector command')
                        console.log(response);
                    if (!response.passedSecurity) { // Security error
                        this.toastr.error(`Could not remove ${cmd.phoneNumber} from`
                                + ` ${this.changeBaseInformationCommand.displayName}s phone numbers because of security issues`);
                    } else {
                        const errors = response.allValidationMessages.join('\n');
                        this.toastr.error(`Could not remove ${cmd.phoneNumber} from`
                                + ` ${this.changeBaseInformationCommand.displayName}s phone numbers:\n${errors}`);
                    }
                });
        });
    }

//#endregion

    private hasChangedBaseInformation() {
        return (this.changeBaseInformationCommand.displayName !== this.user.displayName
            || this.changeBaseInformationCommand.fullName !== this.user.fullName
            || this.changeBaseInformationCommand.sex !== this.user.sex
            || this.changeBaseInformationCommand.yearOfBirth !== this.user.yearOfBirth);
    }
    private hasChangedLocation() {
        return (this.user.location.latitude !== this.changeLocationCommand.location.latitude
            || this.user.location.longitude !== this.changeLocationCommand.location.longitude);
    }
    private hasChangedPreferredLanguage() {
        return this.changePreferredLanguageCommand.preferredLanguage !== this.user.preferredLanguage;
    }
}
