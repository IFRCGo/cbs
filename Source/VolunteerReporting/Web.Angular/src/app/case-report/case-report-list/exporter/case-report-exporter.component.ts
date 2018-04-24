import { Component, OnInit } from '@angular/core';
import { CaseReportExporter } from './case-report-exporter.service';
import { BsModalService } from 'ngx-bootstrap/modal';
import { BsModalRef } from 'ngx-bootstrap/modal/bs-modal-ref.service';

@Component({
  selector: 'case-report-exporter',
  template: `
    <button type="button" class="btn btn-primary" (click)="openModal()">
      Export
    </button>
      
  `,
  providers: [BsModalService]
})
export class CaseReportExporterComponent implements OnInit {
  bsModalRef: BsModalRef;

  constructor(private modalService: BsModalService) { }

  ngOnInit() {}

  openModal() {
    this.bsModalRef = this.modalService.show(CaseReportExporterModalContent);
  }
}
@Component( {
  selector: 'modal-content',
  template: `
  <div class="modal-header">
    <h4 class="modal-title pull-left">Case Report Export</h4>
    <button type="button" class="close pull-right" aria-label="Close" (click)="bsModalRef.hide()">
      <span aria-hidden="true">&times;</span>
    </button>
  </div>
  <div class="modal-body">
    <input [(ngModel)]="exportType" type="radio" name="export" value="excel" />Excel 
    <input [(ngModel)]="exportType" type="radio" name="export" value="csv" />Csv 
    <input [(ngModel)]="exportType" type="radio" name="export" value="pdf" />Pdf 
  </div>
  <div class="modal-footer">
    <button type="button" class="btn btn-default" (click)="export()">Export</button>
  </div>
  `
})
export class CaseReportExporterModalContent {
  exportType: string;
  constructor (public bsModalRef: BsModalRef, private exporterService: CaseReportExporter) {}

  export() {
    this.bsModalRef.hide();
    
    switch (this.exportType) {
      case 'pdf':
        this.exporterService.exportToPdf();
        break;
      case 'csv':
        this.exporterService.exportToCsv();
        break;
      case 'excel':
        this.exporterService.exportToExcel();
        break;
    }
  }
}


