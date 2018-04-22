import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";
import { RegisterDataCollector } from '../../domain/RegisterDataCollector';

import { CommandCoordinator } from '../../services/CommandCoordinator';
import { Command } from '../../services/Command';
import { Guid } from '../../services/Guid';

export const DATA_COLLECTOR_PATH = 'data-collector';

@Component({
    templateUrl: './user-form-data-collector.component.html',
    styleUrls: ['./user-form-data-collector.component.scss']
})
export class UserFormDataCollectorComponent {

    phoneNumberString: string;
    command: RegisterDataCollector = new RegisterDataCollector();
    languageOptions = ['English', 'French'];
    sexOptions = [{ desc: 'Male', id: '1' }, { desc: 'Female', id: '2' }];

    constructor(
        private router: Router,
        private commandCoordinator: CommandCoordinator
    ) { }

    submit() {
        this.command.dataCollectorId = Guid.create();
        this.command.phoneNumbers = this.phoneNumberString.split(',');
        this.commandCoordinator.handle(this.command)
            .then(response => {
                console.log(response); 
                //this.router.navigate(['list']);
            })
            .catch(response => {
                console.log(response);
                //this.router.navigate(['list']);
            });
    }
}
