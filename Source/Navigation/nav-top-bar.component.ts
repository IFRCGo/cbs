import { Component, OnInit } from '@angular/core'

@Component({
    selector: 'cbs-nav-top-bar',
    templateUrl: `./nav-top-bar.component.html`,
    styleUrls: ['./nav-top-bar.component.scss']
})
export class NavTopBarComponent implements OnInit {
    societies:any[];

    constructor() {
        this.societies = ['Norway', 'Sweden'];
    }

    ngOnInit() {
        
        
    }
}

