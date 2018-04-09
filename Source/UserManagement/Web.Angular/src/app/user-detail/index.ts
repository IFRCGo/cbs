import { Routes } from '@angular/router';

import { DataCollectorDetailComponent } from './datacollector-detail.component';

const USER_DETAIL_URL= 'detail';

export const USER_DETAIL_ROUTES: Routes = [
    {
        path: USER_DETAIL_URL,
        component: DataCollectorDetailComponent
    }
];
