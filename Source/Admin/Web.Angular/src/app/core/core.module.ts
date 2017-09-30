import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProjectService } from './project.service';
import { UtilityService } from './utility.service';

@NgModule({
    imports: [
        CommonModule
    ],
    providers: [
        ProjectService,
        UtilityService
    ],
    declarations: [
    ]
})

export class CoreModule { }
