import { Component, Input, TemplateRef } from '@angular/core';
import { BsModalService } from 'ngx-bootstrap/modal';
import { BsModalRef } from 'ngx-bootstrap/modal/bs-modal-ref.service';

import { DataCollector } from '../DataCollector';
import { DeleteDataCollector } from '../Registration/DeleteDataCollector';
import { environment } from '../../../../environments/environment';
import { Router } from '@angular/router';

import { CommandCoordinator } from '@dolittle/commands';

@Component({
    selector: 'delete-user',
    templateUrl: './delete.html'
})
export class Delete {
    command: DeleteDataCollector = new DeleteDataCollector();

    @Input() user: DataCollector;
    modalRef: BsModalRef;

    constructor(
        private commandCoordinator: CommandCoordinator,
        private modalService: BsModalService,
        private router: Router
    ) {
    }

    openModal(template: TemplateRef<any>) {
        this.modalRef = this.modalService.show(template)
    }

    deleteUser(id: string) {
        this.command.dataCollectorId = this.user.id;
        
        this.commandCoordinator.handle(this.command)
            .then(response => {
                this.modalRef.hide();
                this.router.navigate(['list']);
                window.location.reload();

            })
            .catch(response => {
                if (!environment.production) {
                    console.error(response);
                }
                this.router.navigate(['list']);
            });
    }
}
