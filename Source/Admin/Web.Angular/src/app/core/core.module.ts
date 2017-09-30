import { NationalSocietyService } from './nationalsociety.service';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { ProjectService } from './project.service';
import { UtilityService } from './utility.service';

@NgModule({
    imports: [
        CommonModule
    ],
    providers: [
        ProjectService,
        UtilityService,
        NationalSocietyService
    ],
    declarations: [
    ]
})

export class CoreModule { }
