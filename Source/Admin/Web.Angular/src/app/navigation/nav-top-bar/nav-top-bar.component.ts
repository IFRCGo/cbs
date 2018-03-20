import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'cbs-nav-top-bar',
    templateUrl: `./nav-top-bar.component.html`,
    styleUrls: ['./nav-top-bar.component.scss']
})
export class NavTopBarComponent implements OnInit {
    navigationServiceUrl: string;
    displayNavBar: boolean;

    constructor(public sanitizer: DomSanitizer, private http: HttpClient) {
        this.navigationServiceUrl = "//localhost:9999";
    }
    
    async ngOnInit() {
        this.displayNavBar = true;
        this.http.get(this.navigationServiceUrl, { responseType: 'text' })
            .subscribe(
                data => {  },
                error => { this.displayNavBar = false; }
            )
    }
}
