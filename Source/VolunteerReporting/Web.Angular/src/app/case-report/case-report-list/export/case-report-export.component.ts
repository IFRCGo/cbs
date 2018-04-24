import { Component } from '@angular/core';
import { NgxSmartModalService } from 'ngx-smart-modal';

import { SortableColumn } from '../sort/columns';
import { QuickFilter } from '../filtering/filter.pipe';

class FieldsToExport {
  all: boolean = true
  timestamp: boolean = false
  status: boolean = false
  datacollector: boolean = false
  healthrisk: boolean = false
  femalesUnder5: boolean = false
  females5AndOlder: boolean = false
  malesUnder5: boolean = false
  males5AndOlder: boolean = false
}

@Component({
    selector: 'cbs-case-report-export',
    templateUrl: './case-report-export.component.html',
    styleUrls: ['./case-report-export.component.scss']
})
export class CaseReportExportComponent {
    fields : FieldsToExport = new FieldsToExport()

    constructor(
        private modal: NgxSmartModalService
    ) { }

    open(filter: QuickFilter, sortColum: SortableColumn, sortDescending: boolean) {
      this.modal.getModal('modalExportCaseReports').open()
    }

    fieldsChanged(field, selected) {
      if (field === 'all' && selected) {
        this.fields.timestamp = false;
        this.fields.status = false;
        this.fields.datacollector = false;
        this.fields.healthrisk = false;
        this.fields.femalesUnder5 = false;
        this.fields.females5AndOlder = false;
        this.fields.malesUnder5 = false;
        this.fields.males5AndOlder = false;
      } else if (field !== 'all' && selected) {
        this.fields.all = false;
      }
    }
}
