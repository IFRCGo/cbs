import { Component, Input } from '@angular/core';

import { Column, SortableColumn } from './columns';


@Component({
    selector: '[column]',
    templateUrl: './sortable-column.component.html'
})
export class SortableColumnComponent {
    @Input('column')
    column: Column;

    @Input('current-sorted')
    current: SortableColumn;

    @Input('sort-descending')
    descending: boolean;

    isSortedAscending(): boolean {
        return this.column === this.current && !this.descending;
    }

    isSortedDescending(): boolean {
        return this.column === this.current && this.descending;
    }
}
