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
const EDIT_USER_URL_PREFIX = 'edit-user';

const USER_FORM_PATH_MAPPINGS = {
    [ADMIN_PATH]: UserFormAdminComponent,
    [DATA_COLLECTOR_PATH]: UserFormDataCollectorComponent,
    [DATA_CONSUMER_PATH]: UserFormDataConsumerComponent,
    [DATA_COORDINATOR_PATH]: UserFormDataCoordinatorComponent,
    [DATA_OWNER_PATH]: UserFormDataOwnerComponent,
    [DATA_VERIFIER_PATH]: UserFormDataVerifierComponent,
    [SYSTEM_CONFIGURATOR_PATH]: UserFormSystemConfiguratorComponent
};

export function addUserFormRoutes(): Routes {
    return Object.entries(USER_FORM_PATH_MAPPINGS)
        .map(function ([ pathSuffix, component ]) {
            return {
                path: `${ADD_USER_URL_PREFIX}/${pathSuffix}`,
                component
            };
        });
}

export function editUserFormRoutes(): Routes {
    return Object.entries(USER_FORM_PATH_MAPPINGS)
        .map(function ([ pathSuffix, component ]) {
            return {
                path: `${EDIT_USER_URL_PREFIX}/${pathSuffix}/:id`,
                component
            };
        });
}
