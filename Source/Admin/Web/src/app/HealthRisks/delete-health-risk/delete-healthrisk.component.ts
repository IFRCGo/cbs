import { Component, Input, TemplateRef } from '@angular/core';
import { BsModalService } from 'ngx-bootstrap/modal';
import { BsModalRef } from 'ngx-bootstrap/modal/bs-modal-ref.service';

import { Router } from '@angular/router';
import { CommandCoordinator } from '@dolittle/commands';
import { HealthRisk } from '../HealthRisk';
import { DeleteHealthRisk } from '../DeleteHealthRisk';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'cbs-delete-healthrisk',
    templateUrl: './delete-healthrisk.component.html'
})
export class DeleteHealthRiskComponent {
    cmd: DeleteHealthRisk = new DeleteHealthRisk();

    @Input() risk: HealthRisk;
    modalRef: BsModalRef;

    constructor(
        private modalService: BsModalService,
        private router: Router,
        private toastr: ToastrService
    ) {
    }

    openModal(template: TemplateRef<any>) {
        this.modalRef = this.modalService.show(template)
    }

    deleteHealthrisk(id: string) {
        this.cmd.healthRiskId = this.risk.id;
        
        const commandCoordinator = new CommandCoordinator();
        commandCoordinator.handle(this.cmd)
            .then(response => {
                this.modalRef.hide();
                this.router.navigate(['healthrisk']); //TODO: Route back
                window.location.reload();

            })
            .catch(response => {
                this.toastr.error('There were problems while trying to delete health risk');
                this.router.navigate(['']);//TODO: Route back
            });
    }
}
