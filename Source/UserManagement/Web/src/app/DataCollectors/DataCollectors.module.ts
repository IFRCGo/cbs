import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';
import { DataCollectorsRoutes } from './DataCollectors.routes';
import { List } from './list/list';
import { Edit } from './edit/edit';
import { Register } from './register/register';
import { Details } from './details/details';
import { Export } from './export/export';
import { Delete } from './delete/delete';

@NgModule({
    imports: [
        DataCollectorsRoutes,
        SharedModule
    ],
    declarations: [
        List,
        Edit,
        Register,
        Details,
        Export,
        Delete
    ]
})
export class DataCollectorsModule { }