import { Routes, RouterModule } from '@angular/router';

import { List } from './list/list';
import { Edit } from './edit/edit';
import { Register } from './register/register';
import { Details } from './details/details';
import { Delete } from './delete/delete';
import { Export } from './export/export';


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
            }
        ]
    }
]

export const DataCollectorsRoutes = RouterModule.forChild(routes);
