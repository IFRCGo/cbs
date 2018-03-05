import { Component, OnInit, Input, HostListener } from '@angular/core';
import { Subscription } from 'rxjs/Subscription';

import { SortService } from './sort.service';


@Component({
    selector: '[sortable-column]',
    templateUrl: './sortable-column.component.html'
})
export class SortableColumnComponent implements OnInit {
    
    constructor(private sortService: SortService) { }

    @Input('sortable-column')
    columnName: string;

    @Input('sort-direction')
    sortDirection: string = '';

    timeSortDirection: string = "asc";
    private columnSortedSubscription: Subscription;

    @HostListener('click')
    sort() {
        this.sortDirection = this.sortDirection === 'asc' ? 'desc' : 'asc';
        
        // Not used yet
        this.timeSortDirection = this.columnName === "timeStamp"? this.sortDirection : this.timeSortDirection;

        this.sortService.columnSorted({ sortColumn: this.columnName, sortDirection: this.sortDirection });
    }

    ngOnInit() {
        // subscribe to sort changes so we can react when other columns are sorted
        this.columnSortedSubscription = this.sortService.columnSorted$.subscribe(event => {
            // reset this column's sort direction to hide the sort icons
            if (this.columnName != event.sortColumn) {
                this.sortDirection = '';
            }
        });
    }

    ngOnDestroy() {
         this.columnSortedSubscription.unsubscribe();
    }
}
