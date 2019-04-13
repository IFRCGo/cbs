import { NgModule } from '@angular/core';
import { AngularMultiSelectModule } from 'angular2-multiselect-dropdown';

import { SharedModule } from '../../shared/shared.module';
import { DataCollectorsRoutes } from './DataCollectors.routes';
import { List } from './list/list';
import { Edit } from './edit/edit';
import { Register } from './register/register';
import { Details } from './details/details';
import { Export } from './export/export';
import { Delete } from './delete/delete';
import { SendSms } from './send-sms/send-sms';

@NgModule({
    imports: [
        DataCollectorsRoutes,
        SharedModule,
        AngularMultiSelectModule
    ],
    declarations: [
        List,
        Edit,
        Register,
        Details,
        Export,
        Delete,
        SendSms
    ]
})
export class DataCollectorsModule { }
