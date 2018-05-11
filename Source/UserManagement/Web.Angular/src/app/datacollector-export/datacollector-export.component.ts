import { Component, OnInit } from '@angular/core';
import { DataCollectorService } from '../services/data-collector.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap';
import { environment } from '../../environments/environment';
import { NgxSmartModalService } from 'ngx-smart-modal';

@Component({
  selector: 'cbs-datacollector-export',
  templateUrl: './datacollector-export.component.html',
  styles: ['./datacollector-export.component.scss']
})
export class DatacollectorExportComponent {
  readonly exportBackendUrl: string = `${environment.api}/api/datacollectors/export`;

// TODO: This should in the future be a modal window with filtering and time range stuff for exporting datacollectors

  constructor(
    private service: DataCollectorService,
    private modal: NgxSmartModalService) {

   }


   open() {
    this.modal.getModal('modalExportDataCollectors').open();
  }
}
