import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';
import { DataCollectorsRoutes } from './DataCollectors.routes';
import { DataCollectorListComponent } from './datacollector-list/datacollector-list.component';
import { DataCollectorExportComponent } from './datacollector-export/datacollector-export.component';
import { DataCollectorEditComponent } from './datacollector-edit/datacollector-edit.component';
import { DataCollectorRegisterComponent } from './datacollector-register/datacollector-register.component';
import { DataCollectorDeleteComponent } from './datacollector-delete/datacollector-delete.component';

console.log("MODULE");


@NgModule({
    imports: [
        DataCollectorsRoutes,
        SharedModule
    ],
    declarations: [
        DataCollectorListComponent,
        DataCollectorExportComponent,
        DataCollectorEditComponent,
        DataCollectorRegisterComponent,
        DataCollectorDeleteComponent
    ]
})
export class DataCollectorsModule { }