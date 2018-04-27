import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { CommandCoordinator } from '../../services/CommandCoordinator';
import { Command } from '../../services/Command';
import { Guid } from '../../services/Guid';
import { Language } from '../../domain/language.model';
import { Sex } from '../../domain/sex';
import { RegisterDataCollector } from '../../domain/data-collector/RegisterDataCollector';

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
        private commandCoordinator: CommandCoordinator
    ) { }

    submit() {
        this.command.dataCollectorId = Guid.create();
        this.command.phoneNumbers = this.phoneNumberString.split(',');
        this.command.phoneNumbers.map( number => number.trim());
        console.log(this.command);
        this.commandCoordinator.handle(this.command)
            .then(response => {
                console.log(response);
                // this.router.navigate(['list']);
            })
            .catch(response => {
                console.log(response);
                // this.router.navigate(['list']);
            });
    }
}
