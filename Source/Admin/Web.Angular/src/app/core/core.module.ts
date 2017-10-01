import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { NationalSocietyService } from './nationalsociety.service';
import { ProjectService } from './project.service';
import { UserService } from './user.service';
import { UtilityService } from './utility.service';

@NgModule({
    imports: [
        CommonModule
    ],
    providers: [
        ProjectService,
        UtilityService,
        NationalSocietyService,
        UserService
    ],
    declarations: [
    ]
})

export class CoreModule { }
