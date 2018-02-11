import { Routes } from '@angular/router';

import { UserFormAdminComponent, ADMIN_PATH } from './user-form-admin/user-form-admin.component';
import { UserFormDataCollectorComponent, DATA_COLLECTOR_PATH } from './user-form-data-collector/user-form-data-collector.component';
import { UserFormDataConsumerComponent, DATA_CONSUMER_PATH } from './user-form-data-consumer/user-form-data-consumer.component';
import { UserFormDataOwnerComponent, DATA_OWNER_PATH } from './user-form-data-owner/user-form-data-owner.component';
import { UserFormDataVerifierComponent, DATA_VERIFIER_PATH } from './user-form-data-verifier/user-form-data-verifier.component';
import {
    UserFormDataCoordinatorComponent,
    DATA_COORDINATOR_PATH
} from './user-form-data-coordinator/user-form-data-coordinator.component';
import {
    UserFormSystemConfiguratorComponent,
    SYSTEM_CONFIGURATOR_PATH
} from './user-form-system-configurator/user-form-system-configurator.component';

const ADD_USER_URL_PREFIX = 'add-user';

export const USER_FORM_ROUTES: Routes = [
    {
        path: `${ADD_USER_URL_PREFIX}/${ADMIN_PATH}`,
        component: UserFormAdminComponent
    },
    {
        path: `${ADD_USER_URL_PREFIX}/${DATA_COLLECTOR_PATH}`,
        component: UserFormDataCollectorComponent
    },
    {
        path: `${ADD_USER_URL_PREFIX}/${DATA_CONSUMER_PATH}`,
        component: UserFormDataConsumerComponent
    },
    {
        path: `${ADD_USER_URL_PREFIX}/${DATA_OWNER_PATH}`,
        component: UserFormDataOwnerComponent
    },
    {
        path: `${ADD_USER_URL_PREFIX}/${DATA_VERIFIER_PATH}`,
        component: UserFormDataVerifierComponent
    },
    {
        path: `${ADD_USER_URL_PREFIX}/${DATA_COORDINATOR_PATH}`,
        component: UserFormDataCoordinatorComponent
    },
    {
        path: `${ADD_USER_URL_PREFIX}/${SYSTEM_CONFIGURATOR_PATH}`,
        component: UserFormSystemConfiguratorComponent
    }
];
