import { Component, Input, TemplateRef } from '@angular/core';
import { BsModalService } from 'ngx-bootstrap/modal';
import { BsModalRef } from 'ngx-bootstrap/modal/bs-modal-ref.service';

import { StaffUserService } from '../services/staff-user.service';
import { StaffUser } from '../domain/staff-user';

@Component({
    selector: 'cbs-delete-user',
    templateUrl: './delete-user.component.html'
})
export class DeleteUserComponent {
    @Input() user: StaffUser;
    modalRef: BsModalRef;

    constructor(
        private staffUserService: StaffUserService,
        private modalService: BsModalService
    ) {}

    openModal(template: TemplateRef<any>) {
        this.modalRef = this.modalService.show(template)
    }

    deleteUser(id: string) {
        this.staffUserService.deleteUser(id);
        this.modalRef.hide();

        // TODO: reload userList on success
    }
}
