import { Component, OnInit, isDevMode } from '@angular/core';

@Component({
    selector: 'cbs-nav-top-bar',
    templateUrl: `./nav-top-bar.component.html`,
    styleUrls: ['./nav-top-bar.component.scss']
})
export class NavTopBarComponent implements OnInit {
    static apiBaseUrl: string;
    name: string;

    constructor() {
        this.name = 'Unknown';
    }

    ngOnInit() {
        fetch(`${NavTopBarComponent.apiBaseUrl}/identity`).then(async response => this.name = await response.text());
    }
}
