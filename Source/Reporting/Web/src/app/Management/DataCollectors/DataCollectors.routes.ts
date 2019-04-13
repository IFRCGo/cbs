import { Routes, RouterModule } from '@angular/router';

import { List } from './list/list';
import { Edit } from './edit/edit';
import { Register } from './register/register';
import { Details } from './details/details';
import { SendSms } from './send-sms/send-sms';

const routes: Routes = [
    {
        path: "datacollectors",
        children: [
            {
                path: '',
                component: List
            },
            {
                path: 'register',
                component: Register
            },
            {
                path: 'edit/:id',
                component: Edit
            },
            {
                path: 'details/:id',
                component: Details
            },
            {
                path: 'send-sms',
                component: SendSms
            }
        ]
    }
]

export const DataCollectorsRoutes = RouterModule.forChild(routes);
