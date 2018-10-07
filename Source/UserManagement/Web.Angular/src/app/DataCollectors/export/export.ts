import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';

import { DataCollectorExportService } from '../DataCollectorExportService';
import { environment } from '../../../environments/environment';
import { NgxSmartModalService } from 'ngx-smart-modal';

@Component({
    selector: 'export',
    templateUrl: './export.html',
    styles: ['./export.scss']
})
export class Export {
    readonly exportBackendUrl: string = `${environment.api}/api/datacollectors/export`;

    constructor(
        private service: DataCollectorExportService,
        private modal: NgxSmartModalService) {
    }

    open() {
        this.modal.getModal('modalExportDataCollectors').open();
    }
}
