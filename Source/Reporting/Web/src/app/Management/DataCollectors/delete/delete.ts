import { Component, Input, TemplateRef, Output, EventEmitter } from '@angular/core';
import { BsModalService } from 'ngx-bootstrap/modal';
import { BsModalRef } from 'ngx-bootstrap/modal/bs-modal-ref.service';
import { DataCollector } from '../DataCollector';
import { DeleteDataCollector } from '../DeleteDataCollector';

import { CommandCoordinator } from '@dolittle/commands';

@Component({
    selector: 'delete-user',
    templateUrl: './delete.html'
})
export class Delete {
    command: DeleteDataCollector = new DeleteDataCollector();

    @Input() user: DataCollector;
    @Output() onDelete: EventEmitter<boolean> = new EventEmitter<boolean>();
    modalRef: BsModalRef;

    constructor(
        private modalService: BsModalService
    ) {
    }

    openModal(template: TemplateRef<any>) {
        this.modalRef = this.modalService.show(template)
    }

    deleteUser() {
        this.command.dataCollectorId = this.user.id;
        const commandCoordinator = new CommandCoordinator();
        commandCoordinator.handle(this.command)
            .then(response => {
                this.onDelete.emit(true);
                this.modalRef.hide();

            })
            .catch(response => {
                this.modalRef.hide();
            });
    }
}
