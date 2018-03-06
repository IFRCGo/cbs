import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
    selector: 'cbs-nav-top-bar',
    templateUrl: `./nav-top-bar.component.html`,
    styleUrls: ['./nav-top-bar.component.scss']
})
export class NavTopBarComponent implements OnInit {
    navigationServiceUrl: String
    constructor(public sanitizer: DomSanitizer) { }

    ngOnInit() {
        this.navigationServiceUrl = "//localhost:9999";
    }

}
