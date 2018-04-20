import { Component, Input, TemplateRef } from '@angular/core';
import { BsModalService } from 'ngx-bootstrap/modal';
import { BsModalRef } from 'ngx-bootstrap/modal/bs-modal-ref.service';

import { DataCollectorService } from '../services/data-collector.service';
import { DataCollector } from '../domain/data-collector';

@Component({
    selector: 'cbs-delete-user',
    templateUrl: './delete-user.component.html'
})
export class DeleteUserComponent {
    @Input() user: DataCollector;
    modalRef: BsModalRef;

    constructor(
        private dataCollectorService: DataCollectorService,
        private modalService: BsModalService
    ) {}

    openModal(template: TemplateRef<any>) {
        this.modalRef = this.modalService.show(template)
    }

    deleteUser(id: string) {
        console.log(id);
        this.dataCollectorService.deleteDataCollector(id);
        this.modalRef.hide();
    }
}
