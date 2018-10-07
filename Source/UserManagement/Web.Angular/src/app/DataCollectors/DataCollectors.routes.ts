import { Routes, RouterModule } from '@angular/router';

import { DataCollectorListComponent } from './datacollector-list/datacollector-list.component';
import { DataCollectorEditComponent } from './datacollector-edit/datacollector-edit.component';
import { DataCollectorRegisterComponent } from './datacollector-register/datacollector-register.component';
import { DataCollectorDetailComponent } from './datacollector-detail/datacollector-detail.component';
import { DataCollectorDeleteComponent } from './datacollector-delete/datacollector-delete.component';
import { DataCollectorExportComponent } from './datacollector-export/datacollector-export.component';


const routes: Routes = [
    {
        path: "datacollectors",
        children: [
            {
                path: '',
                component: DataCollectorListComponent
            },
            {
                path: 'register',
                component: DataCollectorRegisterComponent
            },
            {
                path: 'edit',
                component: DataCollectorEditComponent
            }
        ]
    }
]

export const DataCollectorsRoutes = RouterModule.forChild(routes);

/*
  { path: 'list', component: DataCollectorListComponent },
  { path: '', component: DataCollectorListComponent },
  { path: '**', component: DataCollectorListComponent }

*/
