import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { CommandCoordinator } from '../../services/CommandCoordinator';
import { Command } from '../../services/Command';
import { Guid } from '../../services/Guid';
import { Language } from '../../domain/language.model';
import { Sex } from '../../domain/sex';
import { RegisterDataCollector } from '../../domain/data-collector/RegisterDataCollector';
import { ToastrService } from 'ngx-toastr';
import { environment } from '../../../environments/environment.prod';

export const DATA_COLLECTOR_PATH = 'data-collector';

@Component({
    templateUrl: './user-form-data-collector.component.html',
    styleUrls: ['./user-form-data-collector.component.scss']
})
export class UserFormDataCollectorComponent {

    phoneNumberString = '';
    command: RegisterDataCollector = new RegisterDataCollector();
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

    submit() {
        this.command.dataCollectorId = Guid.create();
        this.command.phoneNumbers = this.phoneNumberString.split(',');
        this.command.phoneNumbers.map( number => number.trim());
        this.commandCoordinator.handle(this.command)
            .then(response => {
                if (!environment.production) {
                    console.log(response);
                }
                if (response.success)  {
                    this.toastr.success('Successfully registered a new data collector!');
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
                if (!environment.production) {
                    console.log(response);
                }
                if (!response.passedSecurity) { // Security error
                    this.toastr.error('Could not register a new data collector because of security issues');
                } else {
                    const errors = response.allValidationMessages.join('\n');
                    this.toastr.error('Could not register new data collector:\n' + errors);
                }
            });
    }
}
