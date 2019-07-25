import ReactDOM from 'react-dom';
import React from 'react';
import {Component, onInit, AfterContentInit, ViewEncapsulation} from '@angular/core';
import CBSNavigation from '../../../node_modules/navigation/';

@Component({
  selector: 'navbar-host',
  templateUrl:'./navbar-host.component.html',
  styleUrls: ['../../../node_modules/navigation/lib/cbs-navigation-v1.scss'],
  encapsulation: ViewEncapsulation.None
})

export class NavbarHostComponent implements AfterContentInit, onInit {
    static apiBaseUrl: string;
    username: string;  

    constructor() {
      this.username = 'Unknown';
    }

    ngOnInit(){
      fetch(`${NavbarHostComponent.apiBaseUrl}/identity`).then(async response => this.username = await response.text());
    }

    ngAfterContentInit(){
        ReactDOM.render(React.createElement(CBSNavigation, {activeMenuItem: 'reporting/case-reports', username: this.username}), document.getElementById("navbar"));
    }
}