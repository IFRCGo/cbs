import { Component, OnInit } from '@angular/core';

import { AuthenticationService } from './authentication.service';

@Component({
  selector: 'cbs-if-logged-in',
  templateUrl: './if-logged-in.component.html'
})
export class IfLoggedInComponent implements OnInit {
    loggedIn:boolean;

    constructor(private authentication:AuthenticationService) {
        this.loggedIn = false;
    }

    ngOnInit() {
        this.authentication.isLoggedIn.subscribe((loggedIn) => {
            this.loggedIn = loggedIn;
        });
    }
}
