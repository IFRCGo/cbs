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
    <h2 class="modal-title pull-left">Export Case Reports</h2>
    <button type="button" class="close pull-right" aria-label="Close" (click)="bsModalRef.hide()">
      <span aria-hidden="true">&times;</span>
    </button>
  </div>
  <div class="modal-body">
    Export type 
    <input [(ngModel)]="exportType" type="radio" name="export" value="excel" />Excel 
    <input [(ngModel)]="exportType" type="radio" name="export" value="csv" />Csv 
    <input [(ngModel)]="exportType" type="radio" name="export" value="pdf" />Pdf<br/>
    Filter
    <input [(ngModel)]="exportFilter" type="radio" name="filter" value="all" />All 
    <input [(ngModel)]="exportFilter" type="radio" name="filter" value="success" />Success 
    <input [(ngModel)]="exportFilter" type="radio" name="filter" value="error" />Error
    <input [(ngModel)]="exportFilter" type="radio" name="filter" value="unknown_sender" />Unknown Sender<br/>
    OrderBy
    <input [(ngModel)]="exportOrderBy" type="radio" name="orderBy" value="time" />Time 
    <input [(ngModel)]="exportOrderBy" type="radio" name="orderBy" value="males_under" />Males < 5 
    <input [(ngModel)]="exportOrderBy" type="radio" name="orderBy" value="males_over" />Males >= 5
    <input [(ngModel)]="exportOrderBy" type="radio" name="orderBy" value="females_under" />Females < 5 
    <input [(ngModel)]="exportOrderBy" type="radio" name="orderBy" value="females_over" />Females >= 5<br/>
    Ordering direction
    <input [(ngModel)]="exportDirection" type="radio" name="direction" value="asc" />Ascending 
    <input [(ngModel)]="exportDirection" type="radio" name="direction" value="desc" />Decending<br/> 
  </div>
  <div class="modal-footer">
    <button type="button" class="btn btn-default" (click)="export()">Export</button>
  </div>
  `
})
export class CaseReportExporterModalContent {
  exportType: string = 'excel';
  exportFilter: string = 'all';
  exportOrderBy: string = 'time';
  exportDirection: string = 'desc';

  constructor (public bsModalRef: BsModalRef, private exporterService: CaseReportExporter) {}

  export() {
    this.bsModalRef.hide();
    
    switch (this.exportType) {
      case 'pdf':
        this.exporterService.exportToPdf(this.exportFilter, this.exportOrderBy, this.exportDirection);
        break;
      case 'csv':
        this.exporterService.exportToCsv(this.exportFilter, this.exportOrderBy, this.exportDirection);
        break;
      case 'excel':
        this.exporterService.exportToExcel(this.exportFilter, this.exportOrderBy, this.exportDirection);
        break;
    }
  }
}


