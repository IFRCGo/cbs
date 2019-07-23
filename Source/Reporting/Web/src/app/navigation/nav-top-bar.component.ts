import { Component, OnInit, isDevMode } from '@angular/core';
import CBSNavigation from '../../../../../Navigation/Web.React/lib/index.js';

@Component({
    selector: 'cbs-nav-top-bar',
    templateUrl: `../../../../../Navigation/Web.React/lib/index.js`,
})
export class NavTopBarComponent implements OnInit {
    static apiBaseUrl: string;
    name: string;

    constructor() {
        this.name = 'Unknown';
    }

    ngOnInit() {
        fetch(`${NavTopBarComponent.apiBaseUrl}/identity`).then(async response => this.name = await response.text());
        CBSNavigation.render();
    }

    logout() {
        window.location.href = `${NavTopBarComponent.apiBaseUrl}/signout`;
    }
}
