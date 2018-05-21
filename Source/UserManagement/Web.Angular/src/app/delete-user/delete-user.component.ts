import { Component, Input, TemplateRef } from '@angular/core';
import { BsModalService } from 'ngx-bootstrap/modal';
import { BsModalRef } from 'ngx-bootstrap/modal/bs-modal-ref.service';

import { DataCollectorService } from '../services/data-collector.service';
import { DataCollector } from '../domain/data-collector';
import { CommandCoordinator } from '../services/CommandCoordinator';
import { DeleteDataCollector } from '../domain/data-collector/DeleteDataCollector';
import { environment } from '../../environments/environment.prod';
import { Router } from '@angular/router';

@Component({
    selector: 'cbs-delete-user',
    templateUrl: './delete-user.component.html'
})
export class DeleteUserComponent {
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
        if (!environment.production) {
            console.log('Deleting datacollector with id = ' + this.command.dataCollectorId )
        }
        this.commandCoordinator.handle(this.command)
            .then(response => {
                if (!environment.production) {
                    console.log(response);
                }
                this.modalRef.hide();
                this.router.navigate(['list']);
                window.location.reload();

            })
            .catch(response => {
                if (!environment.production) {
                    console.error(response);
                }
                // TODO: Maybe use toastr to show error message?
                this.router.navigate(['list']);
            });
    }
}
