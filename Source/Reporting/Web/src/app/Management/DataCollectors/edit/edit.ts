import { Component, Input, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

import { CommandCoordinator } from '@dolittle/commands';
import { Language } from '../../Language';
import { Location } from '../../Location';
import { Sex } from '../../Sex';
import { AddPhoneNumberToDataCollector } from '../EditInformation/AddPhoneNumberToDataCollector';
import { ChangeBaseInformation } from '../EditInformation/ChangeBaseInformation';
import { ChangeLocation } from '../EditInformation/ChangeLocation';
import { ChangePreferredLanguage } from '../EditInformation/ChangePreferredLanguage';
import { RemovePhoneNumberFromDataCollector } from '../EditInformation/RemovePhoneNumberFromDataCollector';
import { DataCollector } from '../DataCollector';
import { ChangeVillage } from '../EditInformation/ChangeVillage';
import { QueryCoordinator } from '@dolittle/queries';
import { DataCollectorById } from '../DataCollectorById';

@Component({
    templateUrl: './edit.html',
    styleUrls: ['./edit.scss']
})
export class Edit implements OnInit {
    error = false;
    dataCollector: DataCollector;
    phoneNumberString = '';

    changeBaseInformationCommand: ChangeBaseInformation = new ChangeBaseInformation();
    changeLocationCommand: ChangeLocation = new ChangeLocation();
    changePreferredLanguageCommand: ChangePreferredLanguage = new ChangePreferredLanguage();
    changeVillageCommand: ChangeVillage = new ChangeVillage();

    languageOptions = [{ desc: Language[Language.English], id: Language.English as number },
    { desc: Language[Language.French], id: Language.French as number }];
    sexOptions = [{ desc: Sex[Sex.Male], id: Sex.Male as number },
    { desc: Sex[Sex.Female], id: Sex.Female as number }];

    private userHasChanged = false;

    constructor(
        private router: Router,
        private route: ActivatedRoute,
        private commandCoordinator: CommandCoordinator,
        private toastr: ToastrService,
        private queryCoordinator: QueryCoordinator<DataCollector>
    ) {
        toastr.toastrConfig.positionClass = 'toast-top-center';
    }
    ngOnInit(): void {
        this.route.params.subscribe(params => {
            this.getDataCollector();
        });
    }

    getDataCollector(): void {
        const id = this.route.snapshot.paramMap.get('id');
        let query = new DataCollectorById();
        query.dataCollectorId = id;
        this.queryCoordinator.execute(query)
            .then(response => {
                if (response.success) {
                    if (response.items.length > 0) {
                        this.dataCollector = response.items[0]
                        this.initChangeBaseInformation();
                        this.initChangeLocation();
                        this.initChangePreferredLanguage();
                        this.initPhoneNumbers();
                        this.initVillage();                        
                    } else {
                        console.error(response)
                    }
                } else {
                    console.error(response);
                }
            })
            .catch(response => {
                console.error(response);
            })
    }


    onLocationSelected(event) {
        this.changeLocationCommand.location.latitude = event.coords.lat;
        this.changeLocationCommand.location.longitude = event.coords.lng;
    }

    submit() {
        // Make queue of commands
        const queue = [];

        this.handleChangeBaseInformation(queue);
        this.handleChangeLocation(queue);
        this.handleChangePreferredLanguage(queue);
        this.handleChangeVillage(queue);
        this.handleAddPhoneNumbers(queue);
        this.handleRemovePhoneNumbers(queue);

        this.handleQueue(queue);
    }

    private handleQueue(queue) {
        if (queue.length == 0) {
            if (this.userHasChanged) {
                this.toastr.info('Reload page to see changes');
            } else {
                this.toastr.warning('No changes has been made');
            }
            this.router.navigate(['datacollectors']);
        } else {
            // Handle a command and wait for the response
            const current = queue.shift();
            this.commandCoordinator.handle(current.command).then(response => {
                current.then(response);
                this.handleQueue(queue);
            }).catch(response => {
                current.catch(response);
                this.handleQueue(queue);
            });
        }
    }


    private initChangeBaseInformation() {
        this.changeBaseInformationCommand.dataCollectorId = this.dataCollector.id;
        this.changeBaseInformationCommand.displayName = this.dataCollector.displayName;
        this.changeBaseInformationCommand.fullName = this.dataCollector.fullName;
        this.changeBaseInformationCommand.sex = this.dataCollector.sex;
        this.changeBaseInformationCommand.yearOfBirth = this.dataCollector.yearOfBirth;
        this.changeBaseInformationCommand.region = this.dataCollector.region;
        this.changeBaseInformationCommand.district = this.dataCollector.district;
    }

    private initChangeLocation() {
        this.changeLocationCommand.dataCollectorId = this.dataCollector.id;
        this.changeLocationCommand.location = new Location();
        this.changeLocationCommand.location.latitude = this.dataCollector.location.latitude;
        this.changeLocationCommand.location.longitude = this.dataCollector.location.longitude;

    }
    private initChangePreferredLanguage() {
        this.changePreferredLanguageCommand.dataCollectorId = this.dataCollector.id;
        this.changePreferredLanguageCommand.preferredLanguage = this.dataCollector.preferredLanguage;
    }
    private initPhoneNumbers() {
        this.phoneNumberString = this.dataCollector.phoneNumbers.join(', ');
    }
    private initVillage() {
        this.changeVillageCommand.dataCollectorId = this.dataCollector.id;
        this.changeVillageCommand.village = this.dataCollector.village;
    }

    private handleChangeBaseInformation(queue) {
        if (this.hasChangedBaseInformation()) {
            this.userHasChanged = true;
            queue.push({
                command: this.changeBaseInformationCommand,
                then: response => {
                    if (response.success) {
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
                },
                catch: response => {
                    if (!response.passedSecurity) { // Security error
                        this.toastr.error(`Could not change ${this.changeBaseInformationCommand.displayName}s` +
                            ' base information because of security issues');
                    } else {
                        const errors = response.allValidationMessages.join('\n');
                        this.toastr.error(`Could not change ${this.changeBaseInformationCommand.displayName}s`
                            + ` base information:\n${errors}`);
                    }
                },
            });
        }
    }
    private handleChangeLocation(queue) {
        if (this.hasChangedLocation()) {
            this.userHasChanged = true;
            queue.push({
                command: this.changeLocationCommand,
                then: response => {
                    if (response.success) {
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
                },
                catch: response => {
                    if (!response.passedSecurity) { // Security error
                        this.toastr.error(`Could not change ${this.changeBaseInformationCommand.displayName}s` +
                            ' location because of security issues');
                    } else {
                        const errors = response.allValidationMessages.join('\n');
                        this.toastr.error(`Could not change ${this.changeBaseInformationCommand.displayName}s location:\n${errors}`);
                    }
                },
            });
        }
    }
    private handleChangePreferredLanguage(queue) {
        if (this.hasChangedPreferredLanguage()) {
            this.userHasChanged = true;
            queue.push({
                command: this.changePreferredLanguageCommand,
                then: response => {
                    if (response.success) {
                        this.toastr.success(`Successfully changed ${this.changeBaseInformationCommand.displayName}s preferred language`);
                    } else {
                        if (!response.passedSecurity) { // Security error
                            this.toastr.error(`Could not change ${this.changeBaseInformationCommand.displayName}s` +
                                ' preferred language because of security issues');
                        } else {
                            const errors = response.allValidationMessages.join('\n');
                            this.toastr.error(`Could not change ${this.changeBaseInformationCommand.displayName}s`
                                + ` preferred language:\n${errors}`);
                        }
                    }
                },
                catch: response => {
                    if (!response.passedSecurity) { // Security error
                        this.toastr.error(`Could not change ${this.changeBaseInformationCommand.displayName}s` +
                            ' preferred language because of security issues');
                    } else {
                        const errors = response.allValidationMessages.join('\n');
                        this.toastr.error(`Could not change ${this.changeBaseInformationCommand.displayName}s`
                            + ` preferred language:\n${errors}`);
                    }
                },
            });
        }
    }

    handleChangeVillage(queue) {
        if (this.changeVillageCommand.village != null && this.changeVillageCommand.village !== this.dataCollector.village) {
            this.userHasChanged = true;
            this.changeVillageCommand.dataCollectorId = this.dataCollector.id;
            queue.push({
                command: this.changeVillageCommand,
                then: response => {
                    if (response.success) {
                        this.toastr.success('Successfully added village to data collector!');
                    } else {
                        if (!response.passedSecurity) { // Security error
                            this.toastr.error('Could not change village of data collector because of security issues');
                        } else {
                            const errors = response.allValidationMessages.join('\n');
                            this.toastr.error('Could not change village of data collector:\n' + errors);
                        }
                    }
                },
                catch: response => {
                    if (!response.passedSecurity) { // Security error
                        this.toastr.error('Could not change village of data collector because of security issues');
                    } else {
                        const errors = response.allValidationMessages.join('\n');
                        this.toastr.error('Could not change village of data collector:\n' + errors);
                    }
                },
            });
        }
    }
    private handleAddPhoneNumbers(queue) {
        const prevNumbers = this.dataCollector.phoneNumbers.map(number => number.trim());
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
            cmd.dataCollectorId = this.dataCollector.id;
            cmd.phoneNumber = number;
            queue.push({
                command: cmd,
                then: response => {
                    if (response.success) {
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
                },
                catch: response => {
                    if (!response.passedSecurity) { // Security error
                        this.toastr.error(`Could not add ${cmd.phoneNumber} to ${this.changeBaseInformationCommand.displayName}s` +
                            ' phone numbers because of security issues');
                    } else {
                        const errors = response.allValidationMessages.join('\n');
                        this.toastr.error(`Could not add ${cmd.phoneNumber} to ${this.changeBaseInformationCommand.displayName}s`
                            + ` phone numbers:\n${errors}`);
                    }
                },
            });
        });
    }

    private handleRemovePhoneNumbers(queue) {
        const prevNumbers = this.dataCollector.phoneNumbers.map(number => number.trim());
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
            cmd.dataCollectorId = this.dataCollector.id;
            cmd.phoneNumber = number;
            queue.push({
                command: cmd,
                then: response => {
                    if (response.success) {
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
                },
                catch: response => {
                    if (!response.passedSecurity) { // Security error
                        this.toastr.error(`Could not remove ${cmd.phoneNumber} from`
                            + ` ${this.changeBaseInformationCommand.displayName}s phone numbers because of security issues`);
                    } else {
                        const errors = response.allValidationMessages.join('\n');
                        this.toastr.error(`Could not remove ${cmd.phoneNumber} from`
                            + ` ${this.changeBaseInformationCommand.displayName}s phone numbers:\n${errors}`);
                    }
                },
            });
        });
    }

    private hasChangedBaseInformation() {
        return (this.changeBaseInformationCommand.displayName !== this.dataCollector.displayName
            || this.changeBaseInformationCommand.fullName !== this.dataCollector.fullName
            || this.changeBaseInformationCommand.sex !== this.dataCollector.sex
            || this.changeBaseInformationCommand.yearOfBirth !== this.dataCollector.yearOfBirth);
    }
    private hasChangedLocation() {
        return (this.dataCollector.location.latitude !== this.changeLocationCommand.location.latitude
            || this.dataCollector.location.longitude !== this.changeLocationCommand.location.longitude);
    }
    private hasChangedPreferredLanguage() {
        return this.changePreferredLanguageCommand.preferredLanguage !== this.dataCollector.preferredLanguage;
    }
}
