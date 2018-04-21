import { Component, OnInit, isDevMode } from '@angular/core';
import { UserManager, WebStorageStateStore } from 'oidc-client';

import { AuthenticationService } from './authentication.service';

@Component({
    selector: 'cbs-nav-top-bar',
    templateUrl: `./nav-top-bar.component.html`,
    styleUrls: ['./nav-top-bar.component.scss']
})
export class NavTopBarComponent implements OnInit {
    societies:any[];
    name:string;
    loggedIn:boolean;

    constructor(private authentication:AuthenticationService) {
    }

    ngOnInit() {
        this.authentication.societies.subscribe((societies) => {
            this.societies = societies;
        });
        this.authentication.name.subscribe((name) => {
            this.name = name;
        });
        this.authentication.isLoggedIn.subscribe((loggedIn) => {
            this.loggedIn = loggedIn;
        });
    }
}
