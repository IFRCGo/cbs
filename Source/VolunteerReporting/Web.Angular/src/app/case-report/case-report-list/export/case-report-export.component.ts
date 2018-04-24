import { Component } from '@angular/core';
import { NgxSmartModalService } from 'ngx-smart-modal';

import { environment } from '../../../../environments/environment';
import { Column, SortableColumn, CaseReportColumns } from '../sort/columns';
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

const createExportableFieldsArray = (original: Array<Column>, columns: number = 2): Array<Array<Column>> => {
    const fields = [new Column('all','All')].concat(original);
    const rows = Math.ceil(fields.length/columns);
    const columnar = [];
    for (let i = 0; i < fields.length; i += rows) {
        columnar.push(fields.slice(i, i+rows));
    }
    const array = [];
    for (let i = 0; i < rows; i++) {
        const row = [];
        for (let j = 0; j < columns; j++) {
            if (columnar[j][i]) {
                row.push(columnar[j][i]);
            }
        }
        array.push(row);
    }
    return array;
};

@Component({
    selector: 'cbs-case-report-export',
    templateUrl: './case-report-export.component.html',
    styleUrls: ['./case-report-export.component.scss']
})
export class CaseReportExportComponent {
    readonly exportBackendUrl: string = `${environment.api}/api/casereports/export`;

    allFilters: Array<QuickFilter> = QuickFilter.Filters;
    allSortableColumns: Array<Column> = CaseReportColumns.filter((c: Column) => c instanceof SortableColumn) as Array<SortableColumn>;
    allFields: Array<Array<Column>> = createExportableFieldsArray(CaseReportColumns);

    fields : { [key: string]: boolean } = { "all": true };

    constructor(
        private modal: NgxSmartModalService
    ) { }

    open(filter: QuickFilter, sortColum: SortableColumn, sortDescending: boolean) {
        /*const modal = this.modal.getModal('modalExportCaseReports');
        modal.setData({

        });
        modal.open();
        */
        console.log('Set data', filter, sortColum, sortDescending);
        this.modal.setModalData({
          filter: filter,
          sortColumn: sortColum,
          sortDescending: sortDescending,
        },'modalExportCaseReports', true);
        this.modal.getModal('modalExportCaseReports').open();
    }

    fieldsChanged(field, selected) {
        if (field === 'all' && selected) {
            CaseReportColumns.forEach((c: Column) => {
                this.fields[c.name] = false;
            });
        } else if (field !== 'all' && selected) {
            this.fields['all'] = false;
        }
    }
}
