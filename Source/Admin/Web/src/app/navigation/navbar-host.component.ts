import React, { createElement } from 'react';
import ReactDOM, { render } from 'react-dom';
import {Component, OnInit, AfterContentInit, ViewEncapsulation} from '@angular/core';
import CBSNavigation from 'navigation/lib/index.js';

@Component({
  selector: 'navbar-host',
  templateUrl:'./navbar-host.component.html',
  styleUrls: ['../../../node_modules/navigation/lib/cbs-navigation-v1.scss'],
  encapsulation: ViewEncapsulation.None
})

export class NavbarHostComponent implements AfterContentInit {
  static apiBaseUrl: string;
    /*
    username: string;  

    constructor() {
      this.username = 'Unknown';
    }

    ngOnInit(){
      fetch(`${NavbarHostComponent.apiBaseUrl}/identity`).then(async response => this.username = await response.text());
    }*/

    ngAfterContentInit(){
        render(createElement(CBSNavigation, {activeMenuItem: 'admin'}), document.getElementById("navbar"));
    }
}