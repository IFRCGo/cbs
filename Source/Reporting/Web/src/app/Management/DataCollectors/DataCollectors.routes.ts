import {Routes, RouterModule} from '@angular/router';

import {List} from './list/list';
import {Edit} from './edit/edit';
import {RegisterComponent} from './register/register';
import {Details} from './details/details';

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
                component: RegisterComponent
            },
            {
                path: 'edit/:id',
                component: Edit
            },
            {
                path: 'details/:id',
                component: Details
            }
        ]
    }
]

export const DataCollectorsRoutes = RouterModule.forChild(routes);
