import { CommonModule } from '@angular/common';
import { NgModule, Optional, SkipSelf } from '@angular/core';

import { ApiService } from './api.service';
import { throwIfAlreadyLoaded } from './module-import-guard';
import { NationalSocietyService } from './nationalsociety.service';
import { ProjectService } from './project.service';
import { HealthRiskService } from './healthRisk.service'
import { UserService } from './user.service';
import { UtilityService } from './utility.service';

@NgModule({
    imports: [
        CommonModule
    ],
    providers: [
        ApiService,
        ProjectService,
        HealthRiskService,
        UtilityService,
        NationalSocietyService,
        UserService
    ],
    declarations: []
})

export class CoreModule {
    constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
        throwIfAlreadyLoaded(parentModule, 'CoreModule');
      }
}
