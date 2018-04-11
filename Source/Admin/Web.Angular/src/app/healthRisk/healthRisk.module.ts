import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';
import { HealthRiskRouting } from './healthRisk-routing.module';
import { HealthRiskListComponent } from './healthRisk-list/healthRisk-list.component';
import { AddEditHealthRiskComponent } from './add-edit-healthRisk/add-edit-healthRisk.component';

@NgModule({
    imports: [
        HealthRiskRouting,
        SharedModule
    ],
    declarations: [
        HealthRiskListComponent,
        AddEditHealthRiskComponent
    ]
})

export class HealthRiskModule { }
