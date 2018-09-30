import { Routes } from '@angular/router';

import { DataCollectorDetailComponent } from './datacollector-detail.component';

export const USER_DETAIL_ROUTES: Routes = [
    { path: 'detail/:id', component: DataCollectorDetailComponent }
];
