import { Component, OnInit } from '@angular/core';

import { ADMIN_PATH } from '../user-form-admin/user-form-admin.component';
import { DATA_CONSUMER_PATH } from '../user-form-data-consumer/user-form-data-consumer.component';
import { DATA_COORDINATOR_PATH  } from '../user-form-data-coordinator/user-form-data-coordinator.component';
import { DATA_OWNER_PATH } from '../user-form-data-owner/user-form-data-owner.component';
import { DATA_VERIFIER_PATH } from '../user-form-data-verifier/user-form-data-verifier.component';
import { SYSTEM_CONFIGURATOR_PATH } from '../user-form-system-configurator/user-form-system-configurator.component';

const links = [
  { label: 'Administrator', href: ADMIN_PATH },
  { label: 'Data Verifier', href: DATA_VERIFIER_PATH },
  { label: 'Data Consumer', href: DATA_CONSUMER_PATH },
  { label: 'Data Coordinator', href: DATA_COORDINATOR_PATH },
  { label: 'System Configurator', href: SYSTEM_CONFIGURATOR_PATH },
  { label: 'Data Owner', href: DATA_OWNER_PATH }
];

@Component({
  selector: 'cbs-select-user-role',
  templateUrl: './select-user-role.component.html',
  styleUrls: ['./select-user-role.component.scss']
})
export class SelectUserRoleComponent implements OnInit {
  links;

  constructor() {
    this.links = links;
  }

  ngOnInit() {}
}
